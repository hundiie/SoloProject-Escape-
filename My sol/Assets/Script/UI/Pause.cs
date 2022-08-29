using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
                    _Pause(false);
                }
                break;
            case 1:// 다시하기
                {
                    SceneManager.LoadScene(0);
                    Time.timeScale = 1.0f;
                }
                break;
            case 2:// 나기기
                {
                    Application.Quit();
                }
                break;
            default:
                break;
        }
    }
    public void _Pause(bool Active)
    {
        gameObject.SetActive(Active);

        if (Active == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        if (Active == false)
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }


     }
}
