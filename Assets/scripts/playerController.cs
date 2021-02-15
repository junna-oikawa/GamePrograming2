using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//足音
[RequireComponent(typeof(AudioSource))]

public class playerController : MonoBehaviour
{
    GameObject subcamera;
    CameraControll script;
    //　キャラクターの速度
    private Vector3 velocity;
    //　前の速度
    private Vector3 oldVelocity;
    private float moveSpeed = 2f;
    //キャラ動き終わり


    //Animation
    private Animator animator;


    //足音

    [SerializeField] AudioClip[] clips;
    [SerializeField] bool randomizePitch = true;
    [SerializeField] float pitchRange = 0.1f;

    protected AudioSource source;



    // Start is called before the first frame update
    void Start()
    {
        subcamera = GameObject.Find("Sub Camera");
        script = GameObject.Find("CameraController").GetComponent<CameraControll>();
        animator = GetComponent<Animator>();

        //足音
        source = GetComponents<AudioSource>()[0];

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        //animation
        float h1 = Input.GetAxis("Horizontal 1");
        float v1 = Input.GetAxis("Vertical 1");
        var h2 = Input.GetAxis("Horizontal 2");
        var v2 = Input.GetAxis("Vertical 2");

        if (h2 != 0 || v2 != 0 || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            animator.SetBool("is_walking", true);
        else
            animator.SetBool("is_walking", false);


        //キャラ動き
        var rightleft = 0.0f;
        var updown = 0.0f;


        if (Input.GetKey(KeyCode.LeftArrow))
            rightleft = -1.0f;
        if (Input.GetKey(KeyCode.RightArrow))
            rightleft = 1.0f;
        if (Input.GetKey(KeyCode.UpArrow))
            updown = 1.0f;
        if (Input.GetKey(KeyCode.DownArrow))
            updown = -1.0f;

        velocity = Vector3.zero;

        velocity = new Vector3(v2 + updown, 0f, -h2 - rightleft);

        velocity = Vector3.Lerp(oldVelocity, velocity, moveSpeed * Time.deltaTime);

        oldVelocity = velocity;

        if (velocity.magnitude > 0f)
            transform.LookAt(transform.position + velocity);
        else
        {
        }


        velocity.y += Physics.gravity.y * Time.deltaTime;
    }

    Vector3 rawAngles = new Vector3(0,0,0);
    void OnDisable() // プレイヤーオフの際にplayerの体の向きをcamboxへ
    {
        // playerの体の向きをcamboxへ
        Vector3 worldAngle = this.transform.eulerAngles;
        float world_angle_y = worldAngle.y;
        script.yAngle2 = world_angle_y;
    }
//     void OnEnable()
//     {

// Debug.Log("PLAYERENABLE");
//         // transformを取得
//         Transform playerTransform = this.transform;
//         // ワールド座標を基準に、回転を取得
//         Vector3 worldAngle = playerTransform.eulerAngles;
//         rawAngles.y = script.yAngle;
//         Debug.Log("rawAngles.y = script.yAngle = " + rawAngles.y);
//         //rotaition.yをプレイヤーキャラの体の向き合わせる
//         worldAngle.y = script.yAngle;
//         playerTransform.eulerAngles = worldAngle;
//         //Debug.Log("playerTransform = " + playerTransform.eulerAngles);
//     }

    public void PlayFootstepSE()
    {
        if (randomizePitch)
            source.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);

        source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }
}
