using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject gameOVerUI;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void gameOver()
    {
        gameOVerUI.SetActive(true);
    }

    public void restartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void mainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}

