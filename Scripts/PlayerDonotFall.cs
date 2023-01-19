using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDonotFall : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public Transform player;
    void Update()
    {
        if (player.transform.position.y < 0) 
        {
            player.Translate(player.transform.position.x, 0.5f, player.transform.position.z);
        }
    }
}
