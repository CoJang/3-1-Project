using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerMove: MonoBehaviour, IinputListener {

    public bool facingRight = true;
    private bool jump = false;

    public float MoveSpeed = 2f;
    public float JumpForce = 230f;

    public Vector3 moveDir = Vector3.zero; // 캐릭터가 이용할 방향 벡터.

    public Transform GroundCheck;
    public KeyInpuManager keyman;
    private Rigidbody2D m_Rigidbody;
    private Animator m_anim;

    // Use this for initialization
    //void Start ()
    //{
    //    GroundCheck = transform.Find("groundCheck");
    //}

    void Awake()
    {
        GroundCheck = transform.Find("groundCheck");
        keyman.Listerner = this;
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // [ 이동 관련 처리 ]
        moveDir = Vector3.zero; // 매 프레임 마다 초기화를 해주어야, 한 번 눌렀을 때 미끄러지지 않는다.
        m_anim.SetFloat("MoveSpeed", 0.0f);
    }

    // 물리 또는 항상 같음을 유지해야 하는 것 들을 이곳에서 처리한다.
    void FixedUpdate() 
    {
        // 그라운드 체크. 
        //jump = (Physics2D.OverlapPoint(GroundCheck.position) != null) ? true : false;
        jump = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        m_anim.SetBool("Ground", jump); // 점프상태 = 점프 애니메이션 상태
        transform.position += (moveDir * Time.fixedDeltaTime * MoveSpeed); // 플레이어 포지션 변경 [ 이동 ]
    }
    
    void Flip()
    {
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void Jump()
    {
        if (jump)
        {
            jump = false;
            m_Rigidbody.AddForce(new Vector2(0f, JumpForce)); // 플레이어 포지션 변경 [ 점프 ]
        }
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
    }
}
