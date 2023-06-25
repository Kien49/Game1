using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInfo : MonoBehaviour
{
    // Start iƠs called before the first frame update
    [SerializeField] private Text txtDamge;
    [SerializeField] private Text txtAtkSpeed;
    [SerializeField] private Text txtAtkRange;
    [SerializeField] private Text txtHp;
    [SerializeField] private Text txtCriticalRate;
    [SerializeField] private Text txtCriticalDamge;
    int damePlayer, hpPlayerMax, criticalRate, criticalDamge;
    float attackSpeed, attackRange;

    void Start()
    {
        UpdateInfo();

    }

    public void UpdateInfo()
    {
        damePlayer = PlayerController.ins.damePlayer;
        attackSpeed = PlayerController.ins.attackSpeed;
        attackRange = PlayerController.ins.attackRange;
        hpPlayerMax = PlayerController.ins.hpPlayerMax;
        criticalRate = PlayerController.ins.criticalRate;
        criticalDamge = PlayerController.ins.criticalDamge;

        txtDamge.text = damePlayer.ToString();
        txtAtkSpeed.text = attackSpeed.ToString();
        txtAtkRange.text = attackRange.ToString();
        txtHp.text = hpPlayerMax.ToString();
        txtCriticalRate.text = criticalRate.ToString();
        txtCriticalDamge.text = criticalDamge.ToString();
    }
}
