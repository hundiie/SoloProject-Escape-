using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject[] _Item = new GameObject[0];

    public void BackItem()
    {
        for (int i = 0; i < _Item.Length; i++)
        {
            _Item[i].GetComponent<Item>()._BackUpItem();
        }
    }
}
