using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System;
using QFSW.QC;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioManager instance;

    void Awake ()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.group;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.ignoreListenerPause = s.ignorePause;
        }
    }

    private void OnEnable()
    {
        EventManager.PanicSurvival += EscapeMusicToggle;
    }

    private void OnDisable()
    {
        EventManager.PanicSurvival -= EscapeMusicToggle;
    }

    [Command("play-audio")]
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " missing!");
            return;
        }
        s.source.Play();
    }

    [Command("stop-audio")]
    public void Stop (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " missing!");
            return;
        }
        s.source.Stop();
    }

    [Command("pause-audio")]
    public void PauseAudio(bool paused)
    {
        if (paused == true)
        {
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = false;
        }
    }

    private void EscapeMusicToggle(bool active)
    {
        if (active == true)
        {
            Play("EscapeMusic");
        }
        else
        {
            Stop("EscapeMusic");
        }
    }

}
