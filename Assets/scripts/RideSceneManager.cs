using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RideSceneManager : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    void Update(){
        if ( Input.GetKeyDown ( KeyCode.Joystick2Button12 )){
             SceneManager.LoadScene("start");
        }
    }
}