using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager ins { get; private set; }
    private void Awake()
    {
        if (ins != null && ins != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            ins = this;
        }
    }
    public GameObject panelWin;
    public GameObject paneLoss;
    // Start is called before the first frame update
    void Start()
    {
        paneLoss.SetActive(false);
        panelWin.SetActive(false);
    }
    public void setActiveGameobject(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

}
