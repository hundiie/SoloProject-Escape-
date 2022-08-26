using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneText : MonoBehaviour
{
    private UIManager _UIManager;

    public string MainText;
    public string SubText;

    private void Awake()
    {
        _UIManager = GameObject.FindWithTag("UIManager").gameObject.GetComponent<UIManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (MainText.Length != 0)
            {
                _UIManager.SetMainText(MainText, 72);
            }
            if (SubText.Length != 0)
            {
                _UIManager.SetSubText(SubText, 48);
            }
            Destroy(gameObject);
        }
    }
}
