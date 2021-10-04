using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
   


    private void Awake()
    {
        int numberOfMusicPlayerScript = FindObjectsOfType<MusicPlayer>().Length;
        if (numberOfMusicPlayerScript > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        // * This is a when we started
       
        
           // DontDestroyOnLoad(this);
            audioSource = GetComponent<AudioSource>();
            // We are saying the sound of our music should be okaying at whatever the masterVolume are.
            audioSource.volume = PlayerPrefsController.GetMasterVolume();
            
            
    }
        
       

   // Now we want to create another method so that we can set the volume from our other scenes or other scripts or other classes
   // * This is a something else can change it
   public void SetVolume(float volume)
   {
        audioSource.volume = volume;
   }
    // Attach this script into our MusicPlayer GameObject
}

// + What is DontDestroyOnLoad? DontDestroyOnLoad refers to game objects only. Game objects don't have anything to do with C#.
// + They are concepts of the Unity framework. A game object is an object existing in a scene. Usually, Unity destroys all objects when it loads a new scene.


// # What is static? Static classes are great for general concepts like, for example, maths. To calculate something, you need values which you can process. 
// # You do not store any data, and you do not need individual instances  as there are no two maths. And the class does not have to be inside a Unity scene.