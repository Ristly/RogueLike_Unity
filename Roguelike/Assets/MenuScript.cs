using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    private GameObject temp;

    private void Start()
    {
        GameObject RTable = GameObject.Find("RecordTable");
        RTable.SetActive(false);
    }


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject RTable = GameObject.Find("RecordTable");
            RTable.SetActive(false);

        }

    }

    // Start is called before the first frame update
    public void PlayBtnPress()
    {
        SceneManager.LoadScene("Game");
    }


    public void RecordBtnPress(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void QuitBtnPress()
    {
        Application.Quit();
    }

}
