using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(playerTransform.position.x +.8f, playerTransform.position.y+1f, this.transform.position.z);
    }
}
