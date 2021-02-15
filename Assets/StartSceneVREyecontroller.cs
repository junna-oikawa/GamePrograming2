using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneVREyecontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = new Vector3(30.5f, 10.0f + sin * 10, -15.5f);
        Transform myTransform = this.transform;

        Vector3 pos = myTransform.position;
        pos.x += 0.01f;    // x座標へ0.01加算
        myTransform.position = pos;  // 座標を設定
    }
}
