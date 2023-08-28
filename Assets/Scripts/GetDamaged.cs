using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDamaged : MonoBehaviour
{
    public HealthBar healthBar;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
            healthBar.SetHealth(3);
    }

    public void FixedUpdate()
    {
        if (healthBar.getHealth() == 0)
            FindObjectOfType<GameManager>().Restart(); 
    }
}
