using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // 오디오 소스 생성해서 추가
    private AudioSource _AudioSource;
    public List<AudioClip> _ClipList;

    private void Awake()
    {
        _AudioSource = gameObject.AddComponent<AudioSource>();

        //리소스에 있는 사운드 전부 로드
        _ClipList = Resources.LoadAll("Sound", typeof(AudioClip)).OfType<AudioClip>().ToList();

    }
    public void PlaySound( int SoundNumber, float Volume)//Vector3 SoundPosition,
    {
        _AudioSource.volume = Volume;
        _AudioSource.PlayOneShot(_ClipList[SoundNumber]);
    }
}
