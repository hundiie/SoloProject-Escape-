using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private WaveManager _WaveManager;
    private SoundManager _SoundManager;

    [HideInInspector] public GameObject Player;

    [Header("Item")]
    public float LightPower;

    private void Awake()
    {
        _SoundManager = GameObject.FindWithTag("SoundManager").gameObject.GetComponent<SoundManager>();
        _WaveManager = GameObject.FindWithTag("WaveManager").gameObject.GetComponent<WaveManager>();
        Player = GameObject.FindWithTag("PlayerPosition");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Color color = Color.black;
        float Newlight_Power = LightPower;
        int SoundNumber = 2;
        switch (collision.gameObject.tag)
        {
            case "NomalTile":
                {
                    color = Color.white;
                    SoundNumber = 2;
                }
                break;
            case "WaterTile":
                {
                    color = Color.blue;
                    Newlight_Power *= 1.3f;
                    SoundNumber = 5;
                }
                break;
            case "SoilTile":
                {
                    color = Color.yellow;
                    Newlight_Power *= 0.7f;
                    SoundNumber = 8;
                }
                break;
            default:
                break;
        }
        if(color != Color.black)
        {
            _WaveManager.SetWave(gameObject.transform, Newlight_Power, color, WAVETAG.NOMALSOUND);
            if (Player != null)
            {
                float Distance = Vector3.Distance(transform.position, Player.transform.position);
                if (Distance > 20f){ Distance = 20f; }
                if (Distance < 0f)  { Distance = 0f; }
                Distance /= 20f;
                _SoundManager.PlayWalkSound(SoundNumber, 1 - Distance);
            }

        }
    }
}
