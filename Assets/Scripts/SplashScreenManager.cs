using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using UnityEngine.UI;
using TMPro;

public class SplashScreenManager : MonoBehaviour
{
    public GameObject Canvas;
    public Image Splash_IMG;
    public TMP_Text Splash_Text;
    public float imgFadeDuration = 1.0f;
    public float imgTime {  get; private set; }
    public float txtFadeDuration = 1.0f;
    public float txtTime {  get; private set; }
    float waitTime = 1.7f;
    private void Start()
    {
        imgTime = imgFadeDuration;
        txtTime = txtFadeDuration;
    }

    private void Update()
    {
        waitTime -= Time.deltaTime; 
        if (waitTime > 0) return;   
        if (imgTime <= 0) return;


        imgTime -= Time.deltaTime;
        txtTime -= Time.deltaTime;

        float imgAlpha = imgTime / imgFadeDuration;
        float txtAlpha = txtTime / txtFadeDuration;

        Color imgColor = Splash_IMG.color;
        if(imgTime / imgFadeDuration <= 0.57f)
            imgAlpha -= (Time.deltaTime * 2);
        imgColor.a = imgAlpha;
        Color txtColor = Splash_Text.color;
        txtColor.a = txtAlpha;

        Splash_IMG.color = imgColor;
        Splash_Text.color = txtColor;
        if(Splash_IMG.color.a <= 0.47f)
            Canvas.SetActive(false);
        Debug.Log(Splash_IMG.color.a);
    }
}
