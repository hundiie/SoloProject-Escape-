using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkManager : MonoBehaviour
{
    private GameObject[] Walk = new GameObject[20];

    private void Awake()
    {
        for (int i = 0; i < Walk.Length; i++)
        {
            Walk[i] = transform.GetChild(i).gameObject;
        }
    }
    public void wayPooling(Transform trans, bool direction, Color COLOR)
    {
        int DIR = 0;
        DIR = direction ? 1 : 0;
        for (int i = 0; i < 20; i++)
        {
            if (!Walk[i].activeSelf)
            {
                Walk[i].SetActive(true);
                Walk[i].GetComponent<FootManager>()._Setway(trans, DIR, COLOR);
                return;
            }

        }
    }
}
