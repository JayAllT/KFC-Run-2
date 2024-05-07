using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Audio;

public class Music : MonoBehaviour
{
    [SerializeField] AudioClip[] songs;
    [SerializeField] AudioSource source;

    private int oldSong = 0;
    private int song = 0;

    private bool toggle = true;

    void Awake()
    {
        while (song == oldSong)
        {
            song = Random.Range(0, 6);
        }
        source.clip = songs[Random.Range(0, 6)];  // play a random song
        source.Play();

        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Music");
        if (musicObj.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (!source.isPlaying)
            NewSong();

        if (Input.GetKeyDown("m"))
        {
            toggle = !toggle;
            source.mute = !toggle;
        }
    }

    void NewSong()
    {
        while (song == oldSong)
        {
            song = Random.Range(0, 6);
        }
        source.clip = songs[song];  // play a random song
        source.Play();

        oldSong = song;
    }
}
