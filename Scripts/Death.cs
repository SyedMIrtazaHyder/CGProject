using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public int hitPoints = 3;
    // Start is called before the first frame update
    public static int winCondition = 12;
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
            Debug.Log(hitPoints);
        if (collision.gameObject.tag == "Bullet")
        { hitPoints--;
        }

        if (hitPoints <= 0)
        { Destroy(gameObject);
            winCondition--;
        }
    }

    public void Update()
    {
        if (winCondition == 0)
            FindObjectOfType<GameManager>().LoadNextLevel();
    }
}
