using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float fwdForce = 1000;
    public float sideForce = 50;
    public float jumpForce = 50;
    public static int lifePoints = 25;
    public float iFrames = 0.5f;
    private float tempTime;
    private Vector3 tempPos;
    // Start is called before the first frame update

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.collider.tag.Equals("Enemy"))
            //Debug.Log("Hit");*/
    }
    void Update()
    {
        if (Input.GetKey("w")) // forward
        {
            rb.AddForce(0, 0, fwdForce * Time.deltaTime);
        }
        if (Input.GetKey("s")) // backward
        {
            rb.AddForce(0, 0, -fwdForce * Time.deltaTime);
        }
        if (Time.time > tempTime + iFrames)
            this.tag = "Player";

        if (Input.GetKey("a")) // left
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0,
            ForceMode.VelocityChange);
        }
        if (Input.GetKey("d")) // right
        {
            rb.AddForce(sideForce *
            Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }


        /*if (rb.position.y < -14f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        rb.AddForce(0, 0, fwdForce * Time.deltaTime);*/

    }


    /*void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle" && this.tag != "IFrame")
        {
            Destroy(collisionInfo.collider.gameObject);
            transform.Translate(0, 0, -5);
            tempTime = Time.time;
            tempPos = transform.position;
            //Invoke("GameFinish", 5f); //just in case if user gets stuck smwhere
            this.tag = "IFrame";
            //Debug.Log(collisionInfo.collider.name);
            //movement.enabled = false;
            //FindObjectOfType<GameManager>().EndGame();
            lifePoints -= 1;
            if (lifePoints <= 0)
                FindObjectOfType<GameManager>().EndGame();
        }
    }*/

    /*void GameFinish()
    {
        if (Mathf.Abs(tempPos.z - transform.position.z) < 2f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }*/
}
