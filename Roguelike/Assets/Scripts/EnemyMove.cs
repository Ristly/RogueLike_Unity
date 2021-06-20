using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public LevelChange portal;
    public ItemScript DropItem;
    public int enemyIndex;

    private GameObject player;
    public float difficulty;

    private int health = 3;
    private int dmg = 1;
    private float spd = 2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");

        switch (enemyIndex)
        {
            case 0:
                health = Mathf.FloorToInt(3 * difficulty); //Common melee foe
                dmg = 1;
                spd = 2;
                break;

            case 1:
                health = Mathf.FloorToInt(10 * difficulty);//Uncommon melee foe
                dmg = 3;
                spd = 90;
                
                break;

            case 3:
                health *= Mathf.FloorToInt(15 * difficulty); //Boss melee foe
                dmg = 5;
                spd = .5f;
                break;

        }


    }

    // Update is called once per frame
    void Update()
    {
       

        switch (enemyIndex)
        {
            case 0:
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, spd * Time.deltaTime); //Common melee foe
                transform.position = new Vector3(transform.position.x, transform.position.y, 20);
                break;
            case 1:
                transform.position = new Vector3(transform.position.x, transform.position.y, 20);
                break;
            case 3:
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, spd * Time.deltaTime); //Boss melee foe
                transform.position = new Vector3(transform.position.x, transform.position.y, 2);
                break;

        }

        
        transform.rotation = Quaternion.Euler(0,0,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.TryGetComponent<BulletFly>(out BulletFly bullet))
        {
            Destroy(bullet.gameObject);
            health -= player.GetComponent<MoveHero>().damage;
            if (enemyIndex == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, spd * Time.deltaTime);
            }
            else if(enemyIndex == 3)
            {
                spd += .5f;
            }

            if (health <= 0) 
            {
                

                switch (enemyIndex)
                {
                    case 0:
                        player.GetComponent<MoveHero>().score+=2; //Common melee foe
                        ItemScript foeItem = Instantiate(DropItem);
                        foeItem.transform.position = transform.position;
                        
                        break;
                    case 1:
                        player.GetComponent<MoveHero>().score += 5; //Uncommon melee foe
                        break;
                    case 3:
                        player.GetComponent<MoveHero>().score += 35; //Boss melee foe
                        for(int i = 0; i <4; i++)
                        {
                            ItemScript bossItem = Instantiate(DropItem);
                            bossItem.transform.position = transform.position;
                            
                        }
                       LevelChange port = Instantiate(portal);
                        port.transform.position = transform.parent.transform.GetComponentInChildren<Spawnpoint>().transform.position;
                        break;

                }
                Destroy(gameObject);

            }
        }
        else if(collision.gameObject.TryGetComponent<MoveHero>(out MoveHero pers))
        {
            switch (enemyIndex)
            {
                case 0:
                    pers.health -= dmg; //Common melee foe
                    break;
                case 1:
                    pers.health -= dmg; //Uncommon melee foe
                    break;
                case 3:
                    pers.health -= dmg; ; //Boss melee foe
                    break;

            }



            
            if (pers.health <= 0)
            {
                pers.Death();
                
            }
        }
    }

 
}
