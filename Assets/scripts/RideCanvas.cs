using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RideCanvas : MonoBehaviour
{
    static Canvas canvas;
    GameObject balloon;
    Vector3 pos;

  void Start () {
    canvas = GetComponent<Canvas>();
    balloon = GameObject.Find ("ride_balloon");
  }

    void Update(){
        pos = balloon.transform.position;
        if (pos.y <= -7.0f){
            SetActiveButtons();
            
        }
        else{
           SetUnactiveButtons();

        }
    }

    void SetActiveButtons(){
      setActive("SceneChangeButton", true);
      setActive("RejectButton", true);
    }
    void SetUnactiveButtons(){
      setActive("SceneChangeButton", false);
      setActive("RejectButton", false);
    }

  public static void setActive(string name, bool b) {
    GameObject[] childGameObjects = canvas.GetComponentsInChildren<Transform>().Select(t => t.gameObject).ToArray();
    foreach(Transform child in canvas.transform) {
      if(child.name == name) {
        child.gameObject.SetActive(b);
        return;
      }
    }
    Debug.LogWarning("Not found objname:"+name);
  }
}
