using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;
    public GameObject Player;
    Vector3 mov;

    [Header("Float valus")]
    public float movspeed = 30;
    public float Health;
    [SerializeField] float Poss;
    [SerializeField] float Posl;

    public bool HIT;

    public float RotS = 5f;

    public TextMeshProUGUI HealthText;

    public bool left;
    public bool right;
    public bool top;
    public bool down;

    public bool topleft;
    public bool downleft;
    public bool topright;
    public bool downright;
    public bool CloseHouse;
    public bool StopMov;
    public bool Dodging;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    Vector3 tem;
    public float dodgeTimer = 0.3f;
    public float CoolDodge = 0.5f;
    public float speed = 5;
    float Cval;

    public float pause1 = -1;
    public float pause2 = -1;
    public float pause3 = -1;
    public float pauseB = 0;

    public bool start1 = false;
    public bool start2 = false;
    public bool start3 = false;
    public bool startB = false;

    public bool lock1 = false;
    public bool lock2 = true;
    public bool lock3 = true;

    private void FixedUpdate()
    {
        if (start1 == true)
        {
            if (pause1 > 0)
            {
                pause1 -= Time.deltaTime;

            }
        }
        if (start2 == true)
        {
            if (pause2 > 0)
            {
                pause2 -= Time.deltaTime;

            }
        }
        if (start3 == true)
        {
            if (pause3 > 0)
            {
                pause3 -= Time.deltaTime;

            }
            else
            {
                animator.SetBool("Backy", true);
            }
        }
        if (startB == true)
        {
            if (pauseB > 0)
            {
                pauseB -= Time.deltaTime;
            }
            else
            {
                lock1 = false;
                lock2 = true;
                lock3 = true;
                start1 = false;
                start2 = false;
                start3 = false;
                animator.SetBool("Combo1", false);
                animator.SetBool("Combo2", false);
                animator.SetBool("Combo3", false);

                animator.SetBool("Backy", true);
            }
        }
        else
        {
            animator.SetBool("Backy", false);
        }
    }
    void Update()
    {

        Cval = Player.transform.eulerAngles.y;
        HealthText.text = Health.ToString();

        if (dodgeTimer > 0.29)
        {
            animator.SetBool("Dodging", false);
        }
        else
        {
            animator.SetBool("Dodging", true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (lock1 == false)
            {
                if (pause3 <= 0)
                {
                    animator.SetBool("Combo3", false);
                    animator.SetBool("Combo1", true);
                    pause1 = 0.542f;
                    pauseB = 1f;
                    startB = true;
                    start1 = true;
                    lock1 = true;
                    lock2 = false;
                    lock3 = true;
                }
            }


        }
        if (Input.GetMouseButtonDown(0))
        {
            if (lock2 == false)
            {
                if (pause1 <= 0)
                {
                    pause2 = 0.542f;
                    pauseB = 1f;
                    animator.SetBool("Combo1", false);
                    animator.SetBool("Combo2", true);
                    start2 = true;
                    lock1 = true;
                    lock2 = true;
                    lock3 = false;
                }
            }

        }
        if (Input.GetMouseButtonDown(0))
        {
            if (lock3 == false)
            {
                if (pause2 <= 0)
                {
                    pauseB = 1f;
                    pause3 = 0.583f;
                    animator.SetBool("Combo2", false);
                    animator.SetBool("Combo3", true);
                    start3 = true;
                    lock1 = false;
                    lock2 = true;
                    lock3 = true;
                }
            }
        }


        //NOT ANIMATION
        if (Dodging == true)
        {
            if (CoolDodge <= 0)
            {

                dodgeTimer -= Time.deltaTime;
                if (dodgeTimer >= 0)
                {
                    if (CloseHouse == false)
                    {
                        transform.position = Vector3.Lerp(transform.position, tem, speed * Time.deltaTime);
                    }
                    else
                    {
                        //rb.AddForce(tem * speed);
                    }
                }
                else
                {
                    Dodging = false;
                    dodgeTimer = 0.3f;
                    CoolDodge = 0.5f;
                }
            }
        }
        else
        {
            if (CoolDodge >= 0)
            {
                CoolDodge -= Time.deltaTime;
            }
        }


        //stops player somehow when dialogue is playing. idk why but works
        if (DialogueManager.GetInstance().DialogueIsPlaying)
        {
            StopMov = true;
            rb.velocity = new Vector3(0, 0, 0);
            animator.SetBool("Idle", true);
            animator.SetBool("Running", false);
        }
        else
        {
            StopMov = false;
        }

        if (StopMov == false)
        {
            Position();
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            mov = new Vector3(horizontal, 0, vertical);
            //rb.transform.Translate(mov * movspeed * Time.deltaTime, Space.Self);
            mov.y += -0.5f;
            rb.velocity = mov * movspeed;


            if (Input.GetKeyDown(KeyCode.LeftShift))
            {

                Debug.Log("lol");
                Poss = 15;
                Posl = 10.16f;

                Flash(top, new Vector3(0, 0, Poss));
                Flash(down, new Vector3(0, 0, -Poss));
                Flash(right, new Vector3(Poss, 0, 0));
                Flash(left, new Vector3(-Poss, 0, 0));

                Flash(topright, new Vector3(Posl, 0, Posl));
                Flash(topleft, new Vector3(-Posl, 0, Posl));
                Flash(downright, new Vector3(Posl, 0, -Posl));
                Flash(downleft, new Vector3(-Posl, 0, -Posl));
            }
        }
    }

    void Flash(bool Pos, Vector3 V)
    {
        if (Pos == true)
        {
            if (CoolDodge <= 0)
            {

                if (dodgeTimer == 0.3f)
                {

                    tem = Player.transform.position;
                    tem += V;

                    Debug.Log(Pos.ToString());
                    Dodging = true;
                }


            }


        }
    }
    void Cancellor()
    {
        top = false;
        down = false;
        left = false;
        right = false;

        topright = false;
        topleft = false;
        downright = false;
        downleft = false;
    }
    void test(float Pval, float Tes)
    {
        if (Pval == Tes)
        {
            if (Pval > Player.transform.eulerAngles.y)
            {
                Player.transform.Rotate(0, RotS, 0);
            }
            if (Player.transform.eulerAngles.y > Pval)
            {
                Player.transform.Rotate(0, -RotS, 0);
            }
        }
    }
    void rotateFix(float Pval)
    {


        if (Cval == 0)
        {
            Cval = 1f;
        }
        test(Pval, 90);
        test(Pval, 45);
        test(Pval, 135);
        test(Pval, 180);
        test(Pval, 225);
        test(Pval, 270);
        test(Pval, 315);

        test(Pval, 1);


    }
    void Position()
    {
        bool strange = false;

        Cancellor();
        if (Input.GetKey(KeyCode.W))
        {
            Cancellor();
            top = true;
            if (strange == false)
            {
                rotateFix(180);
            }
            animator.SetBool("Running", true);
            animator.SetBool("Idle", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Cancellor();
            left = true;
            //Player.transform.eulerAngles = new Vector3(0, -90, 0);
            if (strange == false)
            {
                rotateFix(90);
            }
            animator.SetBool("Running", true);
            animator.SetBool("Idle", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Cancellor();
            right = true;

            //Player.transform.eulerAngles = new Vector3(0, 270, 0);
            if (strange == false)
            {
                rotateFix(270);
            }
            animator.SetBool("Running", true);
            animator.SetBool("Idle", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Cancellor();
            down = true;
            //Player.transform.eulerAngles = new Vector3(0, 0, 0);
            if (strange == false)
            {
                rotateFix(1);
            }
            animator.SetBool("Running", true);
            animator.SetBool("Idle", false);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            Cancellor();
            topleft = true;
            rotateFix(135);
            strange = true;
            animator.SetBool("Running", true);
            animator.SetBool("Idle", false);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            Cancellor();
            topright = true;
            rotateFix(225);
            strange = true;
            animator.SetBool("Running", true);
            animator.SetBool("Idle", false);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            Cancellor();
            downleft = true;
            rotateFix(45);
            strange = true;
            animator.SetBool("Running", true);
            animator.SetBool("Idle", false);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            Cancellor();
            downright = true;
            rotateFix(315);
            strange = true;
            animator.SetBool("Running", true);
            animator.SetBool("Idle", false);
        }
        //WW
        if (Input.GetKey(KeyCode.W))
        {
            if (strange == false)
            {
                rotateFix(180);
            }

        }
        //AA
        if (Input.GetKey(KeyCode.A))
        {

            if (strange == false)
            {
                rotateFix(90);
            }
        }
        //DD
        if (Input.GetKey(KeyCode.D))
        {

            if (strange == false)
            {
                rotateFix(270);
            }

        }
        //SS
        if (Input.GetKey(KeyCode.S))
        {

            if (strange == false)
            {
                rotateFix(359);
            }
        }
        if (left == true || right == true || top == true || down == true || topleft == true || topright == true || downleft == true || downright == true)
        {
            animator.SetBool("Running", true);
            animator.SetBool("Idle", false);
        }
        else
        {
            animator.SetBool("Running", false);
            animator.SetBool("Idle", true);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "NPC")
        {
            print("y u no work");
        }

        if (collision.gameObject.tag == "Bullet")
        {
            if (dodgeTimer <= 0.3)
            {

            }
            else
            {
                Health -= 1;
                HIT = true;
                if (Health <= 0)
                {
                    Health = 0;
                }
            }

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "House")
        {
            CloseHouse = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "House")
        {
            CloseHouse = false;
        }

    }

}
