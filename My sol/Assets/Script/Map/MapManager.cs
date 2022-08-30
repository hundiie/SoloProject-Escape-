using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private WaveManager _WaveManager;

    [Header("GameObject")]
    public GameObject SoundManager;
    public GameObject WaveManager;
    public GameObject Player;
    [Header("ObjectSound")]
    public GameObject[] WaterSound = new GameObject[0];

    private void Awake()
    {
        _WaveManager = WaveManager.GetComponent<WaveManager>();
        for (int i = 0; i < WaterSound.Length; i++)
        {
            SetMapSound(WaterSound[i], Random.Range(2f,6f), 15, Color.blue,"NatureSound");
        }
    }

    void SetMapSound(GameObject Object, float DeltaTime, float LightPower, Color LightColor, string tag)
    {
        Object.AddComponent<MapSound>()._SetMapSound(DeltaTime, LightPower, LightColor, tag);
        Object.GetComponent<MapSound>()._SoundManager = SoundManager.GetComponent<SoundManager>();
        Object.GetComponent<MapSound>()._WaveManager = _WaveManager;
        Object.GetComponent<MapSound>().Player = Player;
    }

}
