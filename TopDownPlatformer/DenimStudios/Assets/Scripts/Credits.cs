using UnityEngine;

public class Credits : MonoBehaviour
{
    // Mouse arrow is visible on screen
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // When quit button is pressed the game will shut down.
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    
}
