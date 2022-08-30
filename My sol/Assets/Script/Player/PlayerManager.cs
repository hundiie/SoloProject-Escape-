using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerInput _PlayerInput;
    private SoundManager _SoundManager;
    private WaveManager _WaveManager;
    private UIManager _UIManager;
    private PlayerSave _PlayerSave;

    [Header("GameObject")]
    public GameObject SoundManager;
    public GameObject WaveManager;
    public GameObject UiManager;
    public GameObject CAMERA;
    public GameObject Step;

    [Header("Move")]
    public float moveSpeed;// { get; private set; }
    public float light_Delta;// { get; private set; }
    public float light_Power;// { get; private set; }

    [Header("Step")]
    public float SkilStep_light_Power;
    public float SkilStep_Cooltime;

    private bool Die;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _PlayerInput = GetComponent<PlayerInput>();
        _SoundManager = SoundManager.GetComponent<SoundManager>();
        _WaveManager = WaveManager.GetComponent<WaveManager>();
        _UIManager = UiManager.GetComponent<UIManager>();
        _PlayerSave = GetComponent<PlayerSave>();

        Skill_Step_Delta = SkilStep_Cooltime;
        Die = false;
    }
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * 1.05f, Color.green);
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
            {
                Step.SetActive(true);
                Step.transform.position = transform.position;
                StartCoroutine(LightPade());
            }

            Skill_Step_Delta = 0;
            _WaveManager.SetWave(gameObject.transform.position - new Vector3(0,2,0), SkilStep_light_Power, Color.white, WAVETAG.NOMALSOUND);
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
            _SoundManager.PlayWalkSound(TileSound, 1);
        }
    }

    private IEnumerator LightPade()
    {
        for (float i = 2; i > 0; i -= 0.5f *Time.deltaTime)
        {
            Step.GetComponent<Light>().intensity = i;

            yield return null;
        }
        Step.SetActive(false);
    }



    private void DIE()
    {
        _UIManager.Die(true);
        Die = true;
    }

    public void Resurrection()
    {
        Time.timeScale = 1f;
        transform.position = _PlayerSave.GetSavePoint();
        Die = false;
        _UIManager.Die(false);
    }
    GameObject SaveMonster;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster" && !Die)
        {
            collision.gameObject.GetComponent<MonsterAI>().comeback();
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
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2.2f))
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
