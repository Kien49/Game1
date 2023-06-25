using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TxtHpDown : MonoBehaviour
{
    public TextMeshPro txtContent;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    private void Start()
    {
        StartCoroutine(Destroy());
    }
    void Update()
    {
        transform.position += transform.up * Time.deltaTime;

    }
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);    
    }

}
