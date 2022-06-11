using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehavior : MonoBehaviour
{
    private InputHandlerBehavior _pauseInput;

    // Start is called before the first frame update
    void Start()
    {
        _pauseInput = GetComponent<InputHandlerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;

        //if (_pauseInput.Paused)
        //    Time.timeScale = 0.00001f;
        //else
        //    Time.timeScale = 1;
    }
}
