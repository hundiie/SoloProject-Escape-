using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Foot : MonoBehaviour
{
    public RawImage _RawImage;

    private void Awake()
    {
        _RawImage = transform.GetChild(0).gameObject.GetComponent<RawImage>();
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (gameObject.activeSelf == true)
        {
            Color COLOR = _RawImage.color;
            if (COLOR.a > 0)
            {
                COLOR.a -= 0.3f * Time.deltaTime;
            }
            else
            {
                COLOR.a = 255;
                gameObject.SetActive(false);
            }
        _RawImage.color = COLOR;
        }
    }
}
