using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MainCursolCanvas : MonoBehaviour
{
    static Canvas canvas;
    GameObject playerEye;
    Vector3 pos;
    public static bool cursolFlag;

    // Start is called before the first frame update
    void Start()
    {
        cursolFlag = false;
        canvas = GetComponent<Canvas>();
        playerEye = GameObject.Find ("VREye");
    }

    // Update is called once per frame
    void Update()
    {
        // pos = playerEye.transform.position;
        
        // if (pos.x > 63.0f) {
        //   SetActiveButtons();
        // }
        // else{
        //   SetUnactiveButtons();
        // }

        if(cursolFlag){
            setActive("Cursol", true);
            setActive("Image", true);
        }
        else{
            setActive("Cursol", false);
            setActive("Image", false);
        }
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
