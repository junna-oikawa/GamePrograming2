using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeButton_Ride : MonoBehaviour
{
    GameObject sceneManager;
    GameObject eye;
    bool cursolFlag;
    void Start(){
        gameObject.SetActive(false);
        sceneManager = GameObject.Find("SceneManager");
    }

    void Update(){
  
      if( (cursolFlag ==true && Input.GetKey(KeyCode.Joystick2Button0) ) 
      || (cursolFlag ==true && Input.GetKey (KeyCode.Return))){
        
        OnClick();
      }
    }

    public void OnClick() {
    sceneManager.GetComponent<RideSceneManager>().ChangeScene();
    controller.ride_flag = true;

    // eye = GameObject.Find("VREye");
    // Vector3 pos = eye.transform.position;
    // pos.x = 20.5f;
    // eye.transform.position = pos;
  

  }
  public void Enter(){
      cursolFlag = true;

    }
    public void Exit(){
      cursolFlag = false;

    }
}
