using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    
    public int flag;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        


    }

    // Update is called once per frame
    void Update()
    {
        float delay = 1;
        
        switch (flag)
        {
            case 1:
                rb.AddForce(Vector2.up,ForceMode2D.Force+50);
                
                Destroy(gameObject, delay);
                break;
            case 2:
                rb.AddForce(Vector2.right, ForceMode2D.Force + 50);

                Destroy(gameObject, delay);
                break;
            case 3:
                rb.AddForce(Vector2.down, ForceMode2D.Force + 50);

                Destroy(gameObject, delay);
                break;
            case 4:
                rb.AddForce(Vector2.left, ForceMode2D.Force + 50);

                Destroy(gameObject, delay);
                break;
        }
        
    }


}
