using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //movement
    public float movespeed, jumpforce; //untuk menentukan kecepatan jalan dan loncat
    public bool IsFacingRight, isJumping; //untuk memnentukan wajah kearah mana saat jalan dan untuk menentukan animasi loncat 
    Rigidbody2D rb;

    //ground checker
    public float radius;
    public Transform GroundChecker;
    public LayerMask WhatIsGround;

    //Animation
    Animator anim;
    string walk_parameter = "walk";
    string idle_parameter = "idle";
    string jump_parameter = "jump";
    string landing_parameter = "landing";


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        jump();// jump dipanggil di update karna hanya dijalankan beberapa kali, beda sama move 
    }

    void FixedUpdate() //movement di jalankan di sini, biar lebih presisi
    {
        movement();
    }

    void movement() //kode gerak kanan,kiri
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(move * movespeed, rb.linearVelocity.y);

        //kode Animation gerak dan idle
        if (move != 0)
        {
            anim.SetTrigger(walk_parameter);
        }
        else
        {
            anim.SetTrigger(idle_parameter);
        }

        //kode untuk posisi wajah menghadap kemana
        if (move > 0 && !IsFacingRight)
        {
            transform.eulerAngles = Vector2.zero;
            IsFacingRight = true;
        }
        else if (move < 0 && IsFacingRight)
        {
            transform.eulerAngles = Vector2.up * 180;
            IsFacingRight = false;
        }
    }
    void jump() //kode lompat
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.linearVelocity = Vector2.up * jumpforce;
        }

        //kode animasi jump dan landing
        if (!IsGrounded() && !isJumping)
        {
            anim.SetTrigger(jump_parameter);
            isJumping = true;
        }
        else if (IsGrounded() && isJumping)
        {
            anim.SetTrigger(landing_parameter);
            isJumping = false;
        }
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundChecker.position, radius, WhatIsGround); //ini aslinya lingkaran, agar bisa terlihat kita buat "OnDrawGizmos"
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(GroundChecker.position, radius);//dengan ini kita bisa melihat lingkaranya, agar presisi saat menempatkanya
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("holywater"))
        {
            goalManager.singelton.collectHolywater();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("goal"))
        {
            if (goalManager.singelton.canEnter)
            {
                print("youwin");
            }
        }
    }
}
