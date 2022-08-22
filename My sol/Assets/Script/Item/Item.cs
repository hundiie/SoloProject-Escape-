using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private WaveManager _WaveManager;

    [Header("GameObject")]
    public GameObject WaveManager;

    [Header("Item")]
    public float LightPower;

    private void Awake()
    {
        _WaveManager = WaveManager.GetComponent<WaveManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Color color = Color.black;
        float Newlight_Power = LightPower;
        switch (collision.gameObject.tag)
        {
            case "NomalTile":
                {
                    color = Color.white;
                }
                break;
            case "WaterTile":
                {
                    color = Color.blue;
                    Newlight_Power += 2;
                }
                break;
            case "SoilTile":
                {
                    color = Color.yellow;
                    Newlight_Power -= 0.5f;
                }
                break;
            default:
                break;
        }
        if(color != Color.black)
        {
            _WaveManager.SetWave(gameObject.transform, Newlight_Power, color, "NomalSound");
        }
    }
}
