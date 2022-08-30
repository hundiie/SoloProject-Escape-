using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerManager _PlayerManager;
    private PlayerInput _PlayerInput;
    private SoundManager _SoundManager;
    private WaveManager _WaveManager;
    private UIManager _UIManager;
    
    private GameObject CAMERA;

    private float moveSpeed;
    private float light_Delta;
    private float light_Power;

    private void Awake()
    {
        _PlayerManager = GetComponent<PlayerManager>();
        _PlayerInput = GetComponent<PlayerInput>();
        _WaveManager = _PlayerManager.WaveManager.GetComponent<WaveManager>();
        _UIManager = _PlayerManager.UiManager.GetComponent<UIManager>();
        _SoundManager = _PlayerManager.SoundManager.GetComponent<SoundManager>();

        CAMERA = GetComponent<PlayerManager>().CAMERA;
        moveSpeed = _PlayerManager.moveSpeed;
        
        light_Delta = _PlayerManager.light_Delta;
        light_Power = _PlayerManager.light_Power;
    }

    void FixedUpdate()
    {
        if (_PlayerInput.X != 0 || _PlayerInput.Z != 0)
        {
            playerMove(_PlayerInput.X, _PlayerInput.Z);
        }
    }
    private float waveTime;
    private void Update()
    {
        waveTime += Time.deltaTime;
    }

    private void CameraView()
    {
        transform.forward = new Vector3(CAMERA.transform.forward.x, 0f, CAMERA.transform.forward.z).normalized;
    }

    private bool foot = true;
    private void playerMove(float X, float Z)
    {
        CameraView();
        
        float NewSpeed = moveSpeed;
        float Newlight_Power = light_Power;
        int SoundNumber = 0;
        Color color = Color.white;
        int TileCheck = _PlayerManager.GetTile();
        switch (TileCheck)
        {
            case 1:
                color = Color.white; SoundNumber = 0;
                break;
            case 2:
                color = Color.blue; SoundNumber = 3;
                NewSpeed *= 0.7f;
                Newlight_Power *= 1.3f;
                break;
            case 3:
                color = Color.yellow; SoundNumber = 6;
                NewSpeed *= 0.7f;
                Newlight_Power *= 0.7f;
                break;
            default:
                break;
        }

        float PlayerSoundVolume = 1;
        if (_PlayerInput.Key_Shift)
        {
            NewSpeed = moveSpeed * 0.5f;
            Newlight_Power = light_Power * 0.5f;
            PlayerSoundVolume = 0.5f;
        }
        
        if (waveTime >= light_Delta && TileCheck != 0)
        {
            waveTime = 0f;
            foot = !foot;
            _UIManager.Setway(transform, foot, color);
            _WaveManager.SetWave(gameObject.transform.position - new Vector3(0, 2, 0), Newlight_Power, color, WAVETAG.NOMALSOUND) ;
            _SoundManager.PlayWalkSound(SoundNumber, PlayerSoundVolume);
        }

        transform.Translate(X * NewSpeed * Time.deltaTime, 0, Z * NewSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            //Á×À½
           // _UIManager.PlayRed();
        }
    }
}
