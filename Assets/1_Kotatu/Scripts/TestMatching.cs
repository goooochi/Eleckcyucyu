using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Text;
using System.IO;

public class TestMatching : MonoBehaviour
{
    public Image searchImage;
    public Image templateImage;
    //public Button matchButton;
    public float threshold = 0.9f;

    private Texture2D searchTexture;
    private Texture2D templateTexture;

    private void Awake()
    {
        //Texture2D texture = new Texture2D(2, 2);
        //byte[] bytes = File.ReadAllBytes(filePath);
        //texture.LoadImage(bytes);
    }

    void Start()
    {
        // ボタンにクリックイベントを追加
        //matchButton.onClick.AddListener(MatchTemplate);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            MatchTemplate();
        }
    }

    void MatchTemplate()
    {
        // 検索画像のテクスチャを取得
        searchTexture = searchImage.mainTexture as Texture2D;
        if (searchTexture == null)
        {
            Debug.LogError("Search image is not set!");
            return;
        }

        // テンプレート画像のテクスチャを取得
        templateTexture = templateImage.mainTexture as Texture2D;
        if (templateTexture == null)
        {
            Debug.LogError("Template image is not set!");
            return;
        }


        Debug.Log(searchTexture);
        Debug.Log(templateTexture);

        // テンプレートマッチングを実行
        float similarity = PerformTemplateMatching(searchTexture, templateTexture);

        // 類似度をログに出力
        Debug.Log("Similarity: " + similarity);

        // 閾値を超える場合には、Success!というログを出力
        if (similarity > threshold)
        {
            Debug.Log("Success!");
        }

    }

    float PerformTemplateMatching(Texture2D searchTex, Texture2D templateTex)
    {
        // 検索画像とテンプレート画像のサイズを取得
        int searchWidth = searchTex.width;
        int searchHeight = searchTex.height;
        int templateWidth = templateTex.width;
        int templateHeight = templateTex.height;

        // 検索画像とテンプレート画像を2次元配列に変換
        Color32[] searchPixels = searchTex.GetPixels32();
        Color32[] templatePixels = templateTex.GetPixels32();
        Color32[,] searchArray = new Color32[searchHeight, searchWidth];
        Color32[,] templateArray = new Color32[templateHeight, templateWidth];
        for (int y = 0; y < searchHeight; y++)
        {
            for (int x = 0; x < searchWidth; x++)
            {
                searchArray[y, x] = searchPixels[y * searchWidth + x];
            }
        }
        for (int y = 0; y < templateHeight; y++)
        {
            for (int x = 0; x < templateWidth; x++)
            {
                templateArray[y, x] = templatePixels[y * templateWidth + x];
            }
        }

        // テンプレートマッチングアルゴリズムを実装する
        float maxSimilarity = 0.0f;
        for (int y = 0; y <= searchHeight - templateHeight; y++)
        {
            for (int x = 0; x <= searchWidth - templateWidth; x++)
            {
                float similarity = CalculateSimilarity(searchArray, templateArray, x, y, templateWidth, templateHeight);
                if (similarity > maxSimilarity)
                {
                    maxSimilarity = similarity;
                }
            }
        }

        return maxSimilarity;
    }

    float CalculateSimilarity(Color32[,] searchArray, Color32[,] templateArray, int startX, int startY, int templateWidth, int templateHeight)
    {
        float sum = 0.0f;
        for (int y = 0; y < templateHeight; y++)
        {
            for (int x = 0; x < templateWidth; x++)
            {
                Color32 searchPixel = searchArray[startY + y, startX + x];
                Color32 templatePixel = templateArray[y, x];
                float similarity = Mathf.Abs(searchPixel.r - templatePixel.r) + Mathf.Abs(searchPixel.g - templatePixel.g) + Mathf.Abs(searchPixel.b - templatePixel.b);
                sum += similarity;
            }
        }

        return sum / (templateWidth * templateHeight * 3);
    }

}




