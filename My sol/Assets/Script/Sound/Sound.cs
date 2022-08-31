using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource _AudioSource;

    float delta;
    private void Update()
    {
        if (gameObject.activeSelf)
        {
            delta += Time.deltaTime;
        }
        if (delta >= 0.2f)
        {
            delta = 0;
            if (!_AudioSource.isPlaying)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
