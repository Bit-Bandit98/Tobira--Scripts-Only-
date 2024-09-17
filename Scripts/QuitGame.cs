using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    
    [SerializeField] private KeyCode QuitGameButton = KeyCode.Escape;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(QuitGameButton))
        {
            if(Application.platform != RuntimePlatform.WebGLPlayer) Application.Quit();
        }
    }
}
