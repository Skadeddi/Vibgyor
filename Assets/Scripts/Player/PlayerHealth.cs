using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    private float hp = 100;
    
    public void HitPlayer(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            //Do something
        }
        healthBar.fillAmount = hp / 100f;
    }
}
