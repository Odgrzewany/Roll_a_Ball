using UnityEngine;


public class Shop : MonoBehaviour {

    public UnityEngine.UI.Text costshow;
    public float cost;
    public Material material;
    public ParticleSystem ps;
    public float Timer;

    void Start () {
        cost = 10;
        if (ps.isPlaying)
        {
            ps.Stop(true);
        }
        material.color = Manager.Instance.color;
    }


    void Update() {
        costshow.text = "Change colour for: " + cost;
        if(Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        if(Timer <= 0 && ps.isPlaying)
        {
            ps.Stop(true);
        }

	}


  

    public void ColourCanhge()
    {
        if (Manager.Instance.Cash >= cost)
        {
            material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            Manager.Instance.Cash -= cost;
            cost += 5;
            Timer = 2;
            if (ps.isStopped)
            {
                ps.Play(true);
            }
            Manager.Instance.color = material.color;
        }      
    }
}
