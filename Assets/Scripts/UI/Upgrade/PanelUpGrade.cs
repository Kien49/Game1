using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelUpGrade : MonoBehaviour
{
    [SerializeField] private Button btnHide; 
    [SerializeField] private Button btnMe; 
    [SerializeField] private Button btnWeapon; 
    [SerializeField] private Button btnSkin; 
    [SerializeField] private Button btnPet;

    [SerializeField] private GameObject panelContent;
    [SerializeField] private GameObject panelMe;
    [SerializeField] private GameObject panelWeapon;
    [SerializeField] private GameObject panelSkin;
    [SerializeField] private GameObject panelPet;

    public int checkChoose;

    // Start is called before the first frame update
    void Start()
    {

        checkChoose = 5;
        checkChooseOption();
        btnHide.onClick.AddListener(FHideUpGarade);
        btnMe.onClick.AddListener(FMe);
        btnWeapon.onClick.AddListener(FWeapon);
        btnSkin.onClick.AddListener(FFashion);
        btnPet.onClick.AddListener(FPet);
    }
    private void FHideUpGarade()
    {
        checkChoose = 5;
        checkChooseOption();
        panelContent.SetActive(false);
        btnHide.gameObject.SetActive(false);
    }
    private void FMe()
    {
        checkChoose = 1;
        checkChooseOption();
        btnHide.gameObject.SetActive(true);
    }
    private void FWeapon()
    {
        checkChoose = 2;
        checkChooseOption();
        btnHide.gameObject.SetActive(true);
    }
    private void FFashion()
    {
        checkChoose = 3;
        checkChooseOption();
        btnHide.gameObject.SetActive(true);
    }
    private void FPet()
    {
        checkChoose = 4;
        checkChooseOption();
        btnHide.gameObject.SetActive(true);
    }


    private void checkChooseOption()
    {
        panelContent.SetActive(true);
        switch (checkChoose)
        {

            case 1:
                panelMe.gameObject.SetActive(true);
                panelWeapon.gameObject.SetActive(false);
                panelSkin.gameObject.SetActive(false);
                panelPet.gameObject.SetActive(false);
                btnMe.image.color = Color.white;
                btnWeapon.image.color = Color.gray;
                btnSkin.image.color = Color.gray;
                btnPet.image.color = Color.gray;
                break;
            case 2:
                panelWeapon.gameObject.SetActive(true);
                panelSkin.gameObject.SetActive(false);
                panelPet.gameObject.SetActive(false);
                panelMe.gameObject.SetActive(false);
                btnMe.image.color = Color.gray;
                btnWeapon.image.color = Color.white;
                btnSkin.image.color = Color.gray;
                btnPet.image.color = Color.gray;
                break;
            case 3:
                panelSkin.gameObject.SetActive(true);
                panelMe.gameObject.SetActive(false);
                panelWeapon.gameObject.SetActive(false);
                panelPet.gameObject.SetActive(false);
                btnMe.image.color = Color.gray;
                btnWeapon.image.color = Color.gray;
                btnSkin.image.color = Color.white;
                btnPet.image.color = Color.gray;
                break;
            case 4:
                panelPet.gameObject.SetActive(true);
                panelMe.gameObject.SetActive(false);
                panelWeapon.gameObject.SetActive(false);
                panelSkin.gameObject.SetActive(false);
                btnMe.image.color = Color.gray;
                btnWeapon.image.color = Color.gray;
                btnSkin.image.color = Color.gray;
                btnPet.image.color = Color.white;
                break;

            case 5:
                btnMe.image.color = Color.gray;
                btnWeapon.image.color = Color.gray;
                btnSkin.image.color = Color.gray;
                btnPet.image.color = Color.gray;
                break;

        }
            
    }


}
