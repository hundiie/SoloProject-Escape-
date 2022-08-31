using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // ����� �ҽ� �����ؼ� �߰�
    private AudioSource[] _AudioSource = new AudioSource[20];
    public List<AudioClip> _WalkClipList;
    public List<AudioClip> _ScreamClipList;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            
            _AudioSource[i] = transform.GetChild(i).gameObject.AddComponent<AudioSource>();
            transform.GetChild(i).gameObject.GetComponent<Sound>()._AudioSource = _AudioSource[i];
            _AudioSource[i].loop = false;
            transform.GetChild(i).gameObject.SetActive(false);
        }

        //���ҽ��� �ִ� ���� ���� �ε�
        _WalkClipList = Resources.LoadAll("Sound", typeof(AudioClip)).OfType<AudioClip>().ToList();
        _ScreamClipList = Resources.LoadAll("Sound/Scream", typeof(AudioClip)).OfType<AudioClip>().ToList();
    }
    public void PlayWalkSound( int SoundNumber, float Volume)//Vector3 SoundPosition,
    {
        for (int i = 0; i < _AudioSource.Length; i++)
        {
            if (!transform.GetChild(i).gameObject.activeSelf)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                _AudioSource[i].volume = Volume;
                _AudioSource[i].clip = (_WalkClipList[SoundNumber]);
                _AudioSource[i].Play();
                return;
            }
        }
    }

    public void PlayScreamSound(int SoundNumber, float Volume)
    {
        for (int i = 0; i < _AudioSource.Length; i++)
        {
            if (!transform.GetChild(i).gameObject.activeSelf)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                _AudioSource[i].volume = Volume;
                _AudioSource[i].clip = (_ScreamClipList[SoundNumber]);
                _AudioSource[i].Play();
                return;
            }
        }
    }
}
