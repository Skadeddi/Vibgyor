using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SwitchView : MonoBehaviour
{
    public UniversalRendererData urd;
    // Start is called before the first frame update
    void Start()
    {
        urd.rendererFeatures[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            urd.rendererFeatures[1].SetActive(!urd.rendererFeatures[1].isActive);
        }
    }
}
