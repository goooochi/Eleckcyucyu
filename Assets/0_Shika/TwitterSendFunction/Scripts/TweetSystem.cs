using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class TweetSystem : MonoBehaviour
{

    Texture2D screenShot;

    private string CLIENT_ID = "da9b2d80be33534";
    private string CLIENT_SECRET = "3f72ac28a827d4605976fc2a67a7f9a846484337";



    public void TweetButton()
    {
        StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot("ツイート本文をここに書く"));
    }

}
