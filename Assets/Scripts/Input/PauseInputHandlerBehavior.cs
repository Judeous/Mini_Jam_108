using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseInputHandlerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _pauseMenu;
    private bool _paused = false;

    private float _timeUntilPausePressAvailable = 0;

    public bool Paused
    {
        get { return _paused; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Decrease time until Pause is available
        _timeUntilPausePressAvailable -= Time.deltaTime;
        if (_timeUntilPausePressAvailable < 0)
            _timeUntilPausePressAvailable = 0;

        //Get pause input
        float pauseInput = Input.GetAxis("Cancel");

        //If pausing and not holding pause
        if (pauseInput == 1 && _timeUntilPausePressAvailable == 0)
        {
            if (_paused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
            //Reset duration
            _timeUntilPausePressAvailable = 0.25f;
        }
    }

    public void Unpause()
    {
        _pauseMenu.SetActive(false);
        _paused = false;
    }

    public void Pause()
    {
        _pauseMenu.SetActive(true);
        _paused = true;
    }
}
