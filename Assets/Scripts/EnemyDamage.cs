using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public HealthBar healthBar;
    public int HP;
    public void GetDamage()
    {

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
            healthBar.SetHealth(HP);
    }

    public void FixedUpdate()
    {
        if (healthBar.getHealth() == 0) //enemy dies
            FindObjectOfType<GameManager>().LoadNextLevel();
    }
}
