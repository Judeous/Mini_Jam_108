using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehavior : MonoBehaviour
{
    private InputHandlerBehavior _pauseInput;
    [SerializeField] private AudioSource _gameplayAudioSource;
    [SerializeField] private AudioSource _pausedAudioSource;
    [SerializeField] private AudioSource _MainMenuAudioSource;

    [SerializeField] private bool _isMainMenu = false;
    private bool _canPause = true;
    private bool _paused = false;
    
    public bool Paused
    {
        get { return _paused; }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!_isMainMenu)
        {
            _pauseInput = GetComponent<InputHandlerBehavior>();
            _canPause = _pauseInput ? true : false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If this is the main menu, don't do the rest of the Update
        if (_isMainMenu)
            return;

        //Update Paused if this can pause
        if (_canPause)
            _paused = _pauseInput.Paused;

        //If the game is paused
        if (_paused)
        {
            //Pause the Gameplay music and play the Pause music
            //_gameplayAudioSource.Pause();
            //_pausedAudioSource.UnPause();

            if (_gameplayAudioSource)
                _gameplayAudioSource.mute = true;
            if (_pausedAudioSource)
                _pausedAudioSource.mute = false;
        }
        else
        {
            //If the Gameplay music is not already playing, play it
            //_gameplayAudioSource.UnPause();
            //_pausedAudioSource.Pause();

            if (_gameplayAudioSource)
                _gameplayAudioSource.mute = false;
            if (_pausedAudioSource)
                _pausedAudioSource.mute = true;
        }
    }

    public void ChangeVolume(float value)
    {
        if (_MainMenuAudioSource != null)
            _MainMenuAudioSource.volume = value;
        
        if (_gameplayAudioSource != null)
            _gameplayAudioSource.volume = value;
        if (_pausedAudioSource != null)
            _pausedAudioSource.volume = value;
    }
}
