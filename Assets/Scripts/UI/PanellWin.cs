using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanellWin : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button btnReplay;
    void Start()
    {
        btnReplay.onClick.AddListener(FRePlay);
    }

    private void FRePlay()
    {
        SceneManager.LoadScene(0);
    }
}
