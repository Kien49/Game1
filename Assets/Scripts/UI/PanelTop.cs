using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTop : MonoBehaviour
{
    [SerializeField] private Button btnShowInfo;
    public Button btnSwapAttackBoss;

    [SerializeField] private PanelInfo panelInfo;
    int checkOnOff =0 ;
    public static PanelTop ins;
    private void Awake()
    {
        ins = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        btnShowInfo.onClick.AddListener(ShowInforMe);
        btnSwapAttackBoss.onClick.AddListener(SwapAttackBoss);
    }
     private void ShowInforMe()
    {
        checkOnOff++;

        if (checkOnOff % 2 == 0) panelInfo.gameObject.SetActive(false);
        else
        {
            panelInfo.UpdateInfo();
            panelInfo.gameObject.SetActive(true);
        }

    }
    private void SwapAttackBoss()
    {
        //btnSwapAttackBoss.gameObject.SetActive(false);
        //GameCtrl.ins.SwapAtkBoss();
        StartCoroutine(DelaySwapSatusGameToAtkBoss(2));
    }
    private IEnumerator DelaySwapSatusGameToAtkBoss(float time)
    {
        UIManager.ins.paneLoss.SetActive(true);
        GameCtrl.ins.DestroyEnemy();
        PlayerController.ins.spine.idle1();
        yield return new WaitForSeconds(time);
        UIManager.ins.paneLoss.SetActive(false);
        yield return new WaitForSeconds(time);
        GameCtrl.ins.SwapAtkBoss();
    }

}
