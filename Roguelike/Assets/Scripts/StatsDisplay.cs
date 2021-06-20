using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplay : MonoBehaviour
{

    public Text hP;
    public Text score;
    public Text dmg;
    public MoveHero pers;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
        hP.text = "" + pers.health;
        score.text = "" + pers.score;
        dmg.text = "" + pers.damage;
    }
}
