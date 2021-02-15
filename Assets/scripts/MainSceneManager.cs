using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("RideScene");
    }

    void Update(){
        if ( Input.GetKeyDown ( KeyCode.Joystick2Button12 )){
             SceneManager.LoadScene("start");
        }
    }
}