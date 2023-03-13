using UnityEngine;
using System.Runtime.InteropServices;

public class TweetTest : MonoBehaviour
{
    #if UNITY_EDITOR && UNITY_WEBGL
        [DllImport("__Internal")]
        private static extern string TweetFromUnity(string rawMessage);
    #endif  

    public void Tweet()
    {
#if UNITY_EDITOR && UNITY_WEBGL
            TweetFromUnity("Tweet Message");
#endif
    }
}