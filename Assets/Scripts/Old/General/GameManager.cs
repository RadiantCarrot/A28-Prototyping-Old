using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public GameObject MenuCanvas;

    public GameObject Panel1;
    public GameObject Panel2;

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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (Panel1.activeSelf == false || Panel2.activeSelf == false)
            {
                Panel1.SetActive(true);
                Panel2.SetActive(true);
            }
            else
            {
                Panel1.SetActive(false);
                Panel2.SetActive(false);
            }
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

    #region OldPrototypes
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

    public void GoScenePyramid()
    {
        SceneManager.LoadScene("Pyramid");
        MenuCanvas.SetActive(false);
    }

    public void GoSceneKutiKuti()
    {
        SceneManager.LoadScene("KutiKuti");
        MenuCanvas.SetActive(false);
    }
    #endregion

    public void GoSceneLudo()
    {
        SceneManager.LoadScene("Ludo");
        MenuCanvas.SetActive(false);
    }
    public void GoSceneBallpit()
    {
        SceneManager.LoadScene("Ballpit");
        MenuCanvas.SetActive(false);
    }
    public void GoSceneCardPack()
    {
        SceneManager.LoadScene("Card Pack");
        MenuCanvas.SetActive(false);
    }
}
