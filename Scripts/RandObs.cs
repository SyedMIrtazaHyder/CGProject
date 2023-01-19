using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandObs : MonoBehaviour
{
    public GameObject Wall;
    public int obstacleNo = 15;
    public float width;
    //public Boolean spin = false;
    public float distance;
    // Start is called before the first frame update
    void Start()//can try with update
    {
        for (int i = 0; i < obstacleNo; i++)
        {
            SpawnObstacle(i*distance); //spawning 15 random objects
        }
    }

    void SpawnObstacle(float zPos)
    {
        float xPos = UnityEngine.Random.Range(-width, width);
        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundY = UnityEngine.Random.Range(-180f, 180f); //setting a range for the rotation of obstacle around x axis.

        //float tiltAroundX = Input.GetAxis("Vertical") * Random.Range(-180f, 180f);

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(0, tiltAroundY, 0); //Euler rotation allows us to shift angle using degrees

        // Dampen towards the target rotation
        //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * Random.Range(0, 180.0f));

        Instantiate(Wall, new Vector3(xPos, 2, zPos), target);
    }

}
