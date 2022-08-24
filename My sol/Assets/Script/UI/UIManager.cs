using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject UI_WalkManager;
    public GameObject UI_Center;
    public GameObject UI_Die;
    public GameObject UI_Skill;
    public GameObject UI_Pause;
    public void Setway(Transform trans, bool direction, Color COLOR)
    {
        UI_WalkManager.GetComponent<WalkManager>().wayPooling(trans, direction, COLOR);
    }

    public void Die(bool BOOL)
    {
        UI_Die.GetComponent<Die>()._Die(BOOL);
    }

    public void Skill(float CoolTime)
    {
        UI_Skill.GetComponent<Skill>()._Skill(CoolTime);
    }
    public void Pause(bool Active)
    {
        Debug.Log("1");
        UI_Pause.GetComponent<Pause>()._Pause(Active);
        
    }

    public void SetCenter(bool Active)
    {
        Debug.Log("2");
        UI_Center.SetActive(Active);
    }

}
