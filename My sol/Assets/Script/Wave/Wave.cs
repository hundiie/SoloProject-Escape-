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
        StartCoroutine(Fade(Size, MoveSpeed));
    }
    
    private IEnumerator BlowUp(float Size, float WaveSpeed)
    {
        for (float Blow = 0; Blow < Size; Blow+= WaveSpeed * Time.deltaTime)
        {
            transform.localScale = new Vector3(Blow, Blow, Blow);
            yield return null;
        }
        
    }
    
    private static readonly string HIGHLIGHT_COLOR = "_HighlightColor";
    private IEnumerator Fade(float Size, float WaveSpeed)
    {
        Renderer renderer = GetComponent<Renderer>();
        Color baseColor = renderer.material.color;
        baseColor.a = 0f;
        renderer.material.color = baseColor;

        float alpha = 1.0f;
        while (true)
        {
            if (alpha < 0.0f)
            {
                break;
            }

            Color highlight = renderer.material.GetColor(HIGHLIGHT_COLOR);
            highlight.a = alpha;
            renderer.material.SetColor(HIGHLIGHT_COLOR, highlight);

            
            //baseColor.a = 0;
            //renderer.material.color = baseColor * 2;

            alpha -= (WaveSpeed / Size) * Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
    }

}
