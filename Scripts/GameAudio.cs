using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public AudioSource asSound;

    public AudioClip scoreSound;

    public AudioClip winSound;


    public void PlayScoreSound()
    {
        asSound.PlayOneShot (scoreSound);
    }

    public void PlayWinSound()
    {
        asSound.PlayOneShot (winSound);
    }
}
