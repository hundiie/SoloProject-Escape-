using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // ����� �ҽ� �����ؼ� �߰�
    private AudioSource _AudioSource;
    public List<AudioClip> _ClipList;

    private void Awake()
    {
        _AudioSource = gameObject.AddComponent<AudioSource>();

        //���ҽ��� �ִ� ���� ���� �ε�
        _ClipList = Resources.LoadAll("Sound", typeof(AudioClip)).OfType<AudioClip>().ToList();

    }
    public void PlaySound( int SoundNumber, float Volume)//Vector3 SoundPosition,
    {
        _AudioSource.volume = Volume;
        _AudioSource.PlayOneShot(_ClipList[SoundNumber]);
    }
}
