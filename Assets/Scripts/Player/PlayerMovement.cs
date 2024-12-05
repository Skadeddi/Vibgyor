using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController cc;
    public float speed;
    private Camera cam;
    
    void Start()
    {
        cam = GameObject.Find("Main Camera(Clone)").GetComponent<Camera>();
        cc = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        cc.Move(((transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"))).normalized * speed * Time.deltaTime);
        cc.Move(new Vector3(0, -2, 0) * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, cam.transform.eulerAngles.y, 0);
    }
}
