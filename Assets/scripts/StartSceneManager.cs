using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick2Button0)){
            ChangeScene();
        }
        
    }
    public void ChangeScene()
    {   
        SceneManager.LoadScene("MainScene");
    }
}
