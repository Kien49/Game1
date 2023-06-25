using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Config index of Enemy: ")]
    public float attackRangeEnemy;
    public float attackSpeedEnemy;
    public int dameEnemy;
    public int hpEnemy;
    public float speedEnemy;
    private int hpEnemyMax;

    [Header("Variable bool: ")]
    public bool eRun;
    public bool eAtck;
    public bool eHited;
    public bool eDie;
    private bool atkComplete;
    private bool atkContinue;

    [Header("Component Enemy: ")]
    public Rigidbody2D rb2D;
    public CapsuleCollider2D boxCollider;
    public SpineCtrlEnemy spine;
    public LayerMask layer;
    public HealthBar healthBar;
    public Canvas canvasE;
    public TxtHpDown txtHpDown;
    //private bool stopUpdate;

    // Start is called before the first frame update
    void Start()
    {
        atkContinue = true;
        hpEnemyMax = hpEnemy;
        eRun = true;
        eAtck = false;
        eDie = false;
        //stopUpdate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(eDie && PlayerController.ins.transform.position.x - this.transform.position.x >= 5f)
            Destroy(this.gameObject);
        if (eRun)
            transform.position += transform.right* speedEnemy * Time.deltaTime;
        Attack();

    }
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.right, attackRangeEnemy, layer);
        Debug.DrawRay(transform.position, -Vector2.right*attackRangeEnemy, Color.red);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            if (eRun)
            {
                eAtck = true;
                eRun = false;
            }
            if (atkComplete)
            {
                PlayerController player = hit.collider.gameObject.GetComponent<PlayerController>();
                player.TakeDamege(dameEnemy);
                if (!player.playerDie) atkContinue = true;
                else
                {
                    spine.jump();
                    canvasE.enabled = false;
                    atkContinue = false;
                }

                atkComplete = false;
            }
        }
    }

    private void Attack()
    {
        if (eAtck)
        {
            StartCoroutine(CountDownAttack(attackSpeedEnemy));
            eAtck = false;
        }
    }

    public void TakeDamege(int damge)
    {
        hpEnemy -= damge;
        TxtHpDown texthp = Instantiate(txtHpDown, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), Quaternion.identity, this.transform);
        texthp.txtContent.text = "-" + damge;
        healthBar.SetHealth(hpEnemy, hpEnemyMax);

        if(hpEnemy <= 0)
        {
            canvasE.enabled = false;
            atkContinue = false;
            spine.death();
            boxCollider.enabled = false;
            StopAllCoroutines();
            eDie = true;
            SpawnEnemy.ins.isSpawn = true;
            if(SpawnEnemy.ins.totalEnemyOfMap <= 0)
            {
                PlayerController.ins.completeMap();
            }
            
        }
    }
   
    private IEnumerator CountDownAttack(float countDown)
    {
        if (atkContinue)
        {
            spine.shoot();
            
            atkComplete = true;
            yield return new WaitForSeconds(countDown / 2);
            StartCoroutine(CountDownAttack(countDown));
        }
    }



}
