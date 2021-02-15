using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RejectButton_Ride : MonoBehaviour
{
    GameObject sceneManager;
    GameObject balloon;
    GameObject sceneChangeButton;
    bool cursolFlag;
    void Start(){
        gameObject.SetActive(false);
        sceneManager = GameObject.Find("SceneManager");
        balloon = GameObject.Find("ride_balloon");
    }

    void Update(){
      if(( cursolFlag == true && Input.GetKey ( KeyCode.Joystick2Button0 ) )
      || (cursolFlag == true && Input.GetKey (KeyCode.Return))){
        OnClick();
      }
    }

    public void OnClick() {
        sceneChangeButton = GameObject.Find("SceneChangeButton");
        gameObject.SetActive(false);
        sceneChangeButton.SetActive(false);
        
        Vector3 pos = balloon.transform.position;
        pos.y = -6.9f;
        balloon.transform.position = pos;

        balloon.GetComponent<balloonController>().flag = 1;
    }
    public void Enter(){
      cursolFlag = true;

    }
    public void Exit(){
      cursolFlag = false;

    }
}
