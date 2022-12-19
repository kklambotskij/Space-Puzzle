using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] WinScreen winScreen;
    [SerializeField] Shop shop;
    public static Ads Instance { get; private set; } // static singleton
    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    string gameId = "4263027";
    bool testMode = false;
    public static bool Reklama = true;

    public string bannerID = "Banner_Android";
    public string rewardedID = "Rewarded_Android";
    public string videoID = "Interstitial_Android";

    [SerializeField] private string type;

    public void ShowVideo()
    {
        if (Reklama && Advertisement.IsReady(videoID))
        {
            Advertisement.Show(videoID);
        }
    }

    public void ShowRewardedVideo(string type)
    {
        this.type = type;
        if (Reklama && Advertisement.IsReady(rewardedID))
        {
            Advertisement.Show(rewardedID);
        }
    }

    void Start()
    {
        if (!Advertisement.isSupported) return;
        try
        {
            Advertisement.Initialize(gameId, testMode);
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
            throw;
        }
        
    }

    public void StopReklama()
    {
        StopCoroutine(ShowBannerWhenReady());
        Advertisement.Banner.Hide(true);
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(bannerID))
        {
            yield return new WaitForSeconds(1);
        }
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(bannerID);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == rewardedID && showResult == ShowResult.Finished)
        {
            if (type == "X3")
            {
                winScreen.RewardedVideoFinished();
            }
            if (type == "ShopAds")
            {
                shop.AdReward();
            }
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new System.NotImplementedException();
    }
}