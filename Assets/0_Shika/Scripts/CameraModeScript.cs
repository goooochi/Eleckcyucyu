using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModeScript : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject mapCamera;
    //public GameObject pictureCamera;

    //public GameObject canvas;
    private bool mapMode;
    private bool pictureMode;

    //public GameObject PlayerCharacterModel;

    void Start()
    {
        // サブカメラはデフォルトで無効にしておく
        mapCamera.SetActive(false);
        //pictureCamera.SetActive(false);

        mapMode = false;
        pictureMode = false;

        //PlayerCharacterModel.SetActive(false);
    }

    void Update()
    {
        if (mapMode)
        {
            pictureMode = false;
        }
        if (pictureMode)
        {
            mapMode = false;
        }
        MapModeChange();
        PictureModeChange();
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

    void PictureModeChange()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // 各カメラオブジェクトの有効フラグを逆転(true→false,false→true)させる
            pictureMode = !pictureMode;
            mainCamera.SetActive(!mainCamera.activeSelf);
            //pictureCamera.SetActive(!pictureCamera.activeSelf);
        }
    }

    //public void CharacterModelSet()
    //{
    //    PlayerCharacterModel.SetActive(true);
    //}
}