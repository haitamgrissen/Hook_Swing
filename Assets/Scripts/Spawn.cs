using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    [SerializeField]
    GameObject player;
    [Header("characters")]
    [SerializeField]
    GameObject[] characters;
    [SerializeField]
    [Range(0, 2)]
    int selectedcharcternumber;
    GameObject selectedcharacter;

    [Header("Other")]
    [SerializeField]
    GameObject spawneffect;
    [SerializeField]
    GameObject lrgo;
    


    void Start ()
    {
       
        selectedcharcternumber = PlayerPrefs.GetInt("selectedcharacter");
        selectedcharacter = characters[selectedcharcternumber];
        spawn();
    }

    public void spawnagain()
    {
        //Instantiate(player, transform.position, Quaternion.identity);
        Instantiate(selectedcharacter, transform.position, Quaternion.identity);
        Instantiate(spawneffect, transform.position, Quaternion.Euler(90, 0, 0));
    }

    void spawn()
    {
        //Instantiate(player, transform.position, Quaternion.identity);
        Instantiate(selectedcharacter, transform.position, Quaternion.identity);
        Instantiate(lrgo, transform.position, Quaternion.identity);
        Instantiate(spawneffect, transform.position, Quaternion.Euler(90, 0, 0));
    }

}
