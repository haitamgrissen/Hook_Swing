using UnityEngine;
// using GoogleMobileAds.Api;
// using UnityEngine.Advertisements;

public class admanager : MonoBehaviour
{

//     [SerializeField] string ApplicationId;
//     [SerializeField] string BannerId;
//     [SerializeField] string IntId;
//     [SerializeField] float timebetweeninterstitial;
//     float timebetween;
   
//     string appid;
   

//     private BannerView bannerView;
//     private InterstitialAd interstitial;
//     private float deltaTime = 0.0f;
//     private static string outputMessage = string.Empty;

//     public static string OutputMessage
//     {
//         set { outputMessage = value; }
//     }
//     void Start()
//     { 
//         initialize();
//         timebetween = timebetweeninterstitial;
//        // timebetween = timebetweeninterstitial;
//         Advertisement.Initialize(appid);
//         RequestInterstitial();
//         ShowBanner();
//     }

//     private void Update()
//     {
//         deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
//         if (timebetween >= 0 )
//         {
//             timebetween -= Time.deltaTime;
//         }
        
//     }


//     private AdRequest CreateAdRequest()
//     {
//         return new AdRequest.Builder()
//         .TagForChildDirectedTreatment(false)
//         .Build();
//         // .AddTestDevice(AdRequest.TestDeviceSimulator)
//         // .AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
//         //.AddKeyword("game")
//         //.SetGender(Gender.Male)
//         //.SetBirthday(new DateTime(1985, 1, 1))
//         //.TagForChildDirectedTreatment(false)
//         //.AddExtra("color_bg", "9B30FF")
//         //.Build();
//     }

//     void initialize()
// {
    
// #if UNITY_ANDROID
//         string appId = ApplicationId;
// #elif UNITY_IPHONE
//         string appId = "ca-app-pub-3940256099942544~1458002511";
// #else
//         string appId = "unexpected_platform";
// #endif

//         MobileAds.SetiOSAppPauseOnBackground(true);

//         // Initialize the Google Mobile Ads SDK.
//         MobileAds.Initialize(appId);
//     }

//     void ShowBanner()
//     {
//         // These ad units are configured to always serve test ads.
// /*#if   UNITY_EDITOR
//         string adUnitId = "unused";*/
// #if UNITY_ANDROID
//         string adUnitId = BannerId;
// #elif UNITY_IPHONE
//         string adUnitId = "ca-app-pub-3940256099942544/2934735716";
// #else
//         string adUnitId = "unexpected_platform";
// #endif

//         // Clean up banner ad before creating a new one.
//         if (bannerView != null)
//         {
//             bannerView.Destroy();
//         }

//         // Create a 320x50 banner at the top of the screen.
//         bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);

      

//         // Load a banner ad.
//         bannerView.LoadAd(CreateAdRequest());
//     }

//     public void ShowInterstitial()
//     {

//         if (interstitial.IsLoaded() && timebetween <= 0)
//         {
//             interstitial.Show();
//             timebetween = timebetweeninterstitial;
//             Invoke("destroyint", 30);
           
//         }
//     }

//     private void RequestInterstitial()
//     {
//         // These ad units are configured to always serve test ads.
// /*#if UNITY_EDITOR
//         string adUnitId = "unused";*/
// #if UNITY_ANDROID
//         string adUnitId = IntId;
// #elif UNITY_IPHONE
//         string adUnitId = "ca-app-pub-3940256099942544/4411468910";
// #else
//         string adUnitId = "unexpected_platform";
// #endif

//         // Clean up interstitial ad before creating a new one.
//         if (interstitial != null)
//         {
//             interstitial.Destroy();
//         }

//         // Create an interstitial.
//         interstitial = new InterstitialAd(adUnitId);

//         // Load an interstitial ad.
//         interstitial.LoadAd(this.CreateAdRequest());
//     }
//     void destroyint() {
//         interstitial.Destroy();
//         RequestInterstitial();
//     }
}
