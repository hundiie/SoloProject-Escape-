using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public Button[] button = new Button[3];
    private void Awake()
    {
        button[0].onClick.AddListener(delegate { buttonClick(0);});
        button[1].onClick.AddListener(() => buttonClick(1));
        button[2].onClick.AddListener(() => buttonClick(2));
        gameObject.SetActive(false);
    }

    public void buttonClick(int Key)
    {
        switch (Key)
        {
            case 0:
                {
                    Debug.Log("4");
                    _Pause(false);
                }
                break;
            case 1:// 다시하기
                {
                }
                break;
            case 2:// 나기기
                {

                }
                break;
            default:
                break;
        }
    }
    public void _Pause(bool Active)
    {
        Debug.Log("3");
        gameObject.SetActive(Active);

        if (Active == true)
        {
            Time.timeScale = 0f;
        }
        if (Active == false)
        {
            Time.timeScale = 1f;
        }


     }
}
