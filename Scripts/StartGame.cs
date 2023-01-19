using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadNextLevel()
        {
            FindObjectOfType<GameManager>().LoadNextLevel();
        }

    public void StartScreen()
    {
        SceneManager.LoadScene(0);

    }

    public void FixedUpdate()
    {
        if (Input.GetKey("space"))
            LoadNextLevel();
        else if (Input.GetKey("escape"))
        { Debug.Log("Exiting game");
            Application.Quit();
        }
    }
}
