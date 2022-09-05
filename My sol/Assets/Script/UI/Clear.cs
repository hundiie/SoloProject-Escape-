using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    private UIManager _UIManager;

    private Image IMG;
    [HideInInspector] public bool ClearT;
    private void Awake()
    {
        _UIManager = transform.parent.GetComponent<UIManager>();
        IMG = transform.GetChild(0).GetComponent<Image>();
        gameObject.SetActive(false);
        ClearT = false;
    }
    private void Update()
    {
        if (gameObject.activeSelf)
        {
            Color COLOR = IMG.color;

            if (IMG.color.a < 1)
            {
                COLOR.a += 0.3f * Time.deltaTime;
                IMG.color = COLOR;
            }
            else
            {
                if (ClearT)
                {
                    SceneManager.LoadScene(0);
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
    }

    public void _Clear(bool BOOL)
    {
        if (!BOOL)
        {
            Color COLOR = IMG.color;
            COLOR.a = 0;
            IMG.color = COLOR;
        }
        ClearT = BOOL;
        gameObject.SetActive(BOOL);
    }
}
