using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    #region//vars


    admanager ad;
    GameObject player;
    GameObject spawner;
    new GameObject camera;
    GameObject canvas;
    UiManager usrmng;
    Spawn sp;
    Camera cm;
    [SerializeField]
    float slowdownfactor = 0.1f;  
    //[SerializeField]
    //float timetorespawn = 0.5f;
    [SerializeField]
    float slowedtime = 1f;
    [SerializeField]
    float movetonextscenetime;
    public int levelnumber;

    #endregion

    private void Awake()
    {
        ad = GetComponent<admanager>();
        DontDestroyOnLoad(transform.gameObject);
        if (FindObjectsOfType(GetType()).Length>1)
        {
            Destroy(gameObject);
        }
    }

    void Start ()
    {  
        levelnumber = PlayerPrefs.GetInt("level");

        
    }
	
	void Update ()
    {
        Scene scene = SceneManager.GetActiveScene();
        string currentscenename = scene.name;
        if (currentscenename == "PL")
        {
            if (player == null || spawner == null || camera == null || canvas == null)
            {
                FindObjects();
            }
        }
       
        if (UiManager.ispaused == false)
        {
            Time.timeScale += (1 / slowedtime) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }
	}

    void FindObjects()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        cm = camera.GetComponent<Camera>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        usrmng = canvas.GetComponent<UiManager>();
    }
   
    public void respawn()
    {
        if (!win.wonlevl)
        {

            //ad.ShowInterstitial();
            FindObjects();
            Spawn sp = spawner.GetComponent<Spawn>();
            sp.spawnagain();
            cm.retarget();

        }
    }
    

    public void levelwon()
    {
        levelnumber+=1;
        usrmng.WinGui();
        Time.timeScale = slowdownfactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        Invoke("nextscene",movetonextscenetime);
        
    }
    
    void nextscene()
    {   
        usrmng.nxtlvl();
        Time.timeScale = 1;
        /* if (levelnumber > PlayerPrefs.GetInt("level"))
         {*/
        int cur = PlayerPrefs.GetInt("level");
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
        //  }
        
            
    }

   
}
