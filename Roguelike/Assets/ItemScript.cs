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
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject strtTRGR = GameObject.Find("Door");
        strtTRGR.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        strtTRGR.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;

        Debug.Log(item);

        this.gameObject.SetActive(false);
        switch(item){
        case 1: 
                break;
        case 2:
                int temp = GameObject.Find("player").transform.childCount-1;

                GameObject.Find("player").transform.GetChild(temp).GetComponent<SpriteRenderer>().enabled = true;
                break;
        case 3:
                
                break;

        }
    }
}
