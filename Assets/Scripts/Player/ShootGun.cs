using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class ShootGun : MonoBehaviour
{
    private Camera cam;
    private RaycastHit hit;
    public LayerMask enemyLayer;
    private Animator gunimator;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        gunimator = GameObject.Find("Gun").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gunimator.SetTrigger("Shoot");
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 100))
            {
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    CustomEvent.Trigger(hit.transform.gameObject, "hit", Random.Range(10, 20));
                }
            }
        }
    }
}
