using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerMove: MonoBehaviour, IinputListener {

    public bool facingRight = true;
    private bool jump = false;

    public float MoveSpeed = 3f;
    public float JumpForce = 450f;

    public Vector3 moveDir = Vector3.zero; // 캐릭터가 이용할 방향 벡터.

    public Collider2D GroundColl;
    public KeyInpuManager keyman;
    private Rigidbody2D m_Rigidbody;
    private Animator m_anim;

    AudioSource m_WalkSound;

    // Use this for initialization
    //void Start ()
    //{
    //    GroundCheck = transform.Find("groundCheck");
    //}

    void Awake()
    {
        keyman.Listerner = this;
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
        m_WalkSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = Vector3.zero; // 매 프레임 마다 초기화를 해주어야, 한 번 눌렀을 때 미끄러지지 않는다.
        m_anim.SetFloat("MoveSpeed", 0.0f);
    }

    void LateUpdate()
    {
        if (moveDir == Vector3.zero)
            m_WalkSound.Pause();
    }

    // 물리 또는 항상 같음을 유지해야 하는 것 들을 이곳에서 처리한다.
    void FixedUpdate() 
    {
        // 그라운드 체크. 
        jump = Physics2D.IsTouchingLayers(GroundColl);  
        //jump = Physics2D.IsTouchingLayers(GroundColl, 1 << LayerMask.NameToLayer("Ground");
        //jump = (Physics2D.OverlapPoint(GroundCheck.position) != null) ? true : false;
        //jump = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        m_anim.SetBool("Ground", jump); // 점프상태 = 점프 애니메이션 상태
        // [ 이동 관련 처리 ]
        transform.position += (moveDir * Time.fixedDeltaTime * MoveSpeed); // 플레이어 포지션 변경 [ 이동 ]
    }

    void Flip()
    {
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void Lmove()
    {
        moveDir += Vector3.left;
        m_anim.SetFloat("MoveSpeed", 0.2f);

        if (facingRight)
        {
            facingRight = false;
            Flip();
        }

        if (m_WalkSound.isPlaying == false)
            m_WalkSound.Play();
    }

    public void Rmove()
    {
        moveDir += Vector3.right;
        m_anim.SetFloat("MoveSpeed", 0.2f);

        if (!facingRight)
        {
            facingRight = true;
            Flip();
        }

        if (m_WalkSound.isPlaying == false)
            m_WalkSound.Play();
    }

    //public IEnumerator Jump()
    public void Jump()
    {
        if (jump)
        {
            jump = false;
            //Debug.Log("Touched Time : " + checkTime);
            //print(TimeMutiply);
            m_Rigidbody.AddForce(new Vector2(0f, JumpForce * TimeMutiply)); // 플레이어 포지션 변경 [ 점프 ]
            TimeMutiply = 0.25f;
        }
    }

    float checkTime;
    float TimeMutiply;
    public IEnumerator CheckTime()
    {
        checkTime = 0;

        while (jump) // 점프하기 직전까지 계속 췤
        {
            checkTime += 0.4f;

            if (checkTime < 0.5f)
                TimeMutiply = 0.55f;
            else if (checkTime >= 0.5f && checkTime < 0.9f)
                TimeMutiply = 0.75f;
            else if (checkTime >= 0.9f && checkTime <= 1.2f)
                TimeMutiply = 0.85f;
            else if (checkTime > 1.4f)
                TimeMutiply = 1.00f;

            yield return new WaitForSeconds(0.4f);
        }


    }

    public void CheckTouchedTime()
    {
        StartCoroutine("CheckTime");
    }



}
