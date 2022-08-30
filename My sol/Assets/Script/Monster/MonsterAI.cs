using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATE
{
    None,
    STAY,
    MOVE
    //PATROL
}

public class MonsterAI : MonoBehaviour
{
    public STATE State;
    public STATE prevState = STATE.None;

    private SoundManager _SoundManager;
    private WaveManager _WaveManager;
    private UIManager _UIManager;

    public Vector3 SavePosition;
    [Header("Move")]
    public float MoveSpeed; //{ get; private set; }
    public float light_Power;//{ get; private set; }

    //[Header("Patrol")]
    //public GameObject[] PatrolTaget = new GameObject[0];

    private void Awake()
    {
        SavePosition = transform.position;
           _SoundManager = GameObject.FindWithTag("SoundManager").gameObject.GetComponent<SoundManager>();
        _WaveManager = GameObject.FindWithTag("WaveManager").gameObject.GetComponent<WaveManager>();
        _UIManager = GameObject.FindWithTag("UIManager").gameObject.GetComponent<UIManager>();
        StatusChange(STATE.STAY);
    }

    private void FixedUpdate()
    {
        switch (State)
        {
            case STATE.STAY: UpdateStay(); break;
            case STATE.MOVE: UpdateMove(); break;
            //case STATE.PATROL: UpdatePatrol(); break;
        }
    }
    float StayTime;
    float SoundTime;
    private void UpdateStay()
    {
        StayTime += Time.deltaTime;
        SoundTime += Time.deltaTime;
        if (StayTime >= 2.0f)
        {
            StayTime = 0f;
            _WaveManager.SetWave(gameObject.transform.position, light_Power, Color.red, WAVETAG.MONSTERSOUND);

        }
        if (SoundTime >= 5.0f)
        {
            SoundTime = 0f;
            float Distance = Vector3.Distance(transform.position, GameObject.FindWithTag("PlayerPosition").gameObject.transform.position);

            if (Distance > 40f) { Distance = 40f; }
            if (Distance < 0f) { Distance = 0f; }
            Distance /= 40f;
            _SoundManager.PlayScreamSound(0, (1 - Distance) / 2);

        }
    }
    private void UpdateMove()
    {

    }
    private IEnumerator STAY()
    {
        Debug.Log($"{gameObject.name} : STAY 상태 시작");
        
        //while (true)
        {
            int Ran = Random.Range(0, 5);
            if (Ran >= 2)
            {
                //StatusChange(STATE.PATROL);
            }
            //yield return new WaitForSeconds(3f);
            yield break;
        }
    }

    private IEnumerator MOVE()
    {
        Debug.Log($"{gameObject.name} : MOVE 상태 시작");
        //while (true)
        {
            //yield return new WaitForSeconds(3f);
            yield break;
        }
    }

    public void StatusChange(STATE nextState)
    {
        if (prevState == nextState) return;
        StopAllCoroutines();

        prevState = State;
        State = nextState;

        switch (State)
        {
            case STATE.STAY: StartCoroutine(STAY()); break;
            case STATE.MOVE: StartCoroutine(MOVE()); break;
            //case STATE.PATROL: StartCoroutine(PATROL()); break;
            default:break;
        }
    }

    public void comeback()
    {
        transform.position = SavePosition;
        TagetOn(SavePosition);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NomalSound")
        {
            //RaycastHit hit;
            //Debug.DrawRay(transform.position, other.transform.position * 2, Color.red);
            //if (Physics.Raycast(transform.position, other.transform.position, out hit))
            //{
            //    if (hit.collider.gameObject.tag == "Player")
            //    {

            //    }
            //}
            TagetOn(other.gameObject.transform.position);
        }
    }
    public STATE getState()
    {
        return State;
    }

    public void TagetOn(Vector3 Obj)
    {
        StatusChange(STATE.MOVE);
        GetComponent<MonsterMove>().SaveVector = Obj;
        GetComponent<MonsterMove>().SetTaget(Obj, true);
    }
}
