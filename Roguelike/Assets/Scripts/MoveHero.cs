using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHero : MonoBehaviour
{
    public float speed = 50f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vector2 = new Vector2(1,-1);
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if ((Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow)))
        {
            rb.MovePosition(rb.position + Vector2.one * moveX * speed * Time.deltaTime);
        }

            if ((Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow)))
        {

            rb.MovePosition(rb.position + vector2 * moveX * speed * Time.deltaTime);

          
        }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) 
        {   
            rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);
        }
            if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.MovePosition(rb.position + Vector2.up * moveY * speed * Time.deltaTime);
        }

        //TODO:
        //Устранение паузы между сменой направлений движения
        //Анимация




    }
}
