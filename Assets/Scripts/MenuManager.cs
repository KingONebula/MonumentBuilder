using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject MainCanvas_GO;
    public GameObject MenuCanvas_GO;
    public AudioMixer MusicMixer;
    public Slider MusicSlider;
    public AudioMixer SFXMixer;
    public Slider SFXSlider;
    public AudioMixer NarratorMixer;
    public Slider NarratorSlider;
    public Image Knob1900, Knob1280, KnobFullscreen;
    bool isFullscreen = true;
    Vector2Int sreenRes = new Vector2Int(1900, 1080);
    bool isInMenu = false;

    private void Awake()
    {
        isFullscreen = true;
        sreenRes = new Vector2Int(1900, 1080);
        SetRes();
    }

    public void ToggleCanvas()
    {
        isInMenu = !isInMenu;
        MainCanvas_GO.SetActive(!isInMenu);
        MenuCanvas_GO.SetActive(isInMenu);
    }

    public void SetMusicVolume()
    {
        if (MusicMixer == null) return;
        float volume = MusicSlider.value;
        MusicMixer.SetFloat("music", volume);
    }

    public void SetSFXVolume()
    {
        if (SFXMixer == null) return;
        float volume = SFXSlider.value;
        SFXMixer.SetFloat("sfx", volume);
    }

    public void SetNarratorVolume()
    {
        if (NarratorMixer == null) return;
        float volume = NarratorSlider.value;
        NarratorMixer.SetFloat("narrator", volume);
    }

    private void SetRes()
    {
        Screen.SetResolution(sreenRes.x, sreenRes.y, isFullscreen);
    }

    public void SetResolution1900()
    {
        sreenRes = new Vector2Int(1900, 1080);
        Knob1280.gameObject.SetActive(false);
        Knob1900.gameObject.SetActive(true);
        SetRes();
    }
    public void SetResolution1280()
    {
        sreenRes = new Vector2Int(1280, 720);
        Knob1280.gameObject.SetActive(true);
        Knob1900.gameObject.SetActive(false);
        SetRes();
    }
    public void SetFullScreen()
    {
        isFullscreen = !isFullscreen;
        KnobFullscreen.gameObject.SetActive(isFullscreen);
        SetRes();
    }
}
