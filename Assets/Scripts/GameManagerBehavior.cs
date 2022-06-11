using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehavior : MonoBehaviour
{
    private InputHandlerBehavior _pauseInput;
    [SerializeField] private AudioSource _gameplayAudioSource;
    [SerializeField] private AudioSource _pausedAudioSource;
    private bool _paused = false;
    
    public bool Paused
    {
        get { return _paused; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _pauseInput = GetComponent<InputHandlerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update Paused
        _paused = _pauseInput.Paused;

        //If the game is paused
        if (_paused)
        {
            //Pause the Gameplay music and play the Pause music
            //_gameplayAudioSource.Pause();
            //_pausedAudioSource.UnPause();

            _gameplayAudioSource.mute = true;
            _pausedAudioSource.mute = false;
        }
        else
        {
            //If the Gameplay music is not already playing, play it
            //_gameplayAudioSource.UnPause();
            //_pausedAudioSource.Pause();

            _gameplayAudioSource.mute = false;
            _pausedAudioSource.mute = true;
        }
    }
}
