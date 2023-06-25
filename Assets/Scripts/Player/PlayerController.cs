using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public static PlayerController ins;
    private void Awake()
    {
        ins = this;
    }
    [Header("Config index of Player: ")]
    public int damePlayer;// dame
    public float attackSpeed; // speed atck
    public float attackRange; // range atck
    public int hpPlayer; //hp
    public float speedPlayer; //speed run
    public int criticalRate; // ti le chi mang
    public int criticalDamge; // dame chi mang
    public int hpPlayerMax;

    [Header("Variable bool: ")]
    public bool playerRun;
    public bool playerAtk;
    public bool playerDie;
    public bool playerWin;
    private bool atkComplete;
    //private bool stopUpdate;
    private bool atkContinue;

    [Header("Component Player: ")]
    public Rigidbody2D rb2D;
    public SpineCtrlPlayer spine;
    public LayerMask layer;
    public HealthBar healthBar;
    public CapsuleCollider2D boxCollider;
    public Canvas canvasP;
    public TxtHpDown txtHpDown;
    // Start is called before the first frame update
    void Start()
    {
        atkContinue = true;
        playerAtk = false;
        playerDie = false;
        playerWin = false;
        playerRun = true;
        //stopUpdate = true;
        atkComplete = false;

        damePlayer = PlayerPrefs.GetInt("Damge_Player", damePlayer);
        attackSpeed= PlayerPrefs.GetFloat("AtkSped_Player", attackSpeed);
        attackRange = PlayerPrefs.GetFloat("AtkRange_Player", attackRange);
        hpPlayerMax = PlayerPrefs.GetInt("Hp_Player", hpPlayerMax);
        criticalRate = PlayerPrefs.GetInt("CriticalRate_Player", criticalRate);
        criticalDamge = PlayerPrefs.GetInt("CriticalDamge_Player", criticalDamge);
        hpPlayer = hpPlayerMax;
    }


    private void FixedUpdate()
    {
        if (!playerDie && !playerWin)
        {
            if (playerRun)
            {
                transform.position += transform.right * speedPlayer * Time.deltaTime;
            }
            Attack();
            CheckRaycast();
        }

    }

    private void CheckRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, attackRange, layer);
        Debug.DrawRay(transform.position, Vector2.right * attackRange, Color.green);

        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            if (playerRun)
            {
                atkContinue = true;
                playerAtk = true;
                playerRun = false;
            }
            if (atkComplete)
            {
                EnemyController enemy = hit.collider.gameObject.GetComponent<EnemyController>();
                enemy.TakeDamege(dameFinal());
                if (!enemy.eDie) atkContinue = true;
                
                else
                {
                    Run();
                    atkContinue = false;
                }
                atkComplete = false;
            }
        }
    }

    private void Attack()
    {
        if (playerAtk)
        {
            StartCoroutine(CountDownAttack(2- attackSpeed));
            playerAtk = false;
        }
    }
     private IEnumerator CountDownAttack(float countDown)
    {
        if (atkContinue)
        {
            spine.attack_1();
            yield return new WaitForSeconds(countDown / 2);
            atkComplete = true;
            yield return new WaitForSeconds(countDown / 2);
            StartCoroutine(CountDownAttack(countDown));
        }
    }
    private void Run()
    {
        if (!playerWin)
        {
            spine.runningShield();
            playerRun = true;
        }

    }
    private int dameFinal()
    {
        int rd = Random.Range(0, 100);
        if (rd <= criticalRate) return (damePlayer + criticalDamge);// chi mang
        return damePlayer;
    }

    public void TakeDamege(int damge)
    {
        hpPlayer -= damge;
        TxtHpDown texthp = Instantiate(txtHpDown, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity, this.transform);
        texthp.txtContent.text = "-"+damge;
        healthBar.SetHealth(hpPlayer, hpPlayerMax);
        //spine.getHit();

        if (hpPlayer <= 0)
        {
            canvasP.enabled = false;
            spine.death();
            boxCollider.enabled = false;
            StopAllCoroutines();
            playerDie = true;
            UIManager.ins.paneLoss.SetActive(true);
        }
    }
    public void completeMap()
    {
        playerWin = true;
        playerRun = false;
        StopAllCoroutines();
        spine.win();
        canvasP.enabled = false;
        UIManager.ins.panelWin.SetActive(true);
    }
}
