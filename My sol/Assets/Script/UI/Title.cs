using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public Button[] button = new Button[2];
    private void Awake()
    {
        button[0].onClick.AddListener(delegate { buttonClick(0); });
        button[1].onClick.AddListener(() => buttonClick(1));
    }
    private void buttonClick(int Key)
    {
        switch (Key)
        {
            case 0:
                {
                    SceneManager.LoadScene(1);
                }
                break;
            case 1:
                {
                    Application.Quit();
                }
                break;
            default:
                break;
        }
    }
}
