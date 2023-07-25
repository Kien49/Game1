using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetPanel : MonoBehaviour
{
    [SerializeField] private Button btnPetProperties;
    [SerializeField] private Button btnPetPropertiesClose;

    [SerializeField] private GameObject panelPetProperties;

    // Start is called before the first frame update
    void Start()
    {
        btnPetProperties.onClick.AddListener(() => UIManager.ins.setActiveGameobject(panelPetProperties));
        btnPetPropertiesClose.onClick.AddListener(() => UIManager.ins.setActiveGameobject(panelPetProperties));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
