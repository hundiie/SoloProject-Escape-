using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneText : MonoBehaviour
{
    public GameObject UI_Manager;
    private UIManager UIM;

    public string MainText;
    public string SubText;

    private void Awake()
    {
        UIM = UI_Manager.GetComponent<UIManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UIM.SetMainText(MainText, 72);
            UIM.SetSubText(SubText, 48);
            Destroy(gameObject);
        }
    }
}
