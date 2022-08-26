using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private bool Light;
    private float intensity;

    [HideInInspector] public float WaveSpeed;
    private void Awake()
    {
    }
    private void Update()
    {
        if (gameObject.activeSelf)
        {
            if (Light)
            {
                Vector3 V3 = new Vector3(1, 1, 1);
                transform.localScale += V3 * Time.deltaTime * WaveSpeed;
                if (transform.localScale.x >= intensity)
                {
                    Light = false;
                }
            }
            else if (!Light)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void StartWave(float Intensity, Color col)
    {
        gameObject.SetActive(true);
        transform.position -= new Vector3(0, 1, 0);
        transform.localScale = new Vector3(0, 0, 0);
        GetComponent<Renderer>().material.SetColor("_HighlightColor", col);
        intensity = Intensity;
        Light = true;
    }
    
}
