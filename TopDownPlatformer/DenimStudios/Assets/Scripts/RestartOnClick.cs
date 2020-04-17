using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartOnClick : MonoBehaviour
{
    public void Restart()
    {
        // loads current scene
        SceneManager.LoadScene(GameManager.levelIndex);
    }

}
