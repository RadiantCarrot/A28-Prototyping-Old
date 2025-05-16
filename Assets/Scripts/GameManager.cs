using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public GameObject MenuCanvas;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenuUI();
        }
    }
    public void ToggleMenuUI()
    {
        if (MenuCanvas.activeSelf == true)
        {
            MenuCanvas.SetActive(false);
        }
        else
        {
            MenuCanvas.SetActive(true);
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        MenuCanvas.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoSceneLuckySixes()
    {
        SceneManager.LoadScene("LuckySixes");
        MenuCanvas.SetActive(false);
    }
    public void GoScenePachinko()
    {
        SceneManager.LoadScene("Pachinko");
        MenuCanvas.SetActive(false);
    }
    public void GoSceneShuffleboard()
    {
        SceneManager.LoadScene("Shuffleboard");
        MenuCanvas.SetActive(false);
    }

    public void GoSceneServinPlates()
    {
        SceneManager.LoadScene("Servin' Plates");
        MenuCanvas.SetActive(false);
    }
}
