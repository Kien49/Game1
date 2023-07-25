using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMainManager : MonoBehaviour
{
    [SerializeField] private Button btnProfile; 
    [SerializeField] private Button btnUpdate; 
    [SerializeField] private Button btnShop; 
    [SerializeField] private Button btnPet;
    [SerializeField] private Button btnGate;

    //parent panel
    [SerializeField] private GameObject panelContent;

    [SerializeField] private GameObject panelUpdate;
    [SerializeField] private GameObject panelWeapon;
    [SerializeField] private GameObject panelShop;
    [SerializeField] private GameObject panelPet;
    [SerializeField] private GameObject panelProfile;
    [SerializeField] private GameObject panelGate;

    private string currActive = "";

    // Start is called before the first frame update
    void Start()
    {
        btnProfile.onClick.AddListener(() => onActivePanel(CommonConst._panelProfile));
        btnUpdate.onClick.AddListener(() => onActivePanel(CommonConst._panelUpdate));
        btnGate.onClick.AddListener(() => onActivePanel(CommonConst._panelGate));
        btnPet.onClick.AddListener(() => onActivePanel(CommonConst._panelPet));
        btnShop.onClick.AddListener(() => onActivePanel(CommonConst._panelShop));
    }

    private void onActivePanel(string nextActive)
    {

        (Button nextButtonActive, GameObject nextActiveGameobject) = getPanelFollowByName(nextActive);
        (Button currButtonActive, GameObject currActiveGameobject) = getPanelFollowByName(currActive);

        if (currActive.Equals(nextActive))
        {
            panelContent.SetActive(false);
            nextActiveGameobject.SetActive(false);
            nextButtonActive.image.color = Color.gray;
            currActive = "";
            return;
        }

        if (!"".Equals(currActive) && currButtonActive != null)
        {
            currButtonActive.image.color = Color.gray;
            currActiveGameobject.SetActive(false);
        }

        panelContent.SetActive(true);
        nextButtonActive.image.color = Color.white;
        nextActiveGameobject.SetActive(true);
        currActive = nextActive;
    }
    private (Button, GameObject) getPanelFollowByName(string name)
    {
        switch (name)
        {
            case CommonConst._panelProfile:
                return (btnProfile, panelProfile);
            case CommonConst._panelUpdate:
                return (btnUpdate, panelUpdate);
            case CommonConst._panelGate:
                return (btnGate, panelGate);
            case CommonConst._panelPet:
                return (btnPet, panelPet);
            case CommonConst._panelShop:
                return (btnShop, panelShop);
            default:
                return (null, null);
        }
    }

}
