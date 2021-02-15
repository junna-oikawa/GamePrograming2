using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCameracontroller : MonoBehaviour
{
    GameObject player;
    GameObject cameraController;
    GameObject mainCamera;
    GameObject playerCamera;
    GameObject camBox;
    GameObject VREye;
    CameraControll script;

   
    // Start is called before the first frame update
    void Start()
    {
        VREye = GameObject.Find("VREye");
        player = GameObject.Find("player");
        camBox = VREye.transform.Find("CamBox").gameObject;
        mainCamera = camBox.transform.Find("Main Camera").gameObject;
        playerCamera = camBox.transform.Find("Player Eye Camera").gameObject;
        //subCamera = VREye.transform.Find("Sub Camera").gameObject;
        script = GameObject.Find("CameraController").GetComponent<CameraControll>();
        //camTransform = camBox.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable() //cameraオンの時にcamboxにplayerの向きを代入
    {
        // transformを取得
        Transform camTransform = camBox.transform;
        // ワールド座標を基準に、回転を取得
        Vector3 worldAngle = camTransform.eulerAngles;
        //rotaition.yをプレイヤーキャラの体の向き合わせる
        worldAngle.y = script.yAngle2;
        camTransform.eulerAngles = worldAngle;
    }

    void OnDisable() //カメラオフの時にmaincameraの角度をplayerキャラに送る
    {
        Vector3 worldAngle = camBox.transform.eulerAngles;
        float world_angle_y = worldAngle.y;
        //カメラの角度をplayerキャラに送る
        script.yAngle = world_angle_y;
        
    }
}
