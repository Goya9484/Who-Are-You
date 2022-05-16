using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    AudioSource playSource;
    private float randomTime;

    private void Start()
    {
        playSource = this.GetComponent<AudioSource>();
        randomTime = Random.Range(1.0f, 20.0f);
        StartCoroutine("RandomAudio");
    }

    IEnumerator RandomAudio()
    {
        while(true)
        {
            yield return new WaitForSeconds(randomTime);
            playSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            playSource.Play();
            yield return new WaitForSeconds(30);
        }
    }
}
