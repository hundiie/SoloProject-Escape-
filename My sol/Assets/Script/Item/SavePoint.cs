using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    float delta;
    float x;
    float y;
    float z;

    private void Awake()
    {
        randomV();
    }
    private void Update()
    {
        delta += Time.deltaTime;

        if (delta >= 5f)
        {
            delta = 0;
            randomV();
        }
        transform.Rotate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
    }
    void randomV()
    {
        x = Random.Range(0, 360);
        y = Random.Range(0, 360);
        z = Random.Range(0, 360);
    }
}
