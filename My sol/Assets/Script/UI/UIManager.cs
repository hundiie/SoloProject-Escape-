using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject UI_WalkManager;
    public GameObject UI_Die;
    
    public void Setway(Transform trans, bool direction, Color COLOR)
    {
        UI_WalkManager.GetComponent<WalkManager>().wayPooling(trans, direction, COLOR);
    }

    public void Die(bool BOOL)
    {
        if (!BOOL)
        {
            Color COLOR = UI_Die.GetComponent<Die>().IMG.color;
            COLOR.a = 0;
            UI_Die.GetComponent<Die>().IMG.color = COLOR;
        }
        UI_Die.SetActive(BOOL);
    }



}
