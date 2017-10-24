using UnityEngine.SceneManagement;
using UnityEngine;


public class Manager : MonoBehaviour
{
    public static Manager Instance { get; private set; }

    public int ScoreNedded;
    public GameObject[] collectables;
    public float Cash;
    public int difficultychosen;
    public int Lives;
    public int whichLevelIsNow;
    public Color color;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
        
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene: " + scene.name);
        collectables = GameObject.FindGameObjectsWithTag("Pick Up");
        ScoreNedded = collectables.Length;
        if(scene.name == "Menu")
        {
            Lives = 3;
        }
        if(scene.name == "Scene4")
        {
            whichLevelIsNow = 4;
        }
    }
    
}
