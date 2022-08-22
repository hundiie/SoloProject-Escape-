using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    private MonsterAI _MonsterAI;
    private UIManager _UIManager;
    private WaveManager _WaveManager;
    private NavMeshAgent _NavMeshAgent;

    private float MoveSpeed; //{ get; private set; }
    private float light_Power;//{ get; private set; }
    [HideInInspector] public bool Move;
    [HideInInspector] public Vector3 SaveVector;

    private void Awake()
    {
        _MonsterAI = GetComponent<MonsterAI>();
        _UIManager = _MonsterAI.UIManager.GetComponent<UIManager>();
        _WaveManager = _MonsterAI.WaveManager.GetComponent<WaveManager>();
        _NavMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        MoveSpeed = _MonsterAI.MoveSpeed;
        light_Power = _MonsterAI.light_Power;
        _NavMeshAgent.speed = MoveSpeed;
        _NavMeshAgent.enabled = false;
         Move = false;
    }

    private bool foot = true;
    private float waveTime;

    private void Update()
    {
        waveTime += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if (Move)
        {
            if (waveTime >= 0.5f)
            {
                waveTime = 0f;
                foot = !foot;
                _UIManager.Setway(transform, foot, Color.red);
                _WaveManager.SetWave(gameObject.transform, light_Power, Color.red, "MonsterSound");
            }
            if (transform.position.x == SaveVector.x && transform.position.z == SaveVector.z)
            {
                Move = false;
                _NavMeshAgent.enabled = Move;
            }
        }
    }

    public void SetTaget(Vector3 vector)
    {
        Move = true;
        _NavMeshAgent.enabled = Move;
        _NavMeshAgent.SetDestination(vector);
    }
   
}
