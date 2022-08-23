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

    [Header("GameObject")]
    public GameObject SoundManager;
    public GameObject WaveManager;
    public GameObject UIManager;


    [Header("Move")]
    public float MoveSpeed; //{ get; private set; }
    public float light_Power;//{ get; private set; }

    //[Header("Patrol")]
    //public GameObject[] PatrolTaget = new GameObject[0];

    private void Awake()
    {
        _SoundManager = SoundManager.GetComponent<SoundManager>();
        _WaveManager = WaveManager.GetComponent<WaveManager>();
        _UIManager = UIManager.GetComponent<UIManager>();
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
    private void UpdateStay()
    {
        StayTime += Time.deltaTime;
        if (StayTime >= 5.0f)
        {
            StayTime = 0f;
            _WaveManager.SetWave(gameObject.transform, light_Power, Color.red, "MonsterSound");
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
    /*
    private IEnumerator PATROL()
    {
        Debug.Log($"{gameObject.name} : PATROL 상태 시작");
        
        GetComponent<MonsterMove>().SetTaget(PatrolTaget[Random.Range(0, PatrolTaget.Length)].transform.position, false);
        while (true)
        {
            //yield return new WaitForSeconds(3f);
            yield break;
        }
    }
    */
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
            StatusChange(STATE.MOVE);
            GetComponent<MonsterMove>().SaveVector = other.transform.position;
            GetComponent<MonsterMove>().SetTaget(other.transform.position,true);
        }
    }
    
    
}
