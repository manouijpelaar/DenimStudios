using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager manager;
    [SerializeField]
    public static int levelIndex;

    /*void Start()
    {
        StartCoroutine(Countdown(3));
        GameObject musicObject = GameObject.FindGameObjectWithTag("Music");
        if (musicObject != null)
        {
            musicObject.GetComponent<MusicClass>().StopMusic();
        }
        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<CharacterController>().enabled = false;
        
    }*/

    // Singleton gamemanager for every script.
    public static GameManager Manager
    {
        get
        {
            if (manager == null)
                manager = FindObjectOfType<GameManager>();

            return manager;
        }
    }

    /*IEnumerator Countdown(int seconds)
    {
        int count = seconds;

        while (count > 0)
        {

            // Display something...
            yield return new WaitForSeconds(1);
            count--;
            CountDown.text = count.ToString();
        }

        // Count down is finished...
       // StartGame();
    }*/

    /*void StartGame()
    {
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<Rigidbody>().useGravity = true;
        CountDown.enabled = false;
        Manager.GetComponent<TimerCountUp>().enabled = true;
    }*/
}
