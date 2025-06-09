using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DontDestroyOnLoad : MonoBehaviour
{
    public int cardsClicked = 0;
    public GameObject ContinueButton;

    public SeedScript SeedScript;
    public CardPackWeight CardPackWeight;

    public Scene currentScene;


    private static DontDestroyOnLoad _instance;
    public static DontDestroyOnLoad Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DontDestroyOnLoad>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject); // Destroy duplicate
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Make this persistent
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (cardsClicked >= 10)
        {
            RevealContinueButton();
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnSceneLoaded(Scene currentScene, LoadSceneMode mode)
    {
        ContinueButton = GameObject.Find("ContinueButton");
        ContinueButton.GetComponent<Button>().onClick.AddListener(RestartScene);
        ContinueButton.SetActive(false);
        cardsClicked = 0;
        SeedScript = gameObject.GetComponent<SeedScript>();
        SeedScript.GenerateSeed();
        CardPackWeight = gameObject.GetComponent<CardPackWeight>();
        CardPackWeight.reassignVariables = true;
    }

    public void RevealContinueButton()
    {
        ContinueButton.SetActive(true);
    }
}
