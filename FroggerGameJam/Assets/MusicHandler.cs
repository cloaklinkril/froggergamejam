using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        EventScript.current.onGoalReached += onGoalReached;
        EventScript.current.onGameWon += onGameWon;
        EventScript.current.onPlayerRunOver += onPlayerRunOver;
        EventScript.current.onRespawnAfterDeath += onRespawnAfterDeath;
        GetComponents<AudioSource>()[0].Play();
    }
    private void Update()
    {
        if(!start && !GetComponents<AudioSource>()[0].isPlaying)
        {
            GetComponents<AudioSource>()[1].Play();
            start = true;
        }
    }
    private void onGoalReached()
    {
        GetComponents<AudioSource>()[0].Stop();
        GetComponents<AudioSource>()[1].Stop();
        GetComponents<AudioSource>()[2].Play();
        start = true;
    }
    private void onGameWon()
    {
        GetComponents<AudioSource>()[0].Stop();
        GetComponents<AudioSource>()[1].Stop();
        GetComponents<AudioSource>()[2].Stop();
    }
    private void onPlayerRunOver()
    {
        start = true;
        Debug.Log("blah");
        GetComponents<AudioSource>()[0].Stop();
        GetComponents<AudioSource>()[1].Stop();
        GetComponents<AudioSource>()[2].Stop();
    }
    private void onRespawnAfterDeath()
    {
        GetComponents<AudioSource>()[2].Play();
    }
}
