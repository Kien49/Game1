using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfilePanel : MonoBehaviour
{
    [SerializeField] private Button btnWeapon;
    [SerializeField] private Button btnWeaponClose;

    [SerializeField] private GameObject panelWeapon;

    // Start is called before the first frame update
    void Start()
    {
        btnWeapon.onClick.AddListener(() => UIManager.ins.setActiveGameobject(panelWeapon));
        btnWeaponClose.onClick.AddListener(() => UIManager.ins.setActiveGameobject(panelWeapon));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
