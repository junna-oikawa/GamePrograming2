using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 direction;
    GameObject camera; 

    public int flag;
    public bool dirFlag;
    Vector3 startpos;
    void Start()
    {
        camera = GameObject.Find ("Main Camera"); 
        flag = 1;
        dirFlag = false;
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        float h1 = Input.GetAxis( "Horizontal 1");
        float v1 = Input.GetAxis( "Vertical 1" );

        float h2 = Input.GetAxis( "Horizontal 2" );
        float v2 = Input.GetAxis( "Vertical 2" );


        if (h1 > 0f)
			Debug.Log("h1) > 0f");
		else if (h1 < 0f)
			Debug.Log("h1) < 0f");
        
        if (h2 > 0f)
			Debug.Log("h2) > 0f");
		else if (h2 < 0f)
			Debug.Log("h2) < 0f");

        if (v1 > 0f)
			Debug.Log("v1) > 0f");
		else if (v1 < 0f)
			Debug.Log("v1) < 0f");

        if (v2 > 0f)
			Debug.Log("v2 > 0f");
		else if (v2 < 0f)
			Debug.Log("v2 < 0f");
        
        Move();
        Positioning();
        
        if(dirFlag){
            MoveHorizontal(h2, v2);
        }
        Vector3 pos = transform.position;
        if(pos.y < 10.0f){
            pos.x = startpos.x;
            pos.z = startpos.z;
            transform.position = pos;
        }
        

        var speed = 0.1f;


        if ( Input.GetKey ( KeyCode.Joystick1Button3 ) )
        {
            Debug.Log(h1);
        }

        MoveHorizontal(h2,v2);

        
    }

    public void Move(){

        if ( (Input.GetKeyDown ( KeyCode.Joystick2Button11 )　|| Input.GetKeyDown ( KeyCode.Joystick2Button4 )) || Input.GetKeyDown(KeyCode.Space)){
            flag ++;
        }
        if ( Input.GetKeyDown ( KeyCode.Joystick1Button1 )){
            flag ++;
        }

        Vector3 pos = transform.position;
        if (flag % 4 == 1){
            pos.y += 0.1f;
        }
        else if (flag % 4 == 3){
            pos.y -= 0.1f;
        }
        transform.position = pos;


    }

    public void MoveHorizontal(float h2, float v2){
        Vector3 pos = transform.position;
        if(v2 > 0f||Input.GetKey(KeyCode.UpArrow)){
            pos.x -= 0.2f;
        }
        if(v2 < 0f||Input.GetKey(KeyCode.DownArrow)){
            pos.x += 0.2f;
        }
        if(h2 < 0f||Input.GetKey(KeyCode.LeftArrow)){
            pos.z -= 0.2f;
        }
        if(h2 > 0f||Input.GetKey(KeyCode.RightArrow)){
            pos.z += 0.2f;
        }
		transform.position = pos;
    }

    public void Positioning(){
        Vector3 pos = transform.position;
        if(pos.y < -7.0f){
            flag = 0;
            
        }
        else if(pos.y >= 32.0f){
            flag = 2;

        }

        transform.position = pos;
        
        if(pos.y >= 32.0f){
            dirFlag = true;
        }
        else{
            dirFlag = false;
        }
    }
}
