using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour
{
    [SerializeField] private string androidAdUnitId = "Banner_Android";
    [SerializeField] private string iOSAdUnitId = "Banner_iOS";
    string _adUnitId = null;

    [SerializeField] BannerPosition bannerPosition = BannerPosition.BOTTOM_CENTER;

    private void Start()
    {
#if UNITY_IOS
        _adUnitId = iOSAdUnitId
#elif UNITY_ANDROID
        _adUnitId = androidAdUnitId;
#endif

        LoadBannerAd();
    }


    public void LoadBannerAd()
    {
        if(Advertisement.isInitialized)
        {
            Advertisement.Banner.SetPosition(bannerPosition);
            BannerLoadOptions options = new BannerLoadOptions()
            {
                loadCallback = OnBannerLoad,
                errorCallback = OnBannerError
            };
            Advertisement.Banner.Load(_adUnitId, options);
        }
    }

    private void OnBannerError(string message)
    {
        Debug.Log("Banner Error");
    }

    private void OnBannerLoad()
    {
        Advertisement.Banner.Show(_adUnitId);
    }
}
