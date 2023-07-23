using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    public static GameCtrl ins;
    private void Awake()
    {
        ins = this;
    }
    public EnemyController enemy;
    public bool statusAtkBoss;
    public bool statusAtkNormal;

    [Header("Enemy Normal: ")]
    public bool isSpawnNormal;
    public int idxEnemyNormal;
    public List<EnemyController> listEnemyNormal;

    [Header("BOSS: ")]
    public int lv;
    public bool isSpawnBoss;
    public int idxBoss;
    public List<EnemyController> listBoss;

    // Start is called before the first frame update
    void Start()
    {
        checkLvSpawnBoss(lv);
        statusAtkNormal = false; 
        statusAtkBoss = true;
        isSpawnNormal = true;
        isSpawnBoss = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(statusAtkNormal)
        {
            if (isSpawnNormal)
            {
                spawnNormal(idxEnemyNormal);
                isSpawnNormal = false;
            }
        }
        if (statusAtkBoss)
        {
            
            if(isSpawnBoss)
            {
                SpawnBoss(idxBoss);
                isSpawnBoss = false;
            }
        }
    }

    private void spawnNormal(int i)
    {
        enemy = Instantiate(listEnemyNormal[i], new Vector3(0,-6,0), Quaternion.identity);

        if(idxEnemyNormal >= listEnemyNormal.Count-1)
        {
            idxEnemyNormal = 0;
        }
        else
        {
            idxEnemyNormal++;
        }
    }

    private void SpawnBoss( int i)
    {
       
        if (idxBoss >= 3)
        {
            StartCoroutine(NextLv(2));
        }
        else
        {
            if(listBoss.Count >=0)
            {
                enemy = Instantiate(listBoss[i], new Vector3(0, -6, 0), Quaternion.identity);
                idxBoss++;

            }
            else
            {
                SwapAtkNormal();
            }
        }
    }
    private void checkLvSpawnBoss(int i)
    {
        for (int ene = 0; ene < 3* i; ene++)
        {
            listBoss.Remove(listBoss[0]);
        }
    }

    public void SwapAtkNormal()
    {
        if (statusAtkBoss)
        {
            statusAtkBoss = false;
            statusAtkNormal = true;
            isSpawnNormal = true;
            PlayerController.ins.PlayerSwapStatusGame();
            PanelTop.ins.btnSwapAttackBoss.gameObject.SetActive(true);
        }
    }

    public void SwapAtkBoss()
    {
        if (statusAtkNormal)
        {
            idxBoss = 0;
            statusAtkBoss = true;
            statusAtkNormal = false;
            isSpawnBoss = true;
            PlayerController.ins.PlayerSwapStatusGame();
            PanelTop.ins.btnSwapAttackBoss.gameObject.SetActive(false);

        }
    }

    public void DestroyEnemy()
    {
        if (enemy != null) Destroy(enemy.gameObject);
    }

    private IEnumerator NextLv(float time)
    {
        PlayerController.ins.RecoveryFullHpPlayer();
        UIManager.ins.panelWin.SetActive(true);
        isSpawnBoss = false;
        yield return new WaitForSeconds(time);
        UIManager.ins.panelWin.SetActive(false);
        isSpawnBoss = true;
        lv += 1;
        for (int ene = 0; ene < 3; ene++)
        {
            listBoss.Remove(listBoss[0]);
        }
        idxBoss = 0;
    }
}
