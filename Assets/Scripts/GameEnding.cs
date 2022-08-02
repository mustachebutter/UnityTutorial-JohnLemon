using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 1.0f;
    [SerializeField] private float displayImageDuration = 1.0f;
    [SerializeField] private GameObject player;
    [SerializeField] private CanvasGroup exitBackgroundImageCG;
    [SerializeField] private CanvasGroup caughtBackgroundImageCG;
    [SerializeField] private AudioSource exitAudio;
    [SerializeField] private AudioSource caughtAudio;
    private bool _isPlayerEnteredExit;
    private bool _isPlayerCaught;
    private bool _isAudioPlayed;
    private float _timer;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject == player) 
        {
            _isPlayerEnteredExit = true;
        }
    }

    private void Update() 
    {
        if(_isPlayerEnteredExit) 
        {
            EndLevel(exitBackgroundImageCG, false, exitAudio);
        }
        else if (_isPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCG, true, caughtAudio);
        }
    }

    private void EndLevel(CanvasGroup imageCanvasGroup, bool shouldRestart, AudioSource soundToPlay)
    {
        if(!_isAudioPlayed)
        {
            soundToPlay.Play();
            _isAudioPlayed = true;
        }

        _timer += Time.deltaTime;
        imageCanvasGroup.alpha = _timer / fadeDuration;

        if(_timer > fadeDuration + displayImageDuration)
        {
            if(shouldRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }
    
    public void CaughtPlayer()
    {
        _isPlayerCaught = true;
    }
}