using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMe : MonoBehaviour
{
    [SerializeField] private Button btnDamge;
    [SerializeField] private Button btnAtkSpeed;
    [SerializeField] private Button btnAtkRange;
    [SerializeField] private Button btnHp;
    [SerializeField] private Button btnCriticalRate;
    [SerializeField] private Button btnCriticalDamge;

    [SerializeField] private Text txtLvDamge;
    [SerializeField] private Text txtAtkSpeed;
    [SerializeField] private Text txtAtkRange;
    [SerializeField] private Text txtHp;
    [SerializeField] private Text txtCriticalRate;
    [SerializeField] private Text txtCriticalDamge;

    [SerializeField] private PanelInfo panelInfo;

    // Start is called before the first frame update
    void Start()
    {
        showLvDamge();
        showLvAtkSpeed();
        showLvAtkRange();
        showLvHp();
        showLvCriticalRate();
        showLvCriticalDamge();

        btnDamge.onClick.AddListener(UpLevelDamge);
        btnAtkSpeed.onClick.AddListener(UpLevelAtkSpeed);
        btnAtkRange.onClick.AddListener(UpLevelAtkRange);
        btnHp.onClick.AddListener(UpLevelHp);
        btnCriticalRate.onClick.AddListener(UpLevelCriticalRate);
        btnCriticalDamge.onClick.AddListener(UpLevelCriticalDamge);
    }

    private void UpLevelDamge()
    {
        PlayerController.ins.damePlayer += 2;
        showLvDamge();
        PlayerPrefs.SetInt("Damge_Player", PlayerController.ins.damePlayer);
        PlayerPrefs.Save();
        panelInfo.UpdateInfo();
    }
    private void UpLevelAtkSpeed()
    {
        if (PlayerController.ins.attackSpeed <= 1.5f)
        {
            PlayerController.ins.attackSpeed += .1f;
            showLvAtkSpeed();
            PlayerPrefs.SetFloat("AtkSped_Player", PlayerController.ins.attackSpeed);
            PlayerPrefs.Save();
            panelInfo.UpdateInfo();
        }
        else txtAtkSpeed.text = "Max";
    }
    private void UpLevelAtkRange()
    {
        if (PlayerController.ins.attackRange <= 3.0f)
        {
            PlayerController.ins.attackRange += .2f;
            showLvAtkRange();
            PlayerPrefs.SetFloat("AtkRange_Player", PlayerController.ins.attackRange);
            
            PlayerPrefs.Save();
            panelInfo.UpdateInfo();

        }
        else txtAtkRange.text = "Max";
    }
    private void UpLevelHp()
    {
        PlayerController.ins.hpPlayerMax += 10;
        showLvHp();
        PlayerPrefs.SetInt("Hp_Player", PlayerController.ins.hpPlayerMax);
        PlayerPrefs.Save();
        panelInfo.UpdateInfo();

    }
    private void UpLevelCriticalRate()
    {
        if (PlayerController.ins.criticalRate <= 100)
        {
            PlayerController.ins.criticalRate += 2;
            showLvCriticalRate();
            PlayerPrefs.SetFloat("CriticalRate_Player", PlayerController.ins.criticalRate);
            PlayerPrefs.Save();
            panelInfo.UpdateInfo();

        }
        else txtCriticalRate.text = "Max";
    }
    private void UpLevelCriticalDamge()
    {
        PlayerController.ins.criticalDamge += 2;
        showLvCriticalDamge();
        PlayerPrefs.SetFloat("CriticalDamge_Player", PlayerController.ins.criticalDamge);
        PlayerPrefs.Save();
        panelInfo.UpdateInfo();

    }

    private void showLvDamge()
    {
        int lv = (PlayerController.ins.damePlayer - 5)/ 2 ;
        txtLvDamge.text = "Level " + lv.ToString();
    }
    private void showLvAtkSpeed()
    {
        float lv = (PlayerController.ins.attackSpeed - 0.5f) *10;
        int lvInt = (int)lv;
        txtAtkSpeed.text = "Level " + lvInt.ToString();
    }
    private void showLvAtkRange()
    {
        float lv = (PlayerController.ins.attackRange - 0.8f) * 10;
        int lvInt = (int)lv;
        txtAtkRange.text = "Level " + lvInt.ToString();
    }
    private void showLvHp()
    {
        int lv =(PlayerController.ins.hpPlayerMax - 50)/10 ;
        txtHp.text = "Level " + lv.ToString();
    }
    private void showLvCriticalRate()
    {
        int lv = (PlayerController.ins.criticalRate - 20)/ 2;
        txtCriticalRate.text = "Level " + lv.ToString();
    }
    private void showLvCriticalDamge()
    {
        int lv = (PlayerController.ins.criticalDamge - 5) / 2;
        txtCriticalDamge.text = "Level "+ lv.ToString();
    }



}
