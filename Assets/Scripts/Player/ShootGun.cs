using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    private Camera cam;
    private RaycastHit hit;
    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera(Clone)").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 100, enemyLayer))
            {
                Debug.Log("Enemy hit!");
            }
        }
    }
}
