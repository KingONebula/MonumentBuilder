using UnityEngine;
using TMPro;
using System;
using TMPro.Examples;
using UnityEngine.UI;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    public GameManager GameManager;
    //Resource Amounts
    public TMP_Text AnkhAmount_TXT;
    public TMP_Text WoodAmount_TXT;
    public TMP_Text StoneAmount_TXT;
    public TMP_Text SpiritAmount_TXT;
    public TMP_Text PrestigeAmount_TXT;
    //Gather Amounts

    public void UpdateResources(float ankhAmount, float woodAmount, float stoneAmount, float spiritAmount, float prestigeAmount)
    {
        int fontSize;
        AnkhAmount_TXT.text = NumberConverter.ConvertFloat(ankhAmount, out fontSize);
        //AnkhAmount_TXT.fontSize = fontSize;

        WoodAmount_TXT.text = NumberConverter.ConvertFloat(woodAmount, out fontSize);
        //WoodAmount_TXT.fontSize = fontSize;

        StoneAmount_TXT.text = NumberConverter.ConvertFloat(stoneAmount, out fontSize);
        //StoneAmount_TXT.fontSize = fontSize;

        //SpiritAmount_TXT.text = NumberConverter.ConvertFloat(spiritAmount, out fontSize);
        //SpiritAmount_TXT.fontSize = fontSize;

        //PrestigeAmount_TXT.text = NumberConverter.ConvertFloat(prestigeAmount, out fontSize);
        //PrestigeAmount_TXT.fontSize = fontSize;
    }
}
