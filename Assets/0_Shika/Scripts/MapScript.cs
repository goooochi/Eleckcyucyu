using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject mapCamera;
    private bool mapMode;

    void Start()
    {
        // サブカメラはデフォルトで無効にしておく
        mapCamera.SetActive(false);
        mapMode = false;
    }

    void Update()
    {
        MapModeChange();
    }

    void MapModeChange()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            // 各カメラオブジェクトの有効フラグを逆転(true→false,false→true)させる
            mapMode = !mapMode;
            mainCamera.SetActive(!mainCamera.activeSelf);
            mapCamera.SetActive(!mapCamera.activeSelf);
        }
    }
}