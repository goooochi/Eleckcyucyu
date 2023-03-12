using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class InstantiateTemplatePicture : MonoBehaviour
{

    //[SerializeField] GameObject Player;

    //public string folderPath = "Assets/2_Frank/Images";

    ////[Header("保存先の設定")]
    ////[SerializeField]
    ////public static　string savePath = "Assets/2_Frank/Images/";

    //// Start is called before the first frame update
    //void Start()
    //{

    //    GetTemplatePicture();
    //}

    //public int GetRandomNumber()
    //{
    //    throw new System.NotImplementedException();
    //}

    //public void GetTemplatePicture()
    //{
    //    GameObject gameObject = Instantiate(Player, new Vector3((float)Random.Range(-10, 10), 0f, (float)Random.Range(-10, 10)), Quaternion.Euler(-30, Random.Range(0, 360), 0)) as GameObject;

    //    //生成されたオブジェクトの第一子供にアクセスする
    //    gameObject.transform.GetChild(0).gameObject.SetActive(true);

    //    //GameViewを切り取って、写真を保存する
    //    CaptureScreenshot();
    //}

    ///// <summary>
    ///// キャプチャを撮る
    ///// </summary>
    ///// <remarks>
    ///// Edit > CaptureScreenshot に追加。
    ///// HotKeyは Ctrl + Shift + F12。
    ///// </remarks>
    //private void CaptureScreenshot()
    //{
    //    string fileName = "Screenshot_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
    //    string path = Path.Combine(Application.dataPath, "2_Frank", "Images", fileName);
    //    ScreenCapture.CaptureScreenshot(path);
    //    Debug.Log("Screenshot saved at " + path);

    //    Player.gameObject.SetActive(false);
    //}

    //public void GetFileName()
    //{
    //    string[] fileNames = Directory.GetFiles(folderPath);
    //    foreach (string fileName in fileNames)
    //    {
    //        Debug.Log(Path.GetFileName(fileName));
    //    }
    //}

    public Image screenshotImage;

    private string screenshotPath;

    void Start()
    {
        screenshotPath = Path.Combine(Application.persistentDataPath, "Screenshot.png");
    }

    public void CaptureScreenshot()
    {
        StartCoroutine(TakeScreenshot());
    }

    private IEnumerator TakeScreenshot()
    {
        // Wait for end of frame to avoid capturing GUI overlay
        yield return new WaitForEndOfFrame();

        // Take screenshot and save to file
        ScreenCapture.CaptureScreenshot("Screenshot.png");
        yield return new WaitForSeconds(1f); // Wait for Unity to process screenshot
        byte[] data = File.ReadAllBytes(screenshotPath);

        // Save screenshot to file
        string path = Path.Combine(Application.persistentDataPath, "Screenshot.png");
        File.WriteAllBytes(path, data);

        // Refresh the asset database to immediately show the screenshot in the editor
#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }

    public void ShowLatestScreenshot()
    {
        if (!File.Exists(screenshotPath))
        {
            Debug.LogError("Screenshot not found!");
            return;
        }
        byte[] data = File.ReadAllBytes(screenshotPath);

        Texture2D screenshotTexture = new Texture2D(2, 2);
        screenshotTexture.LoadImage(data);
        screenshotImage.sprite = Sprite.Create(screenshotTexture, new Rect(0, 0, screenshotTexture.width, screenshotTexture.height), Vector2.zero);
    }

}


interface FunctionOfInstantiarte
{
    //ランダムな数字を返してくれるfunction
    int GetRandomNumber();

    void GetTemplatePicture();
}