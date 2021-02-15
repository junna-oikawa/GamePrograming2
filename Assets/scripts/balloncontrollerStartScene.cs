using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloncontrollerStartScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float sin = Mathf.Sin(Time.time / 2);
        this.transform.position = new Vector3(30.5f, 10.0f + sin * 10, -15.5f);
    }
}
