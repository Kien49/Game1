using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelShop : MonoBehaviour
{
    [SerializeField] private Button btnSummon;
    [SerializeField] private Button btnHotShop;
    [SerializeField] private Button btnSpecialShop;

    [SerializeField] private GameObject panelSummon;
    [SerializeField] private GameObject panelHotShop;
    [SerializeField] private GameObject panelSpecialShop;

    [SerializeField] private Button btnSummonItem;
    [SerializeField] private Button btnSummonItem1;
    [SerializeField] private Button btnSummonItem2;
    [SerializeField] private Button btnSummonItemClose;

    [SerializeField] private GameObject panelSummonItem;

    public static string currActive = CommonConst._panelSummon;
    void Start()
    {
        onActivePanel(CommonConst._panelSummon);
        btnSummon.onClick.AddListener(() => onActivePanel(CommonConst._panelSummon));
        btnHotShop.onClick.AddListener(() => onActivePanel(CommonConst._panelHotShop));
        btnSpecialShop.onClick.AddListener(() => onActivePanel(CommonConst._panelSpecialShop));

        btnSummonItemClose.onClick.AddListener(() => UIManager.ins.setActiveGameobject(panelSummonItem));
        btnSummonItem.onClick.AddListener(() => UIManager.ins.setActiveGameobject(panelSummonItem));
        btnSummonItem1.onClick.AddListener(() => UIManager.ins.setActiveGameobject(panelSummonItem));
        btnSummonItem2.onClick.AddListener(() => UIManager.ins.setActiveGameobject(panelSummonItem));
    }

    private void onActivePanel(string nextActive)
    {
        (Button nextButtonActive, GameObject nextActiveGameobject) = getPanelFollowByName(nextActive);
        (Button currButtonActive, GameObject currActiveGameobject) = getPanelFollowByName(currActive);

        if (!"".Equals(currActive) && currButtonActive != null)
        {
            currButtonActive.image.color = Color.gray;
            currActiveGameobject.SetActive(false);
        }

        nextButtonActive.image.color = Color.white;
        nextActiveGameobject.SetActive(true);
        currActive = nextActive;
    }
    private (Button, GameObject) getPanelFollowByName(string name)
    {
        switch (name)
        {
            case CommonConst._panelSummon:
                return (btnSummon, panelSummon);
            case CommonConst._panelHotShop:
                return (btnHotShop, panelHotShop);
            case CommonConst._panelSpecialShop:
                return (btnSpecialShop, panelSpecialShop);
            default:
                return (null, null);
        }
    }
}
