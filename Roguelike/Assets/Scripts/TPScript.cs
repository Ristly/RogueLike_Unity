using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPScript : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collision)
    {

        Room curRoom = gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Room>();
        GameObject curDoor = gameObject.transform.parent.gameObject;

        if(collision.TryGetComponent(out MoveHero hero)){
            if (curDoor == curRoom.DoorU)
            {
                
                if (curRoom.roomsPos.AllRooms[curRoom.xPos, curRoom.yPos + 1] != null && curRoom.roomsPos.AllRooms[curRoom.xPos, curRoom.yPos + 1].DoorD != null)
                {
                    
                    collision.gameObject.transform.position = curRoom.roomsPos.AllRooms[curRoom.xPos, curRoom.yPos + 1].DoorD.transform.GetChild(3).position;
                    hero.cam.transform.position = curRoom.roomsPos.AllRooms[curRoom.xPos, curRoom.yPos + 1].transform.Find("CamPos").transform.position;
                    hero.cam.transform.position = new Vector3(hero.cam.transform.position.x, hero.cam.transform.position.y, -50);

                    if (curRoom.roomsPos.AllRooms[curRoom.xPos, curRoom.yPos + 1].transform.rotation.eulerAngles.z == 270 || curRoom.roomsPos.AllRooms[curRoom.xPos, curRoom.yPos + 1].transform.rotation.eulerAngles.z == 90)
                    {
                        
                        hero.cam.GetComponent<Camera>().orthographicSize = 9.80151f;
                    }
                    else
                    {
                        hero.cam.GetComponent<Camera>().orthographicSize = 5.60151f;
                    }
                    ActivateFoe(curRoom.roomsPos.AllRooms[curRoom.xPos, curRoom.yPos + 1]);

                }
            }
            else if (curDoor == curRoom.DoorR)
            {
               
                if (curRoom.roomsPos.AllRooms[curRoom.xPos + 1, curRoom.yPos] != null && curRoom.roomsPos.AllRooms[curRoom.xPos + 1, curRoom.yPos].DoorL != null)
                {
                   
                    collision.gameObject.transform.position = curRoom.roomsPos.AllRooms[curRoom.xPos + 1, curRoom.yPos].DoorL.transform.GetChild(3).position;
                    hero.cam.transform.position = curRoom.roomsPos.AllRooms[curRoom.xPos + 1, curRoom.yPos].transform.Find("CamPos").transform.position;
                    hero.cam.transform.position = new Vector3(hero.cam.transform.position.x, hero.cam.transform.position.y, -50);

                    if (curRoom.roomsPos.AllRooms[curRoom.xPos + 1, curRoom.yPos].transform.rotation.eulerAngles.z == 270 || curRoom.roomsPos.AllRooms[curRoom.xPos + 1, curRoom.yPos].transform.rotation.eulerAngles.z == 90)
                    {
                        
                        hero.cam.GetComponent<Camera>().orthographicSize = 9.80151f;
                    }
                    else
                    {
                        hero.cam.GetComponent<Camera>().orthographicSize = 5.60151f;
                    }
                    ActivateFoe(curRoom.roomsPos.AllRooms[curRoom.xPos + 1, curRoom.yPos]);
                }
            }
            else if (curDoor == curRoom.DoorL)
            {
                
                if (curRoom.roomsPos.AllRooms[curRoom.xPos - 1, curRoom.yPos] != null && curRoom.roomsPos.AllRooms[curRoom.xPos - 1, curRoom.yPos].DoorR != null)
                {
                    
                    collision.gameObject.transform.position = curRoom.roomsPos.AllRooms[curRoom.xPos - 1, curRoom.yPos].DoorR.transform.GetChild(3).position;
                    hero.cam.transform.position = curRoom.roomsPos.AllRooms[curRoom.xPos - 1, curRoom.yPos].transform.Find("CamPos").transform.position;
                    hero.cam.transform.position = new Vector3(hero.cam.transform.position.x, hero.cam.transform.position.y, -50);

                    if (curRoom.roomsPos.AllRooms[curRoom.xPos - 1, curRoom.yPos].gameObject.transform.rotation.eulerAngles.z == 270 || curRoom.roomsPos.AllRooms[curRoom.xPos - 1, curRoom.yPos].gameObject.transform.rotation.eulerAngles.z == 90)
                    {
                        hero.cam.GetComponent<Camera>().orthographicSize = 9.80151f;
                    }
                    else
                    {
                        hero.cam.GetComponent<Camera>().orthographicSize = 5.60151f;
                    }
                    ActivateFoe(curRoom.roomsPos.AllRooms[curRoom.xPos - 1, curRoom.yPos]);
                }

            }
            else if (curDoor == curRoom.DoorD)
            {
                
                if (curRoom.roomsPos.AllRooms[curRoom.xPos, curRoom.yPos - 1] != null && curRoom.roomsPos.AllRooms[curRoom.xPos, curRoom.yPos - 1].DoorU != null)
                {
                    
                    collision.gameObject.transform.position = curRoom.roomsPos.AllRooms[curRoom.xPos, curRoom.yPos - 1].DoorU.transform.GetChild(3).position;
                    hero.cam.transform.position = curRoom.roomsPos.AllRooms[curRoom.xPos, curRoom.yPos - 1].transform.Find("CamPos").transform.position;
                    hero.cam.transform.position = new Vector3(hero.cam.transform.position.x, hero.cam.transform.position.y, -50);

                    if (curRoom.roomsPos.AllRooms[curRoom.xPos, curRoom.yPos - 1].gameObject.transform.rotation.eulerAngles.z == 270 || curRoom.roomsPos.AllRooms[curRoom.xPos, curRoom.yPos - 1].gameObject.transform.rotation.eulerAngles.z == 90)
                    {
                        hero.cam.GetComponent<Camera>().orthographicSize = 9.80151f;
                    }
                    else
                    {
                        hero.cam.GetComponent<Camera>().orthographicSize = 5.60151f;
                    }

                    ActivateFoe(curRoom.roomsPos.AllRooms[curRoom.xPos, curRoom.yPos - 1]);
                }
            }
        }
    }

    void ActivateFoe(Room room)
    {


        
        for (int i = 0; i < room.FoeInRooms.Count; i++)
        {

            room.FoeInRooms[i].gameObject.SetActive(true);

        }
        
        
    }
}
