using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerMove: MonoBehaviour, IinputListener {

    [SerializeField] CanvasRenderer[] UI_Canvas;
    [SerializeField] ItemSlot_1 m_Slot1;
    [SerializeField] ItemSlot_2 m_Slot2;

    private bool facingRight = true;
    private bool jump = false;

    public float MoveSpeed = 3f;
    public float JumpForce = 450f;
    public int MaxLife = 3;
    public int PlayerHealth = 3;

    private bool isDie = false;
    private bool isUnbeatable = false;
    public bool isItemHold = false;

    public Vector3 moveDir = Vector3.zero; // 캐릭터가 이용할 방향 벡터.
    public Collider2D GroundColl;          // 땅바닥 콜라이더
    public KeyInpuManager keyman;          // 입력값 처리하는 키 메니져

    private Rigidbody2D m_Rigidbody;
    private SpriteRenderer m_SpriteRenderer;
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
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        isDie = false;
        PlayerHealth = MaxLife;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDie)
            return;

        moveDir = Vector3.zero; // 매 프레임 마다 초기화를 해주어야, 한 번 눌렀을 때 미끄러지지 않는다.
        m_anim.SetFloat("MoveSpeed", 0.0f);
    }

    void LateUpdate()
    {
        if (isDie)
            return;

        if (moveDir == Vector3.zero)
            m_WalkSound.Pause();
    }

    // 물리 또는 항상 같음을 유지해야 하는 것 들을 이곳에서 처리한다.
    void FixedUpdate() 
    {
        if (isDie)
            return;

        // 그라운드 체크. 
        jump = Physics2D.IsTouchingLayers(GroundColl);  
        m_anim.SetBool("Ground", jump); // 점프상태 = 점프 애니메이션 상태

        // [ 이동 관련 처리 ]
        transform.position += (moveDir * Time.fixedDeltaTime * MoveSpeed); // 플레이어 포지션 변경 [ 이동 ]
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Should Not "isUnbeatable" and "Die" // Should be Hit Monster or Obstacle
        if ((other.gameObject.tag == "Monster" || other.gameObject.tag == "Obstacle") && !isUnbeatable && !isDie)
        {
            Vector2 HitDirection = Vector2.zero;

            if (other.gameObject.transform.position.x > transform.position.x)
                HitDirection = new Vector2(-1.2f, 5f);
            else
                HitDirection = new Vector2(1.2f, 5f);

            m_Rigidbody.velocity = Vector2.zero;
            m_Rigidbody.AddForce(HitDirection, ForceMode2D.Impulse);
            m_anim.SetTrigger("Hit");

            RemoveLife();

            if (PlayerHealth >= 1)
            {
                isUnbeatable = true;
                StartCoroutine(Unbeatable());
            }
            else
                Die();
        }

        if(other.gameObject.tag == "Item")
        {
            if (m_Slot2.GetState() == ItemSlot_2.SLOT_STATE.SLOT_EMPTY || !m_Slot1.IsEquiped)
            {
                isItemHold = true;  
            }
            else
            {
                isItemHold = false;
            }
        }
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

    public void Jump()
    {
        if (jump)
        {
            jump = false;
            m_Rigidbody.AddForce(new Vector2(0f, JumpForce * TimeMutiply)); // 플레이어 포지션 변경 [ 점프 ]
            TimeMutiply = 0.25f;
        }
    }

    private float checkTime;
    private float TimeMutiply;
    private IEnumerator CheckTime()
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
        StartCoroutine(CheckTime());
    }

    private IEnumerator Unbeatable()
    {
        int CountTime = 0;

        while(CountTime < 10)
        {
            if(CountTime % 2 == 0)
                m_SpriteRenderer.color = new Color32(255, 255, 255, 90);
            else
                m_SpriteRenderer.color = new Color32(255, 255, 255, 180);

            yield return new WaitForSeconds(0.25f);

            CountTime++;
        }

        m_SpriteRenderer.color = new Color32(255, 255, 255, 255);

        isUnbeatable = false;

        yield return null;
    }

    private void Die()
    {
        isDie = true;
        m_anim.SetTrigger("Die");

        BoxCollider2D[] Colls = gameObject.GetComponents<BoxCollider2D>();
        Colls[0].enabled = false;

        m_Rigidbody.velocity = Vector2.zero; // stop moving

        Vector2 GotoHell = new Vector2(0f, +10f);
        m_Rigidbody.AddForce(GotoHell, ForceMode2D.Impulse);

    }

    private void RemoveLife()
    {
        switch(PlayerHealth)
        {
            case 3:
                PlayerHealth--;
                UI_Canvas[0].SetAlpha(0);
                break;
            case 2:
                PlayerHealth--;
                UI_Canvas[1].SetAlpha(0);
                break;
            case 1:
                PlayerHealth--;
                UI_Canvas[2].SetAlpha(0);
                break;
            case 0:
                break;
        }
    }
}
