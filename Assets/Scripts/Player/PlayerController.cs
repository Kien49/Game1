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
    public int hpPlayerMax;//hp
    public int hpPlayerRecovery;
    public float attackSpeed; // speed atck
    public int criticalRate; // ti le chi mang
    public int criticalDamge; // dame chi mang


    public int hpPlayer; 
    public float attackRange; // range atck
    public float timeRecoveyHp;

    [Header("Variable bool: ")]
    public bool playerAtk;
    public bool playerWin;
    public bool isRecoveryHp;
    private bool stopUpdate;
    private bool atkContinue;

    [Header("Component Player: ")]
    public Rigidbody2D rb2D;
    public SpineCtrlPlayer spine;
    public HealthBar healthBar;
    public CapsuleCollider2D boxCollider;
    public Canvas canvasP;
    public TxtHpDown txtHpDown;
    // Start is called before the first frame update
    void Start()
    {
        isRecoveryHp = true;
        atkContinue = true;
        playerAtk = false;
        playerWin = false;
        stopUpdate = true;


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
        if (!playerWin)
        {
            Attack();
            HpRecovery();
            if (GameCtrl.ins.enemy!=null) CheckStatusEnemy();

        }

    }

    private void CheckStatusEnemy()
    {
        if (GameCtrl.ins.enemy.eAtck)
        {
            if (stopUpdate)
            {
                atkContinue = true;
                playerAtk = true;
                stopUpdate = false;
            }
        }
        if (GameCtrl.ins.enemy.eDie)
        {
            atkContinue = false;
            stopUpdate = true;
            playerAtk = false;
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
            yield return new WaitForSeconds(countDown);
            StartCoroutine(CountDownAttack(countDown));
        }
    }

    public int dameFinal()
    {
        int rd = Random.Range(0, 100);
        if (rd <= criticalRate) return (damePlayer + criticalDamge);// chi mang
        return damePlayer;
    }

    public void TakeDamege(int damge)
    {
        hpPlayer -= damge;
        TxtHpDown texthp = Instantiate(txtHpDown, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity, this.transform);
        texthp.txtContent.text = "-"+damge;
        healthBar.SetHealth(hpPlayer, hpPlayerMax);

        if (hpPlayer <= 0)
        {

            canvasP.enabled = false;
            spine.death();
            boxCollider.enabled = false;
            StopAllCoroutines();
            //UIManager.ins.paneLoss.SetActive(true);
            
        }
    }

    public void PlayerSwapStatusGame()
    {
        RecoveryFullHpPlayer();
        playerAtk = true;
        canvasP.enabled = true;
        boxCollider.enabled = true;
        isRecoveryHp = true;
        spine.idle1();
    }

    public void RecoveryFullHpPlayer()
    {
        hpPlayer = hpPlayerMax;
        healthBar.SetHealth(hpPlayer, hpPlayerMax);
    }

    public void HpRecovery()
    {
        if(hpPlayer < hpPlayerMax - hpPlayerRecovery)
        {
            if (isRecoveryHp)
            {
                StartCoroutine(CouroutineHpRecovery(timeRecoveyHp));
                isRecoveryHp = false;
            }
        }
    }
    private IEnumerator CouroutineHpRecovery(float time)
    {
        if(hpPlayer < hpPlayerMax - hpPlayerRecovery)
        {
            hpPlayer += hpPlayerRecovery;
            healthBar.SetHealth(hpPlayer, hpPlayerMax);
            yield return new WaitForSeconds(time);
            StartCoroutine(CouroutineHpRecovery(time));
        }
        else
        {
            isRecoveryHp = true ;
        }
    }

}
