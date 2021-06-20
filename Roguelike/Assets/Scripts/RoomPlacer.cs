using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomPlacer : MonoBehaviour
{

    public Room[] RoomPrefabs;
    public Room StartLocation;
    public Room[,] AllRooms;
    public EnemyMove[] Enemies;
    public int max = 5;
    public MoveHero player;

    public float difficulty;
    private void Start()
    {
        difficulty = 1;
        Init();
        player.PlayerReset();
        
    }



    public void Init()
    {
        Room[] temp = FindObjectsOfType<Room>();
        for (int i = 0; i < temp.Length; i++) Destroy(temp[i].gameObject);


       

        AllRooms = new Room[max, max];
        AllRooms[2, 0] = StartLocation;
        Room StartL = Instantiate(StartLocation);
        StartL.transform.position = new Vector2(0, 0);
        StartL.xPos = 2;
        StartL.yPos = 0;
        StartL.roomsPos = this;
        player.transform.position = StartL.transform.Find("Start_point").position;
        player.cam.transform.position = StartL.transform.Find("CamPos").position;
        player.cam.GetComponent<Camera>().orthographicSize = 5.60151f;
        player.isDead = false;

        Room newsr = Instantiate(RoomPrefabs[1]);
        newsr.transform.position = new Vector2(-1, 11.5f);
        newsr.gameObject.SetActive(true);
        AllRooms[2, 1] = newsr;
        newsr.xPos = 2;
        newsr.yPos = 1;
        newsr.roomsPos = this;
        for (int c = 0; c < newsr.gameObject.GetComponentsInChildren<Spawnpoint>().Length; c++) SpawnEnemy(newsr, Random.Range(0, 2), newsr.gameObject.GetComponentsInChildren<Spawnpoint>()[c]);



        for (int i = 0; i < 7; i++)
        {
            RoomSpawner(i);
        }

    }


    private void RoomSpawner(int roomNumber)
    {
        HashSet<Vector2Int> freePlaces = new HashSet<Vector2Int>();

        for(int x = 0; x< AllRooms.GetLength(0); x++)
        {
            for (int y = 0; y < AllRooms.GetLength(1); y++)
            {
                if (AllRooms[x, y] == null) continue;
                if (x == 2 && y == 2) continue;

                int maxX = AllRooms.GetLength(0) - 1, maxY = AllRooms.GetLength(1) - 1;

                if (x > 0 && AllRooms[x - 1, y] == null) freePlaces.Add(new Vector2Int(x - 1, y));
                if (x < maxX && AllRooms[x + 1, y] == null) freePlaces.Add(new Vector2Int(x + 1, y));
                if (y > 0 && AllRooms[x, y - 1] == null) freePlaces.Add(new Vector2Int(x, y - 1));
                if (y < maxY && AllRooms[x, y + 1] == null) freePlaces.Add(new Vector2Int(x, y + 1));
            }
        }

        
        
        Room newRoom;
        
        if(roomNumber == 6)
        {
            newRoom = Instantiate(RoomPrefabs[0]);
            
        }
        else if (roomNumber == 5)
        {
            newRoom = Instantiate(RoomPrefabs[RoomPrefabs.Length - 1]);
        }
        else 
        {
            newRoom = Instantiate(RoomPrefabs[Random.Range(1, RoomPrefabs.Length-1)]);
        }

        int tempLim = 100;
        while (tempLim-- > 0) 
        {
            
            Vector2Int pos = freePlaces.ElementAt(Random.Range(0, freePlaces.Count));
            newRoom.RotateRand();

            if (ConnectToRoom(newRoom, pos))
            {
               
                newRoom.transform.position = new Vector2((pos.x - 2) * 28, (pos.y) *26.5f);
                //newRoom.transform.localScale = new Vector3(1, -1, 1);
                AllRooms[pos.x, pos.y] = newRoom;
                newRoom.gameObject.SetActive(true);
                newRoom.yPos = pos.y;
                newRoom.xPos = pos.x;
                newRoom.roomsPos = this;

                if (roomNumber != 6)
                {
                    for(int c = 0;c <newRoom.gameObject.GetComponentsInChildren<Spawnpoint>().Length;c++) SpawnEnemy(newRoom, Random.Range(0, 2), newRoom.gameObject.GetComponentsInChildren<Spawnpoint>()[c]);
                }

                else
                {
                    for (int c = 0; c < newRoom.gameObject.GetComponentsInChildren<Spawnpoint>().Length; c++) SpawnEnemy(newRoom, 3, newRoom.gameObject.GetComponentsInChildren<Spawnpoint>()[c]);
                }

                

                
                break;
            }

            //if (!tmpflag) Destroy(newRoom);
        }
        

        
        
       
    }

    private bool ConnectToRoom(Room room, Vector2Int p)
    {
        int maxX = AllRooms.GetLength(0) - 1, maxY = AllRooms.GetLength(1) - 1;

        List<Vector2Int> neighbours = new List<Vector2Int>();

        if (room.DoorU != null && p.y < maxY && AllRooms[p.x, p.y + 1]?.DoorD != null) neighbours.Add(Vector2Int.up);
        if (room.DoorD != null && p.y > 0 && AllRooms[p.x, p.y - 1]?.DoorU != null) neighbours.Add(Vector2Int.down);
        if (room.DoorR != null && p.x < maxX && AllRooms[p.x + 1, p.y]?.DoorL != null) neighbours.Add(Vector2Int.right);
        if (room.DoorL != null && p.x > 0 && AllRooms[p.x - 1, p.y]?.DoorR != null) neighbours.Add(Vector2Int.left);

        if (neighbours.Count == 0) return false;

        Vector2Int selectedDirection = neighbours[Random.Range(0, neighbours.Count)];
        Room selectedRoom = AllRooms[p.x + selectedDirection.x, p.y + selectedDirection.y];

        if (selectedDirection == Vector2Int.up)
        {
         

            room.DoorU.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            room.DoorU.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;

            selectedRoom.DoorD.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            selectedRoom.DoorD.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;

           
        }
        else if (selectedDirection == Vector2Int.down)
        {
            room.DoorD.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            room.DoorD.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;

            selectedRoom.DoorU.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            selectedRoom.DoorU.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (selectedDirection == Vector2Int.right)
        {
            room.DoorR.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            room.DoorR.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;

            selectedRoom.DoorL.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            selectedRoom.DoorL.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (selectedDirection == Vector2Int.left)
        {
            room.DoorL.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            room.DoorL.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;

            selectedRoom.DoorR.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            selectedRoom.DoorR.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        }

        return true;
    
    }
    
    
    void SpawnEnemy(Room room,int index,Spawnpoint point)
    {
        
        EnemyMove nwFoe = Instantiate(Enemies[index], room.transform);
        //nwFoe.transform.position = point[i].gameObject.transform.position;
        nwFoe.transform.position = new Vector3(point.gameObject.transform.position.x, point.gameObject.transform.position.y, point.gameObject.transform.position.z+17);
        room.FoeInRooms.Add(nwFoe);
        nwFoe.enemyIndex = index;
        nwFoe.difficulty = difficulty;
        nwFoe.gameObject.SetActive(false);

        
    }
}
