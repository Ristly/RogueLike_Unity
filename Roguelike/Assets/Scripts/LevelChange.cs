using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<MoveHero>(out MoveHero pers))
        {
            FindObjectOfType<RoomPlacer>().difficulty+=.5f;
            FindObjectOfType<RoomPlacer>().Init();
            Destroy(gameObject);
        }
    }

}
