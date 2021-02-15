using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class controller : MonoBehaviour
{
    
    private Vector3 direction;
    GameObject mainCamera;
    GameObject subCamera;
    GameObject camBox;
    GameObject VREye;
    bool flag;

    public static bool ride_flag = false;
    public AudioSource audioSource;
    void Start()
    {
        VREye = GameObject.Find ("VREye");
        mainCamera = GameObject.Find ("Main Camera");
        subCamera = VREye.transform.Find("Sub Camera").gameObject;
        camBox = GameObject.Find("CamBox");
        
        audioSource = GetComponent<AudioSource>();

        if(ride_flag){
            Vector3 pos = transform.position;
            pos.x = 66.0f;
            transform.position = pos;
            transform.rotation = transform.rotation * Quaternion.Euler(0f, 180f, 0f);
        }

    }

    // Update is called once per frame
    void Update()
    {

        var speed = 0.1f;
        float h1 = Input.GetAxis( "Horizontal 1");
        float v1 = Input.GetAxis( "Vertical 1" );

        float h2 = Input.GetAxis( "Horizontal 2" );
        float v2 = Input.GetAxis( "Vertical 2" );


        Move(v2);

        var rightleft = 0;
        var updown = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
            rightleft = -1;
        if (Input.GetKey(KeyCode.RightArrow))
            rightleft = 1;
        if (Input.GetKey(KeyCode.UpArrow))
            updown = 1;
        if (Input.GetKey(KeyCode.DownArrow))
            updown = -1;

        

        if ((mainCamera.activeInHierarchy && Input.GetKeyDown(KeyCode.UpArrow)) || (mainCamera.activeInHierarchy && (v2 > 0f) && flag == false))
            audioSource.Play();
        if ((mainCamera.activeInHierarchy && Input.GetKeyUp(KeyCode.UpArrow)) || (mainCamera.activeInHierarchy && (v2 <= 0f) && flag == true))
            audioSource.Stop();

            
        if(v2 > 0f){
            flag = true;
        }
        else{
            flag = false;
        }


        if (subCamera.activeInHierarchy)
        {
            Vector3 pos = transform.position;
            pos.x += (v2 + updown) * 0.15f;
            pos.z -= (h2 + rightleft) * 0.15f;
            transform.position = pos;
            transform.rotation = Quaternion .Euler(0.0f, 90.0f, 0f);
        }

    }

    public virtual void Move(float stick){
        if ( (mainCamera.activeInHierarchy && Input.GetKey(KeyCode.G)) || (mainCamera.activeInHierarchy && stick > 0f))
        {
            
            //transform.localPosition = transform.localPosition + camera.transform.forward * Time.deltaTime;
            Vector3 pos = transform.position;
            //目線の先ver
            pos.x += mainCamera.transform.forward.x * Time.deltaTime * 2.0f;
            pos.z += mainCamera.transform.forward.z * Time.deltaTime * 2.0f;
            ////体の向きver (一応残しておきます)
            // pos.x += camBox.transform.forward.x * Time.deltaTime * 2.0f;
            // pos.z += camBox.transform.forward.z * Time.deltaTime * 2.0f;
            transform.position = pos;
        }
    }
}
