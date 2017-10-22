using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void EditBall()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void LevelChoose()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    public void Level2()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }
    public void Level3()
    {
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }
    public void Level4()
    {
        SceneManager.LoadScene(6);
        Time.timeScale = 1;
    }
    public void Level5()
    {
        SceneManager.LoadScene(7);
        Time.timeScale = 1;
    }

    public void Peacfull()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
        Manager.Instance.difficultychosen = 1;
    }
    public void Normal()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
        Manager.Instance.difficultychosen = 2;
    }
    public void Hard()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
        Manager.Instance.difficultychosen = 3;
    }
    public void Exit()
    {
        Application.Quit();
    }
}

