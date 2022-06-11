using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandlerBehavior : MonoBehaviour
{
    [SerializeField] private HarpoonClass _harpoon;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _pauseMenu;

    
    private float _timeShootHeld = 0;
    private float _timeBeforeShootMoves = 0.1f;
    private bool _shootheld = false;

    private bool _paused = false;
    private bool _holdingPause = false;

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

        //Get pause input
        float pauseInput = Input.GetAxis("Cancel");
        float shootInput = Input.GetAxis("Fire1");

        if (shootInput != 0)
        {
            _timeShootHeld += Time.deltaTime;
            if (!_shootheld && _timeShootHeld < _timeBeforeShootMoves)
            {
                _harpoon.ShootForward();
            }
            _shootheld = true;
            
        }
        else
        {
            _shootheld = false;
            _timeShootHeld = 0;
        }

        //If pausing and not holding pause
        if (pauseInput == 1)
        {
            if (!_holdingPause)
            {
                if (_paused)
                {
                    Unpause();
                }
                else
                {
                    Pause();
                }
            }
            _holdingPause = true;
        }
        else
        {
            _holdingPause = false;
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
