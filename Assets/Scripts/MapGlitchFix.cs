using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGlitchFix : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if (player.position.y <= 0)
            player.Translate(0, 5, 0);
    }
}
