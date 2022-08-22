using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Die : MonoBehaviour
{
    public Image IMG;

    private void Awake()
    {
        IMG = transform.GetChild(0).GetComponent<Image>();
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (gameObject.activeSelf)
        {
            Color COLOR = IMG.color;
            if (IMG.color.a < 255)
            {
                COLOR.a += 0.3f * Time.deltaTime;
                IMG.color = COLOR;
            }
            else
            {
                gameObject.SetActive(false);
                Time.timeScale = 0;
            }
        }
    }
}
