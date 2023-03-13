using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OpenCvSharp.Demo;
using OpenCvSharp;
using OpenCvSharp.Aruco;

public class Test : MonoBehaviour
{
    public Texture2D texture;

    void Start()
    {
        // 画像読み込み
        Mat mat = OpenCvSharp.Unity.TextureToMat(this.texture);

        // 画像書き出し
        Texture2D outTexture = new Texture2D(mat.Width, mat.Height, TextureFormat.ARGB32, false);
        OpenCvSharp.Unity.MatToTexture(mat, outTexture);

        // 表示
        GetComponent<RawImage>().texture = outTexture;
    }
}
