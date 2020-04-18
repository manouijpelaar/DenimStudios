using UnityEngine;
using UnityEngine.SceneManagement;

public class winTrigger : MonoBehaviour
{
    public GameObject player;

    //public GameObject completeLevelScreen;
    //public TargetVolgorde targetManager;

    void OnTriggerEnter(Collider win)
    {   // when player collides with winscene, level complete
        if (win.gameObject.tag == "Player")
        {
            player.GetComponent<CharMove>().enabled = false;
            SceneManager.LoadScene(3);
            Debug.Log("You Win!");
        }
    }
}
