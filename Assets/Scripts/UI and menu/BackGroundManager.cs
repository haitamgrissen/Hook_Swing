using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    int incr = 5;
    int bg = 0;
    SpriteRenderer sprite;
    [SerializeField]
    Sprite[] spr;
    void Awake ()
    {
        sprite = GetComponent<SpriteRenderer>();
            if (bg >= 9)
            {
                bg = Random.Range(0, 10);
            }       
    }
    private void Update()
    {
        
        if (PlayerPrefs.GetInt("level") > incr -1 )
        {
            incr = incr + 5;

           /* if (bg >= 9)
            {
                bg = Random.Range(0, 10);
            }*/
            if (bg < 9)
            {
                bg = bg + 1;
            }
            switchbg();
        }

    }
    void switchbg()
    {
        sprite.sprite = spr[bg];    
    }
}
