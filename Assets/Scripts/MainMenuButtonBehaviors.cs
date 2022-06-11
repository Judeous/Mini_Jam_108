using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class MainMenuButtonBehaviors : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGameButtonOnClicked()
    {
        EditorSceneManager.LoadScene(sceneName:"GameScene");
    }
}
