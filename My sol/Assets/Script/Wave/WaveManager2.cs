using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager2 : MonoBehaviour
{
    private GameObject[] Wave = new GameObject[30];
    public float IntensitySpeed;
    private void Awake()
    {
        for (int i = 0; i < Wave.Length; i++)
        {
            Wave[i] = transform.GetChild(i).gameObject;
            Wave[i].GetComponent<Wave2>().IntensitySpeed = IntensitySpeed;
        }
    }

    public void SetWave(Transform Soundtransform, float Intensity, Color color, string tag)
    {
        for (int i = 0; i < Wave.Length; i++)
        {
            if (Wave[i].activeSelf == false)
            {
                Wave2 _wave = Wave[i].GetComponent<Wave2>();
                Wave[i].transform.position = Soundtransform.position;
                Wave[i].tag = tag;
                _wave.StartWave(Intensity, color);

                return;
            }
        }
        Debug.Log("저장된 웨이브 없음");

    }
    
}
