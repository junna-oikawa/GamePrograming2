using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeButton : MonoBehaviour
{
    GameObject sceneManager;

    void Start(){
        gameObject.SetActive(false);
        sceneManager = GameObject.Find("SceneManager");
    }

    void Update(){
      if( (SceneChangePlane.flag == true && Input.GetKey(KeyCode.Joystick2Button0) ) 
      || (SceneChangePlane.flag == true && Input.GetKey (KeyCode.Return))){
        OnClick();
        //SceneChangePlane.flag = false;
      }
    }

    public void OnClick() {
    sceneManager.GetComponent<MainSceneManager>().ChangeScene();
  }

}
