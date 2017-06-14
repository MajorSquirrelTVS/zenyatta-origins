using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] 

public class PlayMovie : MonoBehaviour {

    public MovieTexture movie;
    private AudioSource source;

	// Use this for initialization
	void Start () {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        movie.Play();
        source.Play();
    }

    void Update()
    {
        if (!movie.isPlaying)
        {
            Debug.Log("movie end");
            transform.gameObject.SetActive(false);
        }
    }
}