using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSound : MonoBehaviour
{
    public SoundManager _SoundManager;
    public WaveManager _WaveManager;

    public GameObject Player;
    private float deltaTime;

    public Color lightColor;
    public float delay;
    public float lightPower;
    public string Tag;

    private void Update()
    {
        float Distance = Vector3.Distance(transform.position, Player.transform.position);
        if (Distance <= 50)
        {
            SoundUpdate();
        }
        
    }

    private void SoundUpdate()
    {
        deltaTime += Time.smoothDeltaTime;

        if (deltaTime >= delay)
        {
            deltaTime = 0f;
            _WaveManager.SetWave(gameObject.transform, lightPower, lightColor, "NatureSound");
            float Distance = Vector3.Distance(transform.position, GameObject.FindWithTag("PlayerPosition").gameObject.transform.position);

            if (Distance > 20f) { Distance = 20f; }
            if (Distance < 0f) { Distance = 0f; }
            Distance /= 20f;

            _SoundManager.PlaySound(12, 1 - Distance);
        }
    }
    public void _SetMapSound(float Delay, float LightPower, Color LightColor, string tag)
    {
        delay = Delay;
        lightPower = LightPower;
        lightColor = LightColor;
        Tag = tag;
    }

}
