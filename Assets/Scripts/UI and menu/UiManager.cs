using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;


public class UiManager : MonoBehaviour {


    public static bool ispaused;
    //private bool ismuted=false;
    //private float volume;
    [Header("menus")]
    public GameObject pausemenu;
    public GameObject nextlevel;
    public GameObject mainmenu;
    public GameObject gui;
    public GameObject winningui;
    //public AudioMixer audiomixer;
    GameObject gamemanager;
    admanager ad;
    [Header("slider")]
    [SerializeField]
    Slider slider;
    GameObject finishline;
    Scene activescene;
    string activescenename;
    GameObject player;
    float max = 0;

    [Header("texts")]
    public Text Nxtlvltxt;
    public Text GuiLvl;
    public Text plyrprf;



    private void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager");
        ad = gamemanager.GetComponent<admanager>();
        activescene = SceneManager.GetActiveScene();
        activescenename = activescene.name;
        if (activescenename == "PL")
        {
            finishline = GameObject.FindGameObjectWithTag("Finish");
            slider.maxValue = finishline.transform.position.x;
            slider.minValue = 0;
        }
        
    }

    private void Update()
    {
        if (activescenename == "PL")
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }
            else
            {
                
                if (player.transform.position.x > max)
                {
                    slider.value = player.transform.position.x;
                    max = player.transform.position.x;
                }
            }
            
        }
        int curlvl = PlayerPrefs.GetInt("level") + 1;
        plyrprf.text = PlayerPrefs.GetInt("level").ToString();
        GuiLvl.text = curlvl.ToString();

        Nxtlvltxt.text = curlvl.ToString();
        
    }

    public void resume()
    {
        pausemenu.SetActive(false);
        nextlevel.SetActive(false);
        mainmenu.SetActive(false);
        gui.SetActive(true);
        winningui.SetActive(false);

        ispaused = false;
        Time.timeScale = 1f;
    }

    public void pause()
    {
        pausemenu.SetActive(true);
        nextlevel.SetActive(false);
        mainmenu.SetActive(false);
        gui.SetActive(false);
        winningui.SetActive(false);
        ispaused = true;

        Time.timeScale = 0f;
    }

    public void Home()
    {
        pausemenu.SetActive(false);
        nextlevel.SetActive(false);
        mainmenu.SetActive(true);
        gui.SetActive(false);
        winningui.SetActive(false);
        SceneManager.LoadScene("MM");
        Time.timeScale = 1f;
        //ad.ShowInterstitial();
    }

    public void satrtpaly()
    {
        
        pausemenu.SetActive(false);
        nextlevel.SetActive(false);
        mainmenu.SetActive(false);
        gui.SetActive(true);
        winningui.SetActive(false);
        SceneManager.LoadScene("PL");
        Time.timeScale = 1f;
        //ad.RequestBanner();
        //ad.RequestInterstitial();
    }

    public void WinGui()
    {
        //ad.destroybanner();
        pausemenu.SetActive(false);
        nextlevel.SetActive(false);
        mainmenu.SetActive(false);
        gui.SetActive(false);
        winningui.SetActive(true);
    }

    public void nxtlvl()
    {   
        pausemenu.SetActive(false);
        nextlevel.SetActive(true);
        mainmenu.SetActive(false);
        gui.SetActive(false);
        winningui.SetActive(false);
        SceneManager.LoadScene("NL");
        //ad.RequestBanner();
        //ad.ShowInterstitial();
    }
    public void openshop()
    {
        pausemenu.SetActive(false);
        nextlevel.SetActive(false);
        mainmenu.SetActive(false);
        gui.SetActive(false);
        winningui.SetActive(false);
        SceneManager.LoadScene("SHOP");
        
    }

    #region//testing

    public void rest()
    {
        PlayerPrefs.DeleteAll();
    }

    public void add()
    {
        int cur = PlayerPrefs.GetInt("level");
        PlayerPrefs.SetInt("level", cur + 1);
    }
    #endregion

    /* public void AudioManagement()
     {
         Debug.Log("volume =");
         /*if (ismuted)
         {
             volume = 0;
             audiomixer.SetFloat("Volume", volume);
             ismuted = false;
             Debug.Log(volume);
         }
         else
         {
             volume = -80;
             audiomixer.SetFloat("Volume", volume);
             ismuted = true;
             Debug.Log(volume);
         }
     }*/
}
