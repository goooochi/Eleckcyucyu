using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModeScript : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject mapCamera;
    public GameObject pictureCamera;
    public GameObject Player;
    public TakePicture takePicture;
    public TimeManager timeManager;

    //public GameObject canvas;
    private bool mapMode;
    private bool pictureMode;

    void Start()
    {
        // サブカメラはデフォルトで無効にしておく
        mapCamera.SetActive(false);
        pictureCamera.SetActive(false);

        mapMode = false;
        pictureMode = false;
    }

    void Update()
    {
        if (mapMode)
        {
            pictureMode = false;
        }
        else
        {
            PictureModeCameraChange();
        }

        if (pictureMode)
        {
            mapMode = false;
            //pictureModeCameraSettings();

            if (Input.GetKeyDown(KeyCode.X))
            {
                takePicture.OnClick();
                timeManager.ChangePictureBool();

                mapMode = !mapMode;
                mainCamera.SetActive(!mainCamera.activeSelf);
                mapCamera.SetActive(!mapCamera.activeSelf);

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                pictureModeCameraSettings();
            }
        }
        else
        {
            MapModeCameraChange();
        }
    }

    void MapModeCameraChange()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            // 各カメラオブジェクトの有効フラグを逆転(true→false,false→true)させる
            
            mapMode = !mapMode;
            mainCamera.SetActive(!mainCamera.activeSelf);
            mapCamera.SetActive(!mapCamera.activeSelf);
            takePicture.PictureModeUIChange();
        }
    }

    void PictureModeCameraChange()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // 各カメラオブジェクトの有効フラグを逆転(true→false,false→true)させる                     
            pictureMode = !pictureMode;
            mainCamera.SetActive(!mainCamera.activeSelf);
            pictureCamera.SetActive(!pictureCamera.activeSelf);
            takePicture.PictureModeUIChange();
        }
    }

    void pictureModeCameraSettings()
    {
        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        float rotateSpeed = 2.0f;
        
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);

        Player.transform.RotateAround(Player.transform.position, new Vector3(0, 1, 0), angle.x);

        pictureCamera.transform.RotateAround(pictureCamera.transform.position, Player.transform.right, -angle.y);

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Cursor.visible = true;
        //    Cursor.lockState = CursorLockMode.None;
        //}
    }
}