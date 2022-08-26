using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private Light _Light;
    private SphereCollider _SphereCollider;

    private bool Light_UpDown;
    private float intensity;

    [HideInInspector] public float IntensitySpeed;

    private void Awake()
    {
        _Light = GetComponent<Light>();
        _SphereCollider = GetComponent<SphereCollider>();
       Light_UpDown = false;
    }
    private void Update()
    {
        if (gameObject.activeSelf)
        {
            if (Light_UpDown)
            {
                AddIntensity(IntensitySpeed * 1.5f);

                if (_Light.intensity >= intensity)
                {
                    Light_UpDown = false;
                }
            }
            else if (!Light_UpDown)
            {
                AddIntensity(-IntensitySpeed);

                if (_Light.intensity <= 0)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    public void StartWave(float Intensity, Color color)
    {
        gameObject.SetActive(true);
        intensity = Intensity;
        _Light.color = color;
        Light_UpDown =true;
    }

    private void AddIntensity(float Intensity)
    {
        _Light.intensity += Intensity * Time.deltaTime;
        _SphereCollider.radius += Intensity * Time.deltaTime;
    }
}
