using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gvrcameracontroller : MonoBehaviour
{
    Vector3 basePos = Vector3.zero;
    GameObject vreye;
    Vector3 trf = new Vector3();
    Vector3 starttrf = new Vector3();
    Vector3 startPos = new Vector3();
   void Start()
   {
       basePos = transform.position;
       vreye = GameObject.Find("VREye");
       starttrf = vreye.transform.position;
   }

   void Update()
   {
    //    trf = vreye.transform.position;
    //    // VR.InputTracking から hmd の位置を取得
    //    var trackingPos = UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye);

    //    var scale = transform.localScale;
    //    trackingPos = new Vector3(
    //        trackingPos.x * scale.x,
    //        trackingPos.y * scale.y,
    //        trackingPos.z * scale.z
    //    );

    //    // 回転
    //    trackingPos = transform.rotation * trackingPos;

    //    // 固定したい位置から hmd の位置を
    //    // 差し引いて実質 hmd の移動を無効化する
    //    startPos = basePos - trackingPos;
    //    //Debug.Log(trf);
    //    transform.position = startPos + trf - starttrf;

       // 子のカメラの座標がbasePosと同じ値になるかを確認する
       // Debug.Log(transform.GetChild(0).position);
   }
}
