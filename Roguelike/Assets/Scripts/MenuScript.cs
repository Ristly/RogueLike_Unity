using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    private GameObject RTable;
    private GameObject Dialog;
    private void Start()
    {
        RTable = GameObject.Find("RecordTable");
        RTable.SetActive(false);

        Dialog = GameObject.Find("ExitDialog");
        Dialog.SetActive(false);


        RTable.transform.Find("Third").GetComponent<Text>().text = "3: " + PlayerPrefs.GetInt("3") + " points"; 
        RTable.transform.Find("Second").GetComponent<Text>().text = "2: " + PlayerPrefs.GetInt("2") + " points";
        RTable.transform.Find("First").GetComponent<Text>().text = "1: " + PlayerPrefs.GetInt("1") + " points";


    }


    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            RTable.SetActive(false);

        }

        
        if (PlayerPrefs.GetInt("Current") > PlayerPrefs.GetInt("1"))
        {

            RTable.transform.Find("Third").GetComponent<Text>().text = "1: " + PlayerPrefs.GetInt("2") + " points";
            RTable.transform.Find("Second").GetComponent<Text>().text = "2: " + PlayerPrefs.GetInt("1") + " points";
            RTable.transform.Find("First").GetComponent<Text>().text = "3: " + PlayerPrefs.GetInt("Current") + " points";


            PlayerPrefs.SetInt("3", PlayerPrefs.GetInt("2"));
            PlayerPrefs.SetInt("2", PlayerPrefs.GetInt("1"));
            PlayerPrefs.SetInt("1", PlayerPrefs.GetInt("Current"));

            PlayerPrefs.DeleteKey("Current");
        }
        else if (PlayerPrefs.GetInt("Current") > PlayerPrefs.GetInt("2"))
        {
            RTable.transform.Find("Third").GetComponent<Text>().text = "2: " + PlayerPrefs.GetInt("2") + " points";
            RTable.transform.Find("Second").GetComponent<Text>().text = "3: " + PlayerPrefs.GetInt("Current") + " points";

            PlayerPrefs.SetInt("3", PlayerPrefs.GetInt("2"));
            PlayerPrefs.SetInt("2", PlayerPrefs.GetInt("Current"));


            PlayerPrefs.DeleteKey("Current");
        }
        else if (PlayerPrefs.GetInt("Current") > PlayerPrefs.GetInt("3"))
        {
            RTable.transform.Find("Third").GetComponent<Text>().text = "3: " + PlayerPrefs.GetInt("Current") + " points";

            PlayerPrefs.SetInt("3", PlayerPrefs.GetInt("Current"));

            PlayerPrefs.DeleteKey("Current");
        }
        PlayerPrefs.Save();
    }

    // Start is called before the first frame update
    public void PlayBtnPress()
    {
        SceneManager.LoadScene("Game");
        if (!PlayerPrefs.HasKey("1") && !PlayerPrefs.HasKey("2") && !PlayerPrefs.HasKey("3"))
        {
            PlayerPrefs.SetInt("1",0);
            PlayerPrefs.SetInt("2",0);
            PlayerPrefs.SetInt("3",0);
            PlayerPrefs.Save();
        }
    }


    public void RecordBtnPress(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void YesBtnPress()
    {
        Application.Quit();
    }

    public void QuitBtnPress()
    {
        Dialog.SetActive(true);
    }


    public void NoBtnPress()
    {
        Dialog.SetActive(false);
    }
}
