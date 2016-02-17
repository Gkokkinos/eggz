//facebook login and app invite...work in progress

using UnityEngine;
using System.Collections;
using Facebook.Unity;
using System.Collections.Generic;

public class facebookInit : MonoBehaviour {

	public string toId;
	private int scores;
   
    void Awake()
    {
        FB.Init(SetInit, OnHideUnity);
    }

    void SetInit()
    {
        if (FB.IsLoggedIn)
        {
            Debug.Log("FB is logged in");
        }
        else {
            Debug.Log("FB is not logged in");
        }
    }

    void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
    }

    public void FBlogin()
    {
        List<string> permissions = new List<string>();
        permissions.Add("public_profile");

        FB.LogInWithReadPermissions(permissions, AuthCallBack);
    }

    void AuthCallBack(IResult result)
    {

        if (result.Error != null)
        {
            Debug.Log(result.Error);
        }
        else {
            if (FB.IsLoggedIn)
            {
                Debug.Log("FB is logged in");
            }
            else {
                Debug.Log("FB is not logged in");
            }
        }

    }

    public void FBshare(){
		FB.ShareLink(
			//string.Empty, //toId
			new System.Uri("https://play.google.com/store/apps/details?id=com.George.Kokkinos"), 
			//"LinkCaption"
			scores.ToString(),
			"My highest score in eggs", //linkDescription
			new System.Uri("http://i.imgur.com/I3X1fMB.png"), //picture
			FeedCallback //callback
			);
	}

	void FeedCallback(IShareResult result){
		Debug.Log("Worked");
	}

	public void FBAppInv(){
		FB.AppRequest(
			"Beat me! My new best score is: " + scores.ToString(),
			null, null, null, null, null, null,
			delegate (IAppRequestResult result) {
			Debug.Log(result.RawResult);
		}
		);

	}
