using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class changes the song that plays when transitioning to a new scene.
public class NewSongOnLoad : MonoBehaviour
{
    [SerializeField] private AudioClip NewSong;


    private void Start()
    {
        MusicPlayer Music = FindObjectOfType<MusicPlayer>();

        if(Music != null)
        {
            Music.PlayNewMusic(NewSong);
        }
    }

}
