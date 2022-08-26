using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextManager : MonoBehaviour
{
    [Header("Text")]
    public GameObject MainTMP;
    public GameObject SubTMP;

    private Text _MainTMP;
    private Text _SubTMP;

    private bool MainText;
    private bool SubText;

    private void Awake()
    {
        _MainTMP = MainTMP.GetComponent<Text>();
        _SubTMP = SubTMP.GetComponent<Text>();
        MainText = false;
        SubText = false;
        MainTMP.gameObject.SetActive(false);
        SubTMP.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (MainText)
        {
            Color COLOR = _MainTMP.color;
            COLOR.a += 0.3f * Time.deltaTime;
            _MainTMP.color = COLOR;
            if (COLOR.a >= 1)
            {
                MainText = false;
            }
        }
        else if (!MainText)
        {
            Color COLOR = _MainTMP.color;
            COLOR.a -= 0.3f * Time.deltaTime;
            _MainTMP.color = COLOR;
            if (COLOR.a <= 0)
            {
                MainTMP.SetActive(false);
            }
        }

        if (SubText)
        {
            Color COLOR = _SubTMP.color;
            COLOR.a += 0.3f * Time.deltaTime;
            _SubTMP.color = COLOR;
            if (COLOR.a >= 1)
            {
                SubText = false;
            }
        }
        else if (!SubText)
        {
            Color COLOR = _SubTMP.color;
            COLOR.a -= 0.3f * Time.deltaTime;
            _SubTMP.color = COLOR;
            if (COLOR.a <= 0)
            {
                SubTMP.SetActive(false);
            }
        }
    }

    private void InitMainText()
    {
        Color col = _MainTMP.color;
        col.a = 0;
        _MainTMP.color = col;
    }

    public void _SetMainText(string str, int FontSize)
    {
        _MainTMP.text = str;
        _MainTMP.fontSize = FontSize;

        InitMainText();
        MainText = true;
        MainTMP.SetActive(true);
    }
    private void InitSubText()
    {
        Color col = _SubTMP.color;
        col.a = 0;
        _SubTMP.color = col;
    }
    public void _SetSubText(string str, int FontSize)
    {
        _SubTMP.text = str;
        _SubTMP.fontSize = FontSize;

        InitSubText();
        SubText = true;
        SubTMP.SetActive(true);
    }
}
