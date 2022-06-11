using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UnpauseButtonBehavior : MonoBehaviour
{
    private Button _button;
    private PauseInputHandlerBehavior _pauseBehavior;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Unpause()
    {
        _pauseBehavior.Unpause();
    }
}
