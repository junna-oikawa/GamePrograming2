using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangePlane : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject scp;
    public static bool flag;
    void Start()
    {
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnEnterPointer()
    {
        flag = true;　//カウントがtrueに
        Debug.Log("TRUE");
    }

    //視点がオブジェクトから外れたら
    public void OnExitPonter()
    {
        flag = false;//カウントがfalseにtimeが0に
        Debug.Log("FALSE");
    }
}
