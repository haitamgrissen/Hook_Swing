using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour {
    GameManager gm;
    GameObject gamemanger;
    public static bool wonlevl;


    private void Start()
    {
        wonlevl = false;
        gamemanger = GameObject.FindGameObjectWithTag("GameManager");
        gm = gamemanger.GetComponent<GameManager>();
    }

    private void Update()
    {
         if (gamemanger == null || gm == null)
        {
            gamemanger = GameObject.FindGameObjectWithTag("GameManager");
            gm = gamemanger.GetComponent<GameManager>();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !wonlevl)
        {         
            wonlevl = true;
            gm.levelwon();
        }
       
    }


}
