using System.Collections;
using UnityEngine;

public class characterController : MonoBehaviour {

    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float UpDown = Input.GetAxis("Vertical") * speed;
        float LeftRight = Input.GetAxis("Horizontal") * speed;
        UpDown *= Time.deltaTime;
        LeftRight *= Time.deltaTime;

        transform.Translate(LeftRight, 0, UpDown);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }
}
