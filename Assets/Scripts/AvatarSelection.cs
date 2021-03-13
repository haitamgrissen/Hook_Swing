using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSelection : MonoBehaviour
{
    [SerializeField]
    GameObject[] characters;
    [SerializeField]
    int selectedcharcternumber;
    [SerializeField]
    [Range(0, 3)] 
    int select;
    [SerializeField]
    bool editing;
    private void Start()
    {
       
        
        if (editing)
        {
            if (selectedcharcternumber != select & select < characters.Length & select >= 0)
            {
                selectedcharcternumber = select;
                change();
            }
        }
        else
        {
            if (selectedcharcternumber != PlayerPrefs.GetInt("selectedcharacter") & PlayerPrefs.GetInt("selectedcharacter") < characters.Length & PlayerPrefs.GetInt("selectedcharacter") >= 0)
            {
                selectedcharcternumber = PlayerPrefs.GetInt("selectedcharacter");
                change();
            }
        }
    }
    private void Update()
    {
        if (editing)
        {
            if (selectedcharcternumber != select & select < characters.Length & select >= 0/*PlayerPrefs.GetInt("selectedcharacter")*/)
            {
                selectedcharcternumber = select /*PlayerPrefs.GetInt("selectedcharacter")*/;
                change();
            }
        }
        else
        {
            if (selectedcharcternumber != PlayerPrefs.GetInt("selectedcharacter") & PlayerPrefs.GetInt("selectedcharacter") < characters.Length & PlayerPrefs.GetInt("selectedcharacter") >= 0)
            {
                selectedcharcternumber = PlayerPrefs.GetInt("selectedcharacter");
                change();
            }
        }
        
    }
    private void change()
    {
        
        foreach (GameObject character in characters)
        {
            character.SetActive(false);
        }

        characters[selectedcharcternumber].SetActive(true);
    }
}
