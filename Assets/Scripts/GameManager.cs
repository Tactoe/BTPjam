using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject pauseMenu;

    public bool murderMode;

    void Awake()
    {

        if (Instance == null)
        {

            Instance = this;
            DontDestroyOnLoad(this.gameObject);

            //Rest of your Awake code

        }
        else
        {
            Destroy(this);
        }
    }

    public void ExitGame()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            Application.Quit();
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        pauseMenu.SetActive(false);
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void HandleEndScene(bool isRetrying)
    {
        print("ere");
        print(murderMode);
        if (murderMode)
        {
            NextScene();
        }
        else
        {
            if (isRetrying)
                ReloadScene();
            else
                MainMenu();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu != null)
        {
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
            Time.timeScale = pauseMenu.activeInHierarchy ? 0 : 1;
        }
    }

}
