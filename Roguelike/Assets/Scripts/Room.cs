using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject DoorU;
    public GameObject DoorR;
    public GameObject DoorD;
    public GameObject DoorL;
    public int xPos,yPos;
    public RoomPlacer roomsPos;
    public List<EnemyMove> FoeInRooms;

    void Start()
    {
        if (DoorU != null) DoorInteractions(DoorU,false);
        if (DoorR != null) DoorInteractions(DoorR, false);
        if (DoorL != null) DoorInteractions(DoorL, false);
        if (DoorD != null) DoorInteractions(DoorD, false);


    }

    // Update is called once per frame
    void Update()
    {
        RoomScaner();

        bool drUpOpen = (DoorU != null && !DoorU.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled && DoorU.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled);
        bool drROpen = (DoorR != null && !DoorR.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled && DoorR.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled);
        bool drDOpen = (DoorD != null && !DoorD.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled && DoorD.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled);
        bool drLOpen = (DoorL != null && !DoorL.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled && DoorL.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled);


        if (DoorU != null && drUpOpen)
        {
            DoorU.transform.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if(DoorU != null && !drUpOpen)
        {
            DoorU.transform.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (DoorR != null && drROpen)
        {
            DoorR.transform.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if(DoorR != null && !drROpen)
        {
            DoorR.transform.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (DoorD != null && drDOpen)
        {
            DoorD.transform.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if(DoorD != null && !drDOpen)
        {
            DoorD.transform.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (DoorL != null && drLOpen)
        {
            DoorL.transform.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (DoorL != null && !drLOpen)
        {
            DoorL.transform.GetComponent<BoxCollider2D>().enabled = true;
        }

    }

    public void RotateRand()
    {
        int count = Random.Range(0, 4);

        for(int i = 0; i < count; i++)
        {
            transform.Rotate(0, 0, -90);

            GameObject tmp = DoorL;
            DoorL = DoorD;
            DoorD = DoorR;
            DoorR = DoorU;
            DoorU = tmp;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }

    void DoorInteractions(GameObject door, bool flag)
    {
        if (flag)
        {
            door.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            door.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            door.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            door.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        }
       
    }

    void RoomScaner()
    {
        
        if (this.GetComponentsInChildren<EnemyMove>().Length == 0)
        {
            if(DoorU != null)
            {
                if(yPos + 1 < roomsPos.max && roomsPos.AllRooms[xPos, yPos + 1] != null)
                {
                    if ( roomsPos.AllRooms[xPos, yPos + 1].DoorD != null)
                    {
                        DoorInteractions(DoorU, true);
                    }
                }
                
            }

            if (DoorR != null)
            {
                if(xPos + 1 < roomsPos.max && roomsPos.AllRooms[xPos + 1, yPos]!= null)
                {
                    if (roomsPos.AllRooms[xPos + 1, yPos].DoorL != null)
                    {
                        DoorInteractions(DoorR, true);
                    }
                }
                
            }

            if (DoorD != null)
            {
                if(yPos - 1 >= 0 && roomsPos.AllRooms[xPos, yPos - 1] != null)
                {
                    if (roomsPos.AllRooms[xPos, yPos - 1].DoorU != null)
                    {
                        DoorInteractions(DoorD, true);
                    }
                }
                
            }

            if (DoorL != null)
            {
                if (xPos - 1 >= 0 && roomsPos.AllRooms[xPos - 1, yPos] != null)
                {
                    if (roomsPos.AllRooms[xPos - 1, yPos].DoorR != null)
                    {
                        DoorInteractions(DoorL, true);
                    }
                }
                
            }
        }
        else
        {
            
            if (DoorU != null) DoorInteractions(DoorU, false);
            if (DoorR != null) DoorInteractions(DoorR, false);
            if (DoorL != null) DoorInteractions(DoorL, false);
            if (DoorD != null) DoorInteractions(DoorD, false);
        }
    }
}
