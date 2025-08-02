using UnityEngine;
using UnityEngine.UI;

public class soundmanager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] AudioSource audioSource;
    [SerializeField] Slider slider;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateAudio()
    {
        audioSource.volume = slider.value;
    }
}
