using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerInput _PlayerInput;
    private SoundManager _SoundManager;
    private WaveManager _WaveManager;
    private UIManager _UIManager;

    [Header("GameObject")]
    public GameObject SoundManager;
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
        _SoundManager = SoundManager.GetComponent<SoundManager>();
        _WaveManager = WaveManager.GetComponent<WaveManager>();
        _UIManager = UiManager.GetComponent<UIManager>();
        Skill_Step_Delta = 5;
    }
    void Update()
    {
        Skill_Step_Delta += Time.deltaTime;
        PauseTime += Time.deltaTime;



    }
    float PauseTime;
    private void FixedUpdate()
    {
        if (_PlayerInput.Key_R)
        {
            Skll_Step(Skill_Step_Delta);
        }

        if (_PlayerInput.Key_Esc && PauseTime >= 0.1f)
        {
            _UIManager.Pause(true);
            PauseTime = 0f;
        }
    }


    private float Skill_Step_Delta;
    private void Skll_Step(float Cooltime)
    {
        if (Cooltime > SkilStep_Cooltime)
        {
            Skill_Step_Delta = 0;
            _WaveManager.SetWave(gameObject.transform, SkilStep_light_Power, Color.white,"NomalSound");
            _UIManager.Skill(SkilStep_Cooltime);
            int TileSound = 0;

            switch (GetTile())
            {
                case 1:
                    TileSound = 1;
                    break;
                case 2:
                    TileSound = 4;
                    break;
                case 3:
                    TileSound = 7;
                    break;
                default:
                    break;
            }
            _SoundManager.PlaySound(TileSound, 1);
        }
    }

    private void DIE()
    {
        _UIManager.Die(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Debug.Log("Á×À½");
            DIE();
        }
    }

    /// <summary>
    /// 1 = Nomal
    /// 2 = Water
    /// 3 = Sand
    /// </summary>
    /// <returns></returns>
    public int GetTile()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down * 2, Color.gray);
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2))
        {
            switch (hit.collider.gameObject.tag)
            {
                case "NomalTile":
                    return 1;
                case "WaterTile":
                    return 2;
                case "SoilTile":
                    return 3;
                default:
                    break;
            }
        }
        return 0;
    }
}
