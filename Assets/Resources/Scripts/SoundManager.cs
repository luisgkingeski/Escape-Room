﻿using UnityEngine;

public class SoundManager : SingletonMonobehaviour<SoundManager>
{
    public AudioSource puzzle1;
    public AudioSource puzzle2;
    public AudioClip puzzle2Click, puzzle2Fail;
    public AudioSource walk;
    public AudioSource puzzle4;

    private bool isWalking = false;

    private void Update()
    {
        WalkSounds();
    }

    private void WalkSounds()
    {
        if (!isWalking)
        {
            if (Input.GetKeyDown(KeyCode.W) ||
              Input.GetKeyDown(KeyCode.A) ||
              Input.GetKeyDown(KeyCode.S) ||
              Input.GetKeyDown(KeyCode.D))
            {
                isWalking = true;
                walk.Play();
            }
        }
        else
        {
            if (!Input.GetKey(KeyCode.W) &&
             !Input.GetKey(KeyCode.A) &&
             !Input.GetKey(KeyCode.S) &&
             !Input.GetKey(KeyCode.D))
            {
                isWalking = false;
                walk.Stop();
            }
        }

        if(Time.timeScale == 0)
        {
            isWalking = false;
            walk.Stop();
        }


    }

    public void PlayPuzzle1Sound()
    {
        puzzle1.PlayOneShot(puzzle1.clip);
    }

    public void PlayPuzzle2SoundClick()
    {
        puzzle2.PlayOneShot(puzzle2Click);
    }

    public void PlayPuzzle2SoundFail()
    {
        puzzle2.PlayOneShot(puzzle2Fail);
    }

    public void PlayPuzzle4Sound()
    {
        puzzle4.PlayOneShot(puzzle4.clip);
    }

}
