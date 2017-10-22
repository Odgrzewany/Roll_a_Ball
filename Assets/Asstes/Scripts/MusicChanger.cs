using UnityEngine;

public class MusicChanger : MonoBehaviour {

    public UnityEngine.UI.Slider slider;

    private void Start()
    {
        slider.value = MusicManager.Instance.audioSource.volume;
    }

    private void Update()
    {
        MusicManager.Instance.audioSource.volume = slider.value;
    }
}
