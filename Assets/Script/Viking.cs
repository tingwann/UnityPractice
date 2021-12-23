using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]


public class Viking : MonoBehaviour
{
    
    public float defaultRunSpeed = 7.0f;
    public float speedUpRate = 1.0f;
    //public GUIText elapseTimeGUIText;
    private float runSpeed;
    private int runDirection;
    Rigidbody rigidbody;
    Animator animator;
    [SerializeField]float JumpingForce = 400f;
    [SerializeField] LayerMask GroundMask;
    bool jump = false;
    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        this.runSpeed = this.defaultRunSpeed;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        jump = false;
        this.processKeyInput();
        animator.SetBool("Jump", jump);
        this.move();
        this.updateElapsedTimeLabel();
        this.speedUp();
       
        this.checkFail();
    }

  

    //keyborad
    private float lastRotateTime;
    private float lastJumpTime;
    private bool arrowKeyPressed;

    private void processKeyInput()
    {
        if (!arrowKeyPressed && Time.time - lastRotateTime > 0.1f)
        {
            if (Input.GetKey(KeyCode.A))
            {
                runDirection -= 90;
                lastRotateTime = Time.time;
                arrowKeyPressed = true;

            }
            else if (Input.GetKey(KeyCode.D))
            {
                runDirection += 90;
                lastRotateTime = Time.time;
                arrowKeyPressed = true;
            }
            if (Input.GetKey(KeyCode.Q))
            {

                if (runDirection % 360 == 0)
                    this.transform.position += Vector3.left;
                else if (runDirection % 360 == 90 || runDirection % 360 == -270)
                    this.transform.position += Vector3.forward;
                else if (runDirection % 360 == 180 || runDirection % 360 == -180)
                    this.transform.position += Vector3.right;
                else if (runDirection % 360 == 270 || runDirection % 360 == -90)
                    this.transform.position += Vector3.back;

            }
            else if (Input.GetKey(KeyCode.E))
            {

                if (runDirection % 360 == 0)
                    this.transform.position += Vector3.right;
                else if (runDirection % 360 == 90 || runDirection % 360 == -270)
                    this.transform.position += Vector3.back;
                else if (runDirection % 360 == 180 || runDirection % 360 == -180)
                    this.transform.position += Vector3.left;
                else if (runDirection % 360 == 270 || runDirection % 360 == -90)
                    this.transform.position += Vector3.forward;


            }
            
        }
        if (!arrowKeyPressed && Time.time - lastJumpTime > 1f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
                jump = true;
                lastJumpTime = Time.time;
                arrowKeyPressed = true;
            }
        }
       

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.Space))
        {
            arrowKeyPressed = false;
        }

    }

    private void move()
    {
        this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, runDirection, 0), 0.25f);

        Vector3 v = transform.forward * this.runSpeed;
        v.y = this.rigidbody.velocity.y;
        this.rigidbody.velocity = v;
    }

    private void speedUp()
    {
        //speed up 0.1 per 10sec.
        this.runSpeed = defaultRunSpeed + Time.time / 10.0f * this.speedUpRate;
    }

    private void updateElapsedTimeLabel()
    {
        float now = Time.time;
        int sec = (int)now;
        float mil = (now - (float)sec) * 100.0f;
        
    }

    void Jump()
    {
        //check whether we are currently grounded
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f , GroundMask);
        //if we are , jump

        rigidbody.AddForce(Vector3.up * JumpingForce);
        
    }
    private void checkFail()
    {
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(0, 5, 0);
            transform.rotation = Quaternion.identity;
            this.runDirection = 0;
            this.runSpeed = this.defaultRunSpeed;

            SceneManager.LoadScene(2);
            //GameManager.inst.IncrementScore();
            //SceneSwitcher sc = GameObject.FindObjectOfType<SceneSwitcher>();
            // sc.
        }
    }
}