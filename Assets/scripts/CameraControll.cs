using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    private GameObject mainCamera;      //メインカメラ格納用
    private GameObject subCamera;       //サブカメラ格納用 
    private GameObject gvr;       //GvrEditorEmulator格納用 
    private GameObject player;       //GvrEditorEmulator格納用 
    private GameObject playerCam; 
    public float yAngle;  //maincameraのsub=>mainに渡すRotation.y
    public float yAngle2; //playerのmain=>subに渡すRotation.y
    private bool cameraMode = true;  //最初はmaincamera


    void Start()
    {
        //メインカメラとサブカメラなどをそれぞれ取得
        mainCamera = GameObject.Find("Main Camera");
        subCamera = GameObject.Find("Sub Camera");
        gvr = GameObject.Find("GvrEditorEmulator");
        player = GameObject.Find("player");
        playerCam = GameObject.Find("Player Eye Camera");

        //サブカメラを非アクティブにする
        subCamera.SetActive(false);
    }


    void Update()
    {
        //andoid時のR-JoyconのYボタン　または　PCスペースでカメラ切り替え
        if (Input.GetKeyDown(KeyCode.Joystick2Button2) || Input.GetKeyDown(KeyCode.Space))
            cameraMode = !cameraMode;


        if (cameraMode == false)
        {
            //サブカメラをアクティブに設定
            mainCamera.SetActive(false);
            gvr.SetActive(false);
            subCamera.SetActive(true);
            player.SetActive(true);
            playerCam.SetActive(false);
        }
        else
        {
            //メインカメラをアクティブに設定
            subCamera.SetActive(false);
            player.SetActive(false);
            mainCamera.SetActive(true);
            gvr.SetActive(true);
            playerCam.SetActive(true);
        }
    }
}