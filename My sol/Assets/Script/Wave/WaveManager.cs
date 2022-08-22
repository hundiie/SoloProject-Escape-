using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private GameObject[] Wave = new GameObject[20];
    public float IntensitySpeed;
    private void Awake()
    {
        for (int i = 0; i < 20; i++)
        {
            Wave[i] = transform.GetChild(i).gameObject;
            Wave[i].GetComponent<Wave>().IntensitySpeed = IntensitySpeed;
        }
    }

    public void SetWave(Transform Soundtransform, float Intensity, Color color, string tag)
    {
        for (int i = 0; i < 20; i++)
        {
            if (Wave[i].activeSelf == false)
            {
                Wave _wave = Wave[i].GetComponent<Wave>();
                Wave[i].transform.position = Soundtransform.position;
                Wave[i].tag = tag;
                _wave.StartWave(Intensity, color);

                return;
            }
        }
    }
}
