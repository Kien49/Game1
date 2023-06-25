using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image img;
    public Gradient gr;
    public void SetHealth(float health, float maxHealth)
    {
        img.fillAmount =(health/maxHealth);
        img.color = gr.Evaluate(img.fillAmount);

    }
}
