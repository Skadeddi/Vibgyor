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
    }

    void Update()
    {
        pitch = -Input.GetAxisRaw("Mouse Y");
        yaw = Input.GetAxisRaw("Mouse X");
        transform.eulerAngles += new Vector3(pitch, yaw, 0) * Time.deltaTime * sens;

        Debug.Log(transform.eulerAngles.x);
        if(transform.eulerAngles.x > 80 && transform.eulerAngles.x < 280)
        {
            transform.eulerAngles = new Vector3(80, transform.eulerAngles.y, 0);
        }

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
    }
}
