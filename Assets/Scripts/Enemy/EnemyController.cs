using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Config index of Enemy: ")]
    public int dameEnemy;
    public int hpEnemy;
    public int hpEnemyRecovery;
    public float attackSpeedEnemy;

    public float speedEnemy;
    public float attackRangeEnemy;
    private int hpEnemyMax;
    public float timeRecoveyHp;
    [Header("Variable bool: ")]
    public bool eSpawn;
    public bool eAtck;
    public bool eDie;
    private bool atkContinue;
    public bool isRecoveryHp;
    [Header("Component Enemy: ")]
    public Rigidbody2D rb2D;
    public CapsuleCollider2D boxCollider;
    public SpineCtrlEnemy spine;
    public HealthBar healthBar;
    public Canvas canvasE;
    public TxtHpDown txtHpDown;
    //private bool stopUpdate;

    // Start is called before the first frame update
    void Start()
    {
        atkContinue = true;
        hpEnemyMax = hpEnemy;
        eSpawn = true;
        eAtck = false;
        eDie = false;
        isRecoveryHp = true;
    }

    void Update()
    {
        if (eSpawn)
        {
            transform.position += transform.up * speedEnemy * Time.deltaTime;
            if(transform.position.y >= -2)
            {
                eSpawn = false;
                eAtck = true;
                
            }
        }
        if(!eDie)
        {
            Attack();
            HpRecovery();
        }

    }

    private void Attack()
    {
        if (eAtck && atkContinue) 
        {
            StartCoroutine(CountDownAttack(attackSpeedEnemy));
            atkContinue = false;
        }
    }

    public void TakeDamege(int damge)
    {
        hpEnemy -= damge;
        TxtHpDown texthp = Instantiate(txtHpDown, new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z), Quaternion.identity);
        texthp.txtContent.text = "-" + damge;
        healthBar.SetHealth(hpEnemy, hpEnemyMax);

        if(hpEnemy <= 0)
        {
            eDie = true;
            eAtck = false;
            canvasE.enabled = false;
            spine.death();
            boxCollider.enabled = false;
            StopAllCoroutines();
            
        }
    }
   
    private IEnumerator CountDownAttack(float countDown)
    {
        spine.shoot();
        
        yield return new WaitForSeconds(countDown);
        StartCoroutine(CountDownAttack(countDown));
    }


    public void HpRecovery()
    {
        if (hpEnemy < hpEnemyMax - hpEnemyRecovery)
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
        if (hpEnemy < hpEnemyMax - hpEnemyRecovery)
        {
            hpEnemy += hpEnemyRecovery;
            healthBar.SetHealth(hpEnemy, hpEnemyMax);
            yield return new WaitForSeconds(time);
            StartCoroutine(CouroutineHpRecovery(time));
        }
        else
        {
            isRecoveryHp = true;
        }
    }

}
