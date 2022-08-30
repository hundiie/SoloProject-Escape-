using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPatrol : MonoBehaviour
{
    MonsterAI _MonsterAI;

    public GameManager Move1;
    public GameManager Move2;

    private void Awake()
    {
        _MonsterAI = GetComponent<MonsterAI>();
    }
    private void Update()
    {
        if (_MonsterAI.getState() == STATE.STAY)
        {
            int ran = Random.Range(0, 2);
            switch (ran)
            {
                case 0:
                    _MonsterAI.TagetOn(Move2.transform.position);
                    break;
                case 1:
                    _MonsterAI.TagetOn(Move1.transform.position);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_MonsterAI.getState() == STATE.STAY)
        {
            if (other.gameObject == Move1)
            {
                _MonsterAI.TagetOn(Move2.transform.position);
            }

            if (other.gameObject == Move2)
            {
                _MonsterAI.TagetOn(Move1.transform.position);
            }
        }
    }


}
