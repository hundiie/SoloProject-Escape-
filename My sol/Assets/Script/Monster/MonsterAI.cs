using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATE
{
    STAY,
    MOVE,
}


public class MonsterAI : MonoBehaviour
{
    public STATE State { get; private set; }

    [Header("GameObject")]
    public GameObject UIManager;
    public GameObject WaveManager;

    private UIManager _UIManager;
    private WaveManager _WaveManager;

    [Header("Move")]
    public float MoveSpeed; //{ get; private set; }
    public float light_Power;//{ get; private set; }

    private void Awake()
    {
        _UIManager = UIManager.GetComponent<UIManager>();
        _WaveManager = WaveManager.GetComponent<WaveManager>();
    }

    private void FixedUpdate()
    {
        switch (State)
        {
            case STATE.STAY:
                break;
            case STATE.MOVE:
                break;
            default:
                break;
        }
    }

    private IEnumerator STAY()
    {
        while (true)
        {
            _WaveManager.SetWave(gameObject.transform, light_Power, Color.red, "MonsterSound");
            if (State != STATE.STAY)
            {
                yield return null;

            }
            yield return new WaitForSeconds(5f);
        }
    }

    private IEnumerator MOVE()
    {
        while (true)
        {
            if (State != STATE.MOVE)
            {
                yield return null;
            }
            yield return new WaitForSeconds(3f);


        }
    }

    private void StatusChange()
    {
        switch (State)
        {
            case STATE.STAY:StartCoroutine(STAY());
                break;
            case STATE.MOVE:StartCoroutine(MOVE());
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NomalSound")
        {
            GetComponent<MonsterMove>().SaveVector = other.transform.position;
            GetComponent<MonsterMove>().SetTaget(other.transform.position);
        }
    }
    
    
}
