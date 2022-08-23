using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    private Image IMG;

    private float CoolTime;
    private bool CoolSwitch;
    private void Awake()
    {
        IMG = transform.GetChild(0).GetComponent<Image>();
    }
    private void Update()
    {
        if (CoolSwitch)
        {
            UpdateCoolTime();
        }
    }
    float Delta;
    private void UpdateCoolTime()
    {
        
        Delta += Time.deltaTime / CoolTime;
        IMG.fillAmount  = Mathf.Lerp(0, 100, Delta) /100;

        if (IMG.fillAmount >= 1)
        {
            Delta = 0;
            CoolSwitch = false;
        }

    }

    public void _Skill(float Time)
    {
        if(!CoolSwitch)
        {
            IMG.fillAmount = 0;
            CoolTime = Time;
            CoolSwitch = true;
        }
    }
}
