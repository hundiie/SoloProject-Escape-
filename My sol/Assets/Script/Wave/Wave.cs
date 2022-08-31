using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public void StartWave(float Size, float MoveSpeed, Color col)
    {
        gameObject.SetActive(true);
        GetComponent<Renderer>().material.SetColor("_HighlightColor", col);
        GetComponent<Renderer>().material.color = col;
        StartCoroutine(BlowUp(Size, MoveSpeed));
        StartCoroutine(Pade(Size, MoveSpeed));
    }
    
    private IEnumerator BlowUp(float Size, float WaveSpeed)
    {
        for (float Blow = 0; Blow < Size; Blow+= WaveSpeed * Time.deltaTime)
        {
            transform.localScale = new Vector3(Blow, Blow, Blow);
            yield return null;
        }
        
    }

    private IEnumerator Pade(float Size, float WaveSpeed)
    {
        Color color = GetComponent<Renderer>().material.GetColor("_HighlightColor");
        Color Col = GetComponent<Renderer>().material.color;
        
        for (float pade = 1; pade >= 0; pade -= (WaveSpeed / Size) * Time.deltaTime)
        {
            color.a = pade;
            GetComponent<Renderer>().material.SetColor("_HighlightColor", color);
            color = GetComponent<Renderer>().material.GetColor("_HighlightColor");
            GetComponent<Renderer>().material.SetColor("_HighlightColor", color * 5);
            Col.a = 0;
            GetComponent<Renderer>().material.color = Col * 2;
            yield return null;
        }
        gameObject.SetActive(false);
    }

}
