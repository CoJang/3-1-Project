using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class MovieScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        Handheld.PlayFullScreenMovie("OP.mp4", Color.black, FullScreenMovieControlMode.Full);
    }

    // Update is called once per frame
    void Update ()
    {
        Invoke("GoToNextScene", 0.0f);
	}

    private void GoToNextScene()
    {
        SceneManager.LoadScene("stage 1");
    }
}
