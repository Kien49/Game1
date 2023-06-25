using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager ins;
    private void Awake()
    {
        ins = this;
    }
    public GameObject panelWin;
    public GameObject paneLoss;
    // Start is called before the first frame update
    void Start()
    {
        paneLoss.SetActive(false);
        panelWin.SetActive(false);
    }


}
