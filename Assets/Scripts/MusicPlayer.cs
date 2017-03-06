using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	// creates a singleton. So that there is only one music player throughut scene changes

    static MusicPlayer instance = null;

    void Awake() { 
        Debug.Log ("Musis player Awake " + GetInstanceID());
        if (instance != null)
        {
            Destroy(gameObject);
            print("Duplicate music plater self-destructing!");
        }
        else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
	
}
