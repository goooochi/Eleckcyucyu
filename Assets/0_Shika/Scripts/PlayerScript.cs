using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject subCamera;
    void Start()
    {
        // サブカメラはデフォルトで無効にしておく
        subCamera.SetActive(false);
    }

    void Update()
    {
        // もしSpaceキーが押されたならば、
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 各カメラオブジェクトの有効フラグを逆転(true→false,false→true)させる
            mainCamera.SetActive(!mainCamera.activeSelf);
            subCamera.SetActive(!subCamera.activeSelf);
        }
    }
}
