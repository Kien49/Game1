using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public static SpawnEnemy ins;
    private void Awake()
    {
        ins = this;
    }

    public int totalEnemyBoss;
    public int idxEnemy;
    public bool isSpawn;

    public List<EnemyController> listEnemy;
    public List<int> listIndexOfEnemySpawn; 

    

    // Start is called before the first frame update
    void Start()
    {
        idxEnemy = 0;
        isSpawn = true;
    }
    private void Update()
    {
        spawnE();
    }

    private void spawnE()
    {
        if(isSpawn && totalEnemyBoss > 0)
        {
            spawnEnemyFollowIndex(listIndexOfEnemySpawn[idxEnemy]);
        }
        
    }
    private void spawnEnemyFollowIndex(int i)
    {
        EnemyController e = Instantiate(listEnemy[i], new Vector3(PlayerController.ins.transform.position.x + 8, PlayerController.ins.transform.position.y, PlayerController.ins.transform.position.z), Quaternion.Euler(0, 180, 0), this.transform);
        isSpawn = false;
        totalEnemyBoss -= 1;
        idxEnemy++;
    }
}
