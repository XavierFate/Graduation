using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour
{
    [SerializeField] BannerPosition bannerPosition;

    [SerializeField] string androidAdId = "Banner_Android";
    [SerializeField] string iOSAdId = "Banner_iOS";
    private string adID;

    private void Awake()
    {
        adID = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? iOSAdId
            : androidAdId;
    }

    private void Start()
    {
        Advertisement.Banner.SetPosition(bannerPosition);
        StartCoroutine(LoadAdBanner());
    }

    public void LoadBanner()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        Advertisement.Banner.Load(adID, options);
    }

    private void OnBannerLoaded()
    {
        ShowBannerAd();
    }

    private void OnBannerError(string message)
    {
        Debug.Log($"BannerError: {message}");
    }

    public void ShowBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            showCallback = OnBannerShown,
            hideCallback = OnBannerHidden,
        };
        Advertisement.Banner.Show(adID, options);
    }

    private void OnBannerHidden() { }
    private void OnBannerShown() { }
    private void OnBannerClicked() { }

    private IEnumerator LoadAdBanner()
    {
        yield return new WaitForSeconds(1f);
        LoadBanner();
    }
}

