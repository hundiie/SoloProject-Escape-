using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // ����� �ҽ� �����ؼ� �߰�
    private AudioSource _WalkAudioSource;
    private AudioSource _ScreamAudioSource;
    public List<AudioClip> _WalkClipList;
    public List<AudioClip> _ScreamClipList;

    private void Awake()
    {
        _WalkAudioSource = gameObject.AddComponent<AudioSource>();
        _ScreamAudioSource = gameObject.AddComponent<AudioSource>();
        //���ҽ��� �ִ� ���� ���� �ε�
        _WalkClipList = Resources.LoadAll("Sound", typeof(AudioClip)).OfType<AudioClip>().ToList();
        _ScreamClipList = Resources.LoadAll("Sound/Scream", typeof(AudioClip)).OfType<AudioClip>().ToList();
    }
    public void PlayWalkSound( int SoundNumber, float Volume)//Vector3 SoundPosition,
    {
        _WalkAudioSource.volume = Volume;
        _WalkAudioSource.PlayOneShot(_WalkClipList[SoundNumber]);
    }

    public void PlayScreamSound(int SoundNumber, float Volume)
    {
        _ScreamAudioSource.volume = Volume;
        _ScreamAudioSource.PlayOneShot(_ScreamClipList[SoundNumber]);
    }
}
