using System.Collections;
using UnityEngine;
using Cinemachine;
using System;

public class controll : MonoBehaviour
{
    Joystick joystick;
    Animator anim;
    Rigidbody rb;
    public float movement;
    public float movementForward;
    public Vector3 lihat;
    public float turnSmoothTime = 0.1f;
    float truenSmoothVelocity;
    public Transform cam;
    public float jumpForce = 5.0f;
    bool isGrounded;
    public float groundRayLength = 0.1f; // P
    public GameObject plan;




    //Particle





    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();



    }

    // Update is called once per frame
    public void Loncat()
    {
        // Memeriksa apakah karakter berada di tanah
        isGrounded = IsPlayerGrounded();

        // Melakukan lompatan saat tombol lompat ditekan dan karakter berada di tanah
        // 
        if (isGrounded && anim.GetBool("run"))
        {
            // if (anim.GetBool("run"))
            // {
            //     Jump();
            // }

            Jump();


        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("tes");
            Loncat();
        }
    }

    // }
    void FixedUpdate()
    {

        // isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);


        //Store user input as a movement vector
        // Vector3 m_Input = new Vector3(joystick.Horizontal, 0, joystick.Vertical).normalized;
        // lihat = m_Input;

        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        lihat = m_Input;


        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition



        if (lihat.z == 0)
        {

            anim.SetBool("run", false);
            // anim.SetBool("back", false);
        }


        if (m_Input.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(m_Input.x, m_Input.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref truenSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            // controller.Move(moveDir.normalized * speed * Time.deltaTime);
            rb.MovePosition(transform.position + moveDir.normalized * Time.deltaTime * movement);
            // magnitude  adalah nilai tengah atau rata2 yaitu 0 jika dilihat dari direction yang telah di normalized
        }

        if (m_Input.magnitude != 0f)
        {


            // rb.MovePosition(transform.position + m_Input * Time.deltaTime * movementForward);
            anim.SetBool("run", true);






            // rb.MovePosition(transform.position + m_Input * Time.deltaTime * movement);


            // rb.MovePosition(transform.position + m_Input * Time.deltaTime * movement);


        }
        else
        {
            anim.SetBool("run", false);





        }




    }



    void Jump()
    {
        // Memeriksa apakah karakter berada di tanah sebelum melompat
        if (isGrounded)
        {
            anim.SetTrigger("jump");
            // Menambahkan gaya lompatan ke rigidbody
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool IsPlayerGrounded()
    {
        // Mendapatkan tinggi terrain pada posisi karakter
        float terrainHeight = plan.transform.position.y;

        // Memeriksa apakah karakter berada di atas tanah dengan menggunakan ray
        return transform.position.y - terrainHeight < groundRayLength;
    }

    // void AnimationCharacter(string anima)
    // {
    //     anim.SetBool(anima, true);
    //     if (lihat.z == 0) anim.SetBool(anima, false);
    // }
}
