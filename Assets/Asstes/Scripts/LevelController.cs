using UnityEngine;

public class LevelController : MonoBehaviour {

    public UnityEngine.UI.Text text;
    public UnityEngine.UI.Text Timertext;
    public GameObject EndStats;
    public GameObject pauseMenu;
    public int ActualScore;
    public float timer;
    public int closeOpen;
    private bool CanPause;
    public UnityEngine.UI.Text BoostsList;
    public GameController GC;
    public bool czyLiczyc;
    public GameObject HardDiff;
    public UnityEngine.UI.Text HardTimerText;
    public float HardTimer;
    public UnityEngine.UI.Text CashShower;
    public bool win;
    public GameObject LooserStats;
    public UnityEngine.UI.Text LivesShow;
    public GameObject NormalDiff;
    public int LivesOn;
    public ParticleSystem ps;

    void Start () {
        if(ps.isPlaying == true)
        {
            ps.Stop(true);
        }
        EndStats.SetActive(false);
        LooserStats.SetActive(false);
        ActualScore = 0;
        timer = 0;
        pauseMenu.SetActive(false);
        CanPause = true;
        BoostsList.text = "";
        czyLiczyc = true;
        if (Manager.Instance.difficultychosen == 3)
        {
            HardTimer = 10;
            HardDiff.SetActive(true);
        }
        else
        {
            HardDiff.SetActive(false);
        }
        if (Manager.Instance.difficultychosen == 2)
        {
            NormalDiff.SetActive(true);
        }
        else
        {
            NormalDiff.SetActive(false);
        }
    }
	

	void Update () {
        LivesShow.text = "Lives: " + Manager.Instance.Lives;
        HardTimerText.text = "Time to lose: " + HardTimer.ToString("00") + "s";

        CashShower.text = "$: " + Manager.Instance.Cash;
        text.text = "Score: " + ActualScore;
        Timertext.text = "Your time: " + timer.ToString("00") + "s";

        if (Manager.Instance.difficultychosen == 3 && win == false)
        {

            HardTimer -= 1 * Time.deltaTime;
        }
            
        
        if (GC.speedBoostTimer > 0)
        {
            BoostsList.text = "Speed boosted !!!";

            if(ps.isStopped == true)
            {
                ps.Play(true);
            }
        }
        else
        {
            BoostsList.text = " ";
            if (ps.isPlaying == true)
            {
                ps.Stop(true);
            }
        }
        if(ActualScore == Manager.Instance.ScoreNedded && win == false)
        {
            win = true;
            EndStats.SetActive(true);
            switch (Manager.Instance.difficultychosen)
            {
                case 1:
                    Manager.Instance.Cash += 5 * ActualScore;
                    break;
                case 2:
                    Manager.Instance.Cash += 20 * ActualScore;
                    break;
                case 3:
                    Manager.Instance.Cash += 30 * ActualScore;
                    break;
            }                      
            CanPause = false;
            czyLiczyc = false;
            HardDiff.SetActive(false);
            NormalDiff.SetActive(false);
        }
        if (czyLiczyc == true)
        {
            timer += Time.deltaTime;
        }
        if(Manager.Instance.difficultychosen == 3 && HardTimer <= 0)
        {
            LooserStats.SetActive(true);
            win = true;
            czyLiczyc = false;
            CanPause = false;
            HardDiff.SetActive(false);
        }
        if(Manager.Instance.difficultychosen == 2 && Manager.Instance.Lives == 0 )
        {
            LooserStats.SetActive(true);
            win = true;
            czyLiczyc = false;
            CanPause = false;
            NormalDiff.SetActive(false);
        }
        
        if (CanPause == true)
        {
            if (closeOpen == 0)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    pauseMenu.SetActive(true);
                    closeOpen = 1;
                    Time.timeScale = 0;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    pauseMenu.SetActive(false);
                    closeOpen = 0;
                    Time.timeScale = 1;
                }
            }
        }
    }
}
