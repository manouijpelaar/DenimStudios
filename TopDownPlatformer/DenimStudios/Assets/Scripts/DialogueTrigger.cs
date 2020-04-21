using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject player;
    public GameObject platform;
    private void Start()
    {
        platform.GetComponent<MeshCollider>().isTrigger = true;
        player.GetComponent<CharMove>().enabled = true;
    }

    // when player collides with object dialogue will be triggered
    void OnTriggerEnter(Collider texttrigger)
    {   
        if (texttrigger.gameObject.tag == "Player")
        {
            player.GetComponent<CharMove>().enabled = false;
            platform.GetComponent<MeshCollider>().isTrigger = false;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            Debug.Log("starting conversation");
        }
    }
}
