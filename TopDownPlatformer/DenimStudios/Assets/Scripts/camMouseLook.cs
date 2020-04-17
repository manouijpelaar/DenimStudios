using System.Collections;
using UnityEngine;

public class camMouseLook : MonoBehaviour {

    // Variables for the looking angle of the player and movement of the camera.
    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 4.0f;
    public float smoothness = 2.0f;
    public float minAngle = -40.0f;
    public float maxAngle = 60.0f;

    GameObject player;

    //void Start()
    //{
    //    player = this.transform.parent.gameObject;
    //}

    void Update()
    {
        // sets the camera's movement equal to the movement of the position of the mouse.
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothness, sensitivity * smoothness));
        smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f / smoothness);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseDelta.y, 1f / smoothness);
        mouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        mouseLook.y = Mathf.Clamp(mouseLook.y, minAngle, maxAngle);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);

    }
}
