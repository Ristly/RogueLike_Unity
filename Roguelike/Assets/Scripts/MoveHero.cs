using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveHero : MonoBehaviour
{
    public float speed = 50f;

    public float spdInc = 0.5f;

    private Rigidbody2D rb;
    private Animator mvment;
    private SpriteRenderer pers;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mvment = this.transform.GetComponent<Animator>();
        pers = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        
        Vector2 vectorLU = new Vector2(1,-1);
        Vector2 vectorRU = new Vector2(1, 1);

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");


        


        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow)) mvment.Play("Run");

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            
            
            rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime );
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                TurnL();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                TurnR();
            }

        }
  
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.MovePosition(rb.position + Vector2.up * moveY * speed * Time.deltaTime );
        }

            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow)) 
        {
            rb.MovePosition(rb.position + vectorLU * (Mathf.Pow(moveX,2)+ Mathf.Pow(moveY, 2)) * speed * Time.deltaTime * spdInc);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            rb.MovePosition(rb.position + vectorLU * (-(Mathf.Pow(moveX, 2) + Mathf.Pow(moveY, 2))) * speed * Time.deltaTime * spdInc);
        }


        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            rb.MovePosition(rb.position + vectorRU * (Mathf.Pow(moveX, 2) + Mathf.Pow(moveY, 2)) * speed * Time.deltaTime * spdInc);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            rb.MovePosition(rb.position + vectorRU * (-(Mathf.Pow(moveX, 2) + Mathf.Pow(moveY, 2))) * speed * Time.deltaTime * spdInc);
        }


        void TurnR()
        {
            pers.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
            pers.transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = true;
            pers.transform.GetChild(2).GetComponent<SpriteRenderer>().flipX = true;
            pers.transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = true;
            pers.transform.GetChild(4).GetComponent<SpriteRenderer>().flipX = true;
            pers.transform.GetChild(5).GetComponent<SpriteRenderer>().flipX = true;

        }

        void TurnL()
        {
            pers.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
            pers.transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = false;
            pers.transform.GetChild(2).GetComponent<SpriteRenderer>().flipX = false;
            pers.transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = false;
            pers.transform.GetChild(4).GetComponent<SpriteRenderer>().flipX = false;
            pers.transform.GetChild(5).GetComponent<SpriteRenderer>().flipX = false;

        }
        //TODO:
        //Устранение паузы между сменой направлений движения
        //Анимация

    }
}
