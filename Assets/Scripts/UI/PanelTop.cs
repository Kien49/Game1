using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTop : MonoBehaviour
{
    [SerializeField] private Button btnShowInfo;

    [SerializeField] private PanelInfo panelInfo;
    int checkOnOff =0 ;
    // Start is called before the first frame update
    void Start()
    {
        btnShowInfo.onClick.AddListener(ShowInforMe);
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

}
