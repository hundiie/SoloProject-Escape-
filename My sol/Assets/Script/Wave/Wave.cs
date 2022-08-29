using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public void StartWave(float Size, float MoveSpeed, Color col)
    {
        gameObject.SetActive(true);
        transform.position -= new Vector3(0, 1, 0);
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
        for (float pade = 1; pade >= 0; pade -= WaveSpeed / Size * Time.deltaTime)
        {
            color.a = pade;
            GetComponent<Renderer>().material.SetColor("_HighlightColor", color);
            yield return null;
        }
        gameObject.SetActive(false);
    }

}
