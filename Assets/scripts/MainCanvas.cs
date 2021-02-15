using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class MainCanvas : MonoBehaviour {
  static Canvas canvas;
    GameObject playerEye;
    Vector3 pos;

  void Start () {
    canvas = GetComponent<Canvas>();
    playerEye = GameObject.Find ("VREye");

  }

    void Update(){
        pos = playerEye.transform.position;
        
        if (pos.x > 63.0f) {
          SetActiveButtons();
          //MainCursolCanvas.cursolFlag = true;
          ButtonPlane.planeFlag = true;
        }
        else{
          SetUnactiveButtons();
          ButtonPlane.planeFlag = false;
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