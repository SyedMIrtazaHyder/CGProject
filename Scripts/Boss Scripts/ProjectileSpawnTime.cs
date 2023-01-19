using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnTime : MonoBehaviour
{
    public float TimeToLive = 5f;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TimeToLive);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed);
    }
}
