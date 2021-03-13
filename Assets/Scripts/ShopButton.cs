using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.Advertisements;

public class ShopButton : MonoBehaviour
{
    [SerializeField] bool maincharacter;
    [SerializeField] int index;
    [SerializeField] GameObject locksprite;
    [SerializeField] GameObject selectyedsprite;
    int characteravailability;

    private void Start()
    {
        characteravailability = PlayerPrefs.GetInt("purchesed");
        
            if ((characteravailability & 1 << index) == 1 << index)
            {
                locksprite.SetActive(false);
            }
        
    }
    private void Update()
    {
        
            if (index == PlayerPrefs.GetInt("selectedcharacter"))
            {
                selectyedsprite.SetActive(true);
            }
            else
            {
                selectyedsprite.SetActive(false);
            }
        
    }
    public void SelectedPlayer()
    {
        if ((characteravailability & 1 << index) == 1 << index || maincharacter)
        {
            if (index == PlayerPrefs.GetInt("selectedcharacter"))
            {
                SceneManager.LoadScene("PL");
            }
            else
            {
                PlayerPrefs.SetInt("selectedcharacter", index);
                Debug.Log(PlayerPrefs.GetInt("selectedcharacter"));
                
            }

        }
        else
        {

            if (true) //Advertisement.IsReady("rewardedVideo"))
            {
                //var options = new ShowOptions { resultCallback = HandleShowResult };
                //Advertisement.Show("rewardedVideo", options);      
            }
            else
            {
                //try later pop up screen
            }
        }
    }
    private void HandleShowResult()//ShowResult result)
    {
        // switch (result)
        // {
        //     case ShowResult.Finished:
        //         Debug.Log("The ad was successfully shown.");
        //         characteravailability += 1 << index;
        //         PlayerPrefs.SetInt("purchesed", characteravailability);
        //         PlayerPrefs.SetInt("selectedcharacter", index);
        //         locksprite.SetActive(false);
        //         break;
        //     case ShowResult.Skipped:
        //         Debug.Log("The ad was skipped before reaching the end.");
        //         break;
        //     case ShowResult.Failed:
        //         Debug.LogError("The ad failed to be shown.");
        //         break;
        // }
    }
}
