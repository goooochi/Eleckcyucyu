using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject mapCamera;

    void Start()
    {
        // サブカメラはデフォルトで無効にしておく
        mapCamera.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            // 各カメラオブジェクトの有効フラグを逆転(true→false,false→true)させる
            mainCamera.SetActive(!mainCamera.activeSelf);
            mapCamera.SetActive(!mapCamera.activeSelf);
        }
    }
}