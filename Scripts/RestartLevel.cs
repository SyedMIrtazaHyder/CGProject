using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void LevelReset()
    {
        //Cursor.visible = true;
        Debug.Log(GameManager.tempIndex);
        FindObjectOfType<GameManager>().RestartLevel(); 
    }

    public void FixedUpdate()
    {
        if (Input.GetKey("e"))
            SceneManager.LoadScene(0);
        if (Input.GetKey("space"))
            LevelReset();
    }

}
