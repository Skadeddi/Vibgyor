using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sens;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");    
    }

    void Update()
    {
        transform.eulerAngles += new Vector3(-Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"), 0) * Time.deltaTime * sens;
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
    }
}
