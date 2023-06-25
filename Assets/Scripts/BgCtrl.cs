using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgCtrl : MonoBehaviour
{
    public Transform mainCam;
    public Transform midBg;
    public Transform sideBg;
    public float length;
    void Update()
    {
        if (mainCam.position.x > midBg.position.x)
        {
            sideBg.position = midBg.position + Vector3.right * length;
        }
        if (mainCam.position.x < midBg.position.x)
        {
            sideBg.position = midBg.position + Vector3.left * length;
        }
        if (mainCam.position.x > sideBg.position.x || mainCam.position.x < sideBg.position.x)
        {
            Transform tmp = midBg;
            midBg = sideBg;
            sideBg = tmp;
        }
    }
}
