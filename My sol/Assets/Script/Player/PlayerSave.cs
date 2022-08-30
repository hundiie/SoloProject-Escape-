using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSave : MonoBehaviour
{
    private PlayerManager _PlayerManager;
    private UIManager _UIManager;

    private Vector3 SavePoint;

    private void Awake()
    {
        _PlayerManager = GetComponent<PlayerManager>();
        _UIManager = _PlayerManager.UiManager.GetComponent<UIManager>();

        SavePoint = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("SavePoint"))
        {
            other.gameObject.SetActive(false);
            SavePoint = other.transform.position;
            _UIManager.SetMainText("세이브 포인트를 갱신하였습니다.", 72);
        }
    }

    public Vector3 GetSavePoint()
    {
        return SavePoint;
    }
}
