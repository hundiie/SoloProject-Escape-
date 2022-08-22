using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Foot : MonoBehaviour
{
    RawImage _RawImage;

    private void Start()
    {
        _RawImage = transform.GetChild(0).gameObject.GetComponent<RawImage>();
    }
    private void Update()
    {
        Color COLOR = _RawImage.color;
        if (COLOR.a > 0)
        {
            COLOR.a -= 0.3f*Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
        _RawImage.color = COLOR;
    }
}
