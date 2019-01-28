using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Audio_Manager : MonoBehaviour
{

    public Sound[] sounds;
    public static Audio_Manager instance;
    int buildIndex;
    AudioSource currentTrack;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.output;
        }
    }

    void Start()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        PlaySong(buildIndex);
    }

    void Update()
    {
        if (buildIndex != SceneManager.GetActiveScene().buildIndex)
        {
            currentTrack.Stop();
            buildIndex = SceneManager.GetActiveScene().buildIndex;
            PlaySong(buildIndex);
        }
        if (PauseMenu.gameIsPaused){
            Pause();
        } 
        else {
            ResumeTrack();
        }

    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " Not found!");
            return;
        }
        s.source.Play();
    }

    public void PlaySong(int buildIndex)
    {
        Sound s = Array.Find(sounds, sound => sound.levelIndex == buildIndex);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " Not found!");
            return;
        }
        s.source.Play();
        currentTrack = s.source;
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " Not found!");
            return;
        }
        s.source.Stop();
    }

    public void Pause () 
    {
        currentTrack.Pause();
    }

    void ResumeTrack (){
        currentTrack.UnPause();
    }
}
