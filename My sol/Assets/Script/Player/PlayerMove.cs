using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerManager _PlayerManager;
    private PlayerInput _PlayerInput;
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
        Color color = Color.white;

        RaycastHit hit;
        Vector3 DownPosition = transform.GetChild(0).transform.forward;
        Debug.DrawRay(transform.position, DownPosition * 2, Color.red);
        if (Physics.Raycast(transform.position, DownPosition, out hit, 2))
        {
            switch (hit.collider.gameObject.tag)
            {
                case "NomalTile": color = Color.white;
                    break;
                case "WaterTile": color = Color.blue;
                    NewSpeed -= 1;
                    Newlight_Power += 2;
                    break;
                case "SoilTile": color = Color.yellow;
                    NewSpeed -= 0.5f;
                    Newlight_Power -= 0.5f;
                    break;
                default:
                    break;
            }
        }


        if (_PlayerInput.Key_Shift)
        {
            NewSpeed = moveSpeed * 0.3f;
            Newlight_Power = light_Power * 0.3f;
        }

        if (waveTime >= light_Delta)
        {
            waveTime = 0f;
            foot = !foot;
            _UIManager.Setway(transform, foot, color);
            _WaveManager.SetWave(gameObject.transform, Newlight_Power,color, "NomalSound");
        }

       
            //���߿� �� �Ʒ� ���̽��� �߾Ʒ� ��, ��, �� ����

            transform.Translate(X * NewSpeed * Time.deltaTime, 0, Z * NewSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            //����
           // _UIManager.PlayRed();
        }
    }
}
