using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Retry : MonoBehaviour
{
    public Button[] button = new Button[2];
    private void Awake()
    {
        button[0].onClick.AddListener(delegate { buttonClick(0);});
        button[1].onClick.AddListener(() => buttonClick(1));
        gameObject.SetActive(false);
    }

    public void buttonClick(int Key)
    {
        switch (Key)
        {
            case 0:
                {
                    GameObject.FindWithTag("Player").GetComponent<PlayerManager>().Resurrection();
                    gameObject.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                }
                break;
            case 1:// ³ª°¡±â
                {
                    Application.Quit();
                }
                break;
            default:
                break;
        }
    }
    public void _Retry()
    {
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
