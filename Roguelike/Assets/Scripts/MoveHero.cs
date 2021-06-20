using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MoveHero : MonoBehaviour
{
    public GameObject pauseUI;

    private float speed = 15f;

    [HideInInspector] public int health ;
    [HideInInspector] public int score;
    public float spdInc = 0.5f;
    [HideInInspector] public int damage ;

    public GameObject cam;
    public BulletFly bullet;


    private Rigidbody2D rb;
    private Animator mvment;
    private SpriteRenderer pers;
    private bool fL = true, fR = false;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerReset();
    }


    public void PlayerReset()
    {
        rb = GetComponent<Rigidbody2D>();
        mvment = this.transform.GetComponent<Animator>();
        pers = GetComponent<SpriteRenderer>();
        health = 3;
        score = 0;
        damage = 1;
    }

    // Update is called once per frame
    void Update()
    {

        
        Vector2 vectorLU = new Vector2(1,-1);
        Vector2 vectorRU = new Vector2(1, 1);

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");


        // Player's movement logic. Work if he isn't dead
        if(!isDead)
        {
           
            if(!pauseUI.gameObject.transform.Find("pause").gameObject.activeSelf)
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)) mvment.Play("Run");

                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {


                    rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        TurnL();
                    }
                    else if (Input.GetKeyDown(KeyCode.D))
                    {
                        TurnR();
                    }

                }



                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                {
                    rb.MovePosition(rb.position + Vector2.up * moveY * speed * Time.deltaTime);
                }

                if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
                {
                    rb.MovePosition(rb.position + vectorLU * (Mathf.Pow(moveX, 2) + Mathf.Pow(moveY, 2)) * speed * Time.deltaTime * spdInc);
                }

                if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
                {
                    rb.MovePosition(rb.position + vectorLU * (-(Mathf.Pow(moveX, 2) + Mathf.Pow(moveY, 2))) * speed * Time.deltaTime * spdInc);
                }


                if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
                {
                    rb.MovePosition(rb.position + vectorRU * (Mathf.Pow(moveX, 2) + Mathf.Pow(moveY, 2)) * speed * Time.deltaTime * spdInc);
                }

                if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
                {
                    rb.MovePosition(rb.position + vectorRU * (-(Mathf.Pow(moveX, 2) + Mathf.Pow(moveY, 2))) * speed * Time.deltaTime * spdInc);
                }



                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    BulletFly newbullet = Instantiate(bullet);
                    newbullet.transform.position = transform.position;
                    newbullet.flag = 2;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    BulletFly newbullet = Instantiate(bullet);
                    newbullet.transform.position = transform.position;
                    newbullet.flag = 4;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    BulletFly newbullet = Instantiate(bullet);
                    newbullet.transform.position = transform.position;
                    newbullet.flag = 1;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    BulletFly newbullet = Instantiate(bullet);
                    newbullet.transform.position = transform.position;
                    newbullet.flag = 3;
                }

            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Time.timeScale != 0)
                {
                    Time.timeScale = 0;
                    pauseUI.gameObject.transform.Find("pause").gameObject.SetActive(true);

                }
                else
                {
                    Time.timeScale = 1;
                    pauseUI.gameObject.transform.Find("pause").gameObject.SetActive(false);

                }

            }
        }

        void TurnR()
        {
            if (!fR)
            {
                for (var i = 0; i < pers.transform.childCount; i++) pers.transform.GetChild(i).GetComponent<SpriteRenderer>().flipX = true;             
                fR = true;
                fL = false;
            }
            

        }

        void TurnL()
        {
            if (!fL)
            {
                for (var i = 0; i < pers.transform.childCount; i++) pers.transform.GetChild(i).GetComponent<SpriteRenderer>().flipX = false;    
                fR = false;
                fL = true;
            }
            
        }

       

    }

    public void Death()
    {
        isDead = true;
        Time.timeScale = 0;
        PlayerPrefs.SetInt("Current",score);
        PlayerPrefs.Save();
        
       

        pauseUI.gameObject.transform.Find("DeathScreen").Find("Score").GetComponent<Text>().text = "Your score: " + score;
        PlayerReset();
        pauseUI.gameObject.transform.Find("DeathScreen").gameObject.SetActive(true);
       

    }
}
