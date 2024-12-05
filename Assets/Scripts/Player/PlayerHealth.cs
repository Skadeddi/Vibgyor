using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private Image healthBar;
    private float hp = 100;
    private VariableDeclarations vars;

    private void Start()
    {
        healthBar = GameObject.Find("Healthbar").GetComponent<Image>();
        vars = Variables.Scene(SceneManager.GetActiveScene());
    }

    private void Update()
    {
        healthBar.fillAmount = ((int) vars.Get("PlayerHealth")) / 100.0f;
    }

}
