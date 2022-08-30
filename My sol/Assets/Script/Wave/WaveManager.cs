using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WAVETAG
{
    NOMALSOUND,
    MONSTERSOUND,
    NATURESOUND
}
public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Wave = new GameObject[30];
    public float WaveSpeed;

    private void Awake()
    {
        for (int i = 0; i < Wave.Length; i++)
        {
            Wave[i] = transform.GetChild(i).gameObject;
            Wave[i].SetActive(false);
        }
    }
    public void SetWave(Vector3 Soundtransform, float Size, Color color, WAVETAG tag)
    {
        for (int i = 0; i < Wave.Length; i++)
        {
            if (Wave[i].activeSelf == false)
            {
                Wave _wave = Wave[i].GetComponent<Wave>();
                Wave[i].transform.position = Soundtransform;
                string TagName = "Untagged";
                switch (tag)
                {
                    case WAVETAG.NOMALSOUND:TagName = "NomalSound";
                        break;
                    case WAVETAG.MONSTERSOUND:
                        TagName = "MonsterSound";
                        break;
                    case WAVETAG.NATURESOUND:
                        TagName = "NatureSound";
                        break;
                    default:
                        break;
                }
                Wave[i].tag = TagName;
                _wave.StartWave(Size, WaveSpeed, color);

                return;
            }
        }
        Debug.Log("저장된 웨이브 없음");
    }
}
