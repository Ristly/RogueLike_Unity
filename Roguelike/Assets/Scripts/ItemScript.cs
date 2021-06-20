using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemScript : MonoBehaviour
{
    
    private int item ; 
    // Start is called before the first frame update
    void Start()
    {
        item =Random.Range(1, this.gameObject.transform.childCount);
        this.gameObject.transform.GetChild(item).GetComponent<SpriteRenderer>().enabled = true;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
    }

    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<MoveHero>(out MoveHero pers))
        {
      
            switch (item)
            {
                case 1:
                    pers.health += 1;
                    break;
                case 2:
                    pers.damage += 1;
                    break;
                case 3:
                    pers.score += 1;
                    break;

            }
            Destroy(gameObject);
        }
        
    }
}
