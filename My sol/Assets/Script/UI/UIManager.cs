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
    public GameObject UI_Text;
    public GameObject UI_Retry;
    public GameObject UI_Clear;

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
        UI_Pause.GetComponent<Pause>()._Pause(Active);   
    }
    public void SetCenter(bool Active)
    {
        UI_Center.SetActive(Active);
    }
    public void SetMainText(string str, int FontSize)
    {
        UI_Text.GetComponent<TextManager>()._SetMainText(str, FontSize);
    }
    public void SetSubText(string str, int FontSize)
    {
        UI_Text.GetComponent<TextManager>()._SetSubText(str, FontSize);
    }
    public void Retry()
    {
        UI_Retry.GetComponent<Retry>()._Retry();
    }

    public void Clear(bool BOOL)
    {
        UI_Clear.GetComponent<Clear>()._Clear(BOOL);
    }
}
