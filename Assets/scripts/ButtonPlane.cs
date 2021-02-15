using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ButtonPlane : MonoBehaviour
{
    public static bool planeFlag;
    static GameObject buttonPlane;
    void Start(){
        buttonPlane = GameObject.Find("ButtonPlane");
        
    }
    void Update()
    {
        if(planeFlag){
            setActive("SceneChangePlane",true);
            setActive("RejectPlane",true);
        }
        else{
            setActive("SceneChangePlane",false);
            setActive("RejectPlane",false);
        }
    }

    public static void setActive(string name, bool b) {
    GameObject[] childGameObjects = buttonPlane.GetComponentsInChildren<Transform>().Select(t => t.gameObject).ToArray();
    foreach(Transform child in buttonPlane.transform) {
      if(child.name == name) {
        child.gameObject.SetActive(b);
        return;
      }
    }
    Debug.LogWarning("Not found objname:"+name);
  }
}
