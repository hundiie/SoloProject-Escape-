using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FootManager : MonoBehaviour
{
    private GameObject[] Dir = new GameObject[2];

    private void Awake()
    {
        for (int i = 0; i < 2; i++)
        {
            Dir[i] = transform.GetChild(i).gameObject;
        }
        gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (!Dir[0].activeSelf && !Dir[1].activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
    public void _Setway(Transform trans, int direction, Color COLOR)
    {
        Vector3 v3 = new Vector3(trans.position.x, trans.position.y - 1.998f, trans.position.z);

        Dir[direction].SetActive(true);
        Dir[direction].transform.GetChild(0).gameObject.GetComponent<RawImage>().color = COLOR;
        transform.position = v3;
        transform.rotation = trans.rotation;


    }
}
