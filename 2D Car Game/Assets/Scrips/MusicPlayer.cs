using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // This will be called even before start()
    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        //the GetType() will get the type object that is attaced to this script: Music Player
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            //This will destroy the previous one if there are more than one MusicPlayer
            Destroy(gameObject);
        }
        else
        {
            //The music player wont be destroted when chnaging scenes
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
