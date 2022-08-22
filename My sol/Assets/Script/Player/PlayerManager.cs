using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerInput _PlayerInput;
    private WaveManager _WaveManager;

    [Header("GameObject")]
    public GameObject WaveManager;
    public GameObject UiManager;
    public GameObject CAMERA;

    [Header("Move")]
    public float moveSpeed;// { get; private set; }
    public float light_Delta;// { get; private set; }
    public float light_Power;// { get; private set; }

    [Header("Step")]
    public float SkilStep_light_Power;
    public float SkilStep_Cooltime;

    private void Awake()
    {
        _PlayerInput = GetComponent<PlayerInput>();
        _WaveManager = WaveManager.GetComponent<WaveManager>();
    }

    void Update()
    {
        Skill_Step_Delta += Time.deltaTime;

        if (_PlayerInput.Key_R)
        {
            Skll_Step(Skill_Step_Delta);
        }
    }

    private float Skill_Step_Delta;
    private void Skll_Step(float Cooltime)
    {
        if (Cooltime > SkilStep_Cooltime)
        {
            Skill_Step_Delta = 0;
            _WaveManager.SetWave(gameObject.transform, SkilStep_light_Power, Color.white,"NomalSound");
        }
    }
}
