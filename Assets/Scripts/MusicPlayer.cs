using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	// creates a singleton. So that there is only one music player throughut scene changes

    static MusicPlayer instance = null;

    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;

    private AudioSource music;

    void Start() { 
        Debug.Log ("Musis player Awake " + GetInstanceID());
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            print("Duplicate music plater self-destructing!");
        }
        else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            music.clip = startClip;
            music.loop = true;
            music.Play();
        }
    }
	
    void OnLevelWasLoaded(int level) {
        Debug.Log("MusicPlayer: loaded level" + level);
        music.Stop();

        if(level == 0)
        {
            music.clip = startClip;
        }
        if (level == 1)
        {
            music.clip = gameClip;
        }
        if (level == 2)
        {
            music.clip = endClip;
        }

        music.loop = true;
        music.Play();
    }

}
