using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RejectButton : MonoBehaviour
{
    GameObject sceneManager;
    GameObject eye;
    GameObject sceneChangeButton;
    void Start(){
        gameObject.SetActive(false);
        sceneManager = GameObject.Find("SceneManager");
        eye = GameObject.Find("VREye");
    }

    void Update(){
      if((RejectPlane.flag == true && Input.GetKey ( KeyCode.Joystick2Button0 ) )
      || (RejectPlane.flag == true && Input.GetKey (KeyCode.Return))){
        OnClick();
      }
    }

    public void OnClick() {
        sceneChangeButton = GameObject.Find("SceneChangeButton");
        Vector3 pos = eye.transform.position;
        pos.x = 66.5f;
        eye.transform.position = pos;
        eye.transform.rotation = eye.transform.rotation * Quaternion.Euler(0f, 180f, 0f);

        gameObject.SetActive(false);
        sceneChangeButton.SetActive(false);
    }
}
