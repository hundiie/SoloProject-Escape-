using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Die : MonoBehaviour
{
    private Image IMG;
    [HideInInspector] public bool die;

    private void Awake()
    {
        IMG = transform.GetChild(0).GetComponent<Image>();
        gameObject.SetActive(false);
        die = false;
    }
    private void Update()
    {
        if (gameObject.activeSelf)
        {
            Color COLOR = IMG.color;

            if (IMG.color.a < 1)
            {
                COLOR.a += 0.3f * Time.deltaTime;
                IMG.color = COLOR;
            }
            else
            {
                if(die)
                { 
                    Time.timeScale = 0;
                }
            }
        }
    }

    public void _Die(bool BOOL)
    {
        if (!BOOL)
        {
            Color COLOR = IMG.color;
            COLOR.a = 0;
            IMG.color = COLOR;
        }
        die = BOOL;
        gameObject.SetActive(BOOL);
    }

}
