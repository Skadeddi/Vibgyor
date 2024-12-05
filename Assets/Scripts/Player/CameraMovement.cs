using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sens;
    private GameObject player;
    private float pitch, yaw;

    private void Start()
    {
        player = GameObject.Find("Player");
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        pitch -= Input.GetAxisRaw("Mouse Y") * sens * Time.deltaTime;
        yaw += Input.GetAxisRaw("Mouse X") * sens * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -80f, 80f);
        transform.eulerAngles = new Vector3(pitch, yaw, 0);
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
    }
}
