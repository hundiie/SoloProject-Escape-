using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Wave = new GameObject[30];
    public float WaveSpeed;

    private void Awake()
    {
        for (int i = 0; i < Wave.Length; i++)
        {
            Wave[i] = transform.GetChild(i).gameObject;
            Wave[i].GetComponent<Wave>().WaveSpeed = WaveSpeed;
        }
    }
    public void SetWave(Transform Soundtransform, float Size, Color color, string tag)
    {
        for (int i = 0; i < Wave.Length; i++)
        {
            if (Wave[i].activeSelf == false)
            {
                Wave _wave = Wave[i].GetComponent<Wave>();
                Wave[i].transform.position = Soundtransform.position;
                Wave[i].tag = tag;
                _wave.StartWave(Size, color);

                return;
            }
        }
        Debug.Log("저장된 웨이브 없음");
    }
}
