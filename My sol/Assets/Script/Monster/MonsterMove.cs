using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    private MonsterAI _MonsterAI;
    private UIManager _UIManager;
    private SoundManager _SoundManager;
    private WaveManager _WaveManager;
    private NavMeshAgent _NavMeshAgent;

    private float MoveSpeed; //{ get; private set; }
    private float light_Power;//{ get; private set; }
    [HideInInspector] public bool Move;
    [HideInInspector] public Vector3 SaveVector;

    private bool RUN;

    private void Awake()
    {
        _MonsterAI = GetComponent<MonsterAI>();
        _UIManager = _MonsterAI.UIManager.GetComponent<UIManager>();
        _SoundManager = _MonsterAI.SoundManager.GetComponent<SoundManager>();
        _WaveManager = _MonsterAI.WaveManager.GetComponent<WaveManager>();
        _NavMeshAgent = gameObject.GetComponent<NavMeshAgent>();

        MoveSpeed = _MonsterAI.MoveSpeed;
        light_Power = _MonsterAI.light_Power;
        _NavMeshAgent.speed = MoveSpeed;
        _NavMeshAgent.enabled = false;
        Move = false;
        RUN = true;
    }

    private bool foot = true;
    private float waveTime;

    private void Update()
    {
        waveTime += Time.deltaTime;

    }
    private void FixedUpdate()
    {
        float NewSpeed = MoveSpeed;
        float NewLight_Power = light_Power;
        int SoundNumber = 9;
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down * 2, Color.red);
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2))
        {
            switch (hit.collider.gameObject.tag)
            {
                case "NomalTile":
                    SoundNumber = 9;
                    break;
                case "WaterTile":
                    SoundNumber = 10;
                    NewSpeed *= 0.7f;
                    NewLight_Power *= 1.3f;
                    break;
                case "SoilTile":
                    SoundNumber = 11;
                    NewSpeed *= 0.7f;
                    NewLight_Power *= 0.6f;
                    break;
                default:
                    break;
            }
        }
        if (!RUN)
        {
            NewSpeed *= 0.3f;
        }
        _NavMeshAgent.speed = NewSpeed;

        if (Move)
        {
            if (waveTime >= 0.5f)
            {
                waveTime = 0f;
                foot = !foot;
                _UIManager.Setway(transform, foot, Color.red);
                _WaveManager.SetWave(gameObject.transform, NewLight_Power, Color.red, "MonsterSound");
                float Distance = Vector3.Distance(transform.position, GameObject.FindWithTag("PlayerPosition").gameObject.transform.position);
                
                if (Distance > 20f) { Distance = 20f; }
                if (Distance < 0f) { Distance = 0f; }
                Distance /= 20f;

                _SoundManager.PlaySound(SoundNumber,1 - Distance);
            }
            if (transform.position.x == SaveVector.x && transform.position.z == SaveVector.z)
            {
                Move = false;
                _NavMeshAgent.enabled = Move;
                _MonsterAI.StatusChange(STATE.STAY);
            }
        }
    }

    public void SetTaget(Vector3 vector, bool Run)
    {
        Move = true;
        RUN = Run;
        _NavMeshAgent.enabled = true;
        _NavMeshAgent.SetDestination(vector);
    }
   
}
