using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider colliderInfo)
    {
        FindObjectOfType<GameManager>().LevelComplete();
    }
}
