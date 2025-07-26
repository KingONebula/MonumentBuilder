using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    public TMP_Text AnkhAmount_TXT;
    public TMP_Text WoodAmount_TXT;
    public TMP_Text StoneAmount_TXT;
    public TMP_Text SpiritAmount_TXT;
    public TMP_Text PrestigeAmount_TXT;

    public void UpdateResources(float ankhAmount, float woodAmount, float stoneAmount, float spiritAmount, float prestigeAmount)
    {
        double roundVal = Math.Round(ankhAmount, 2);
        AnkhAmount_TXT.text = roundVal.ToString();

        roundVal = Math.Round(woodAmount, 2);
        WoodAmount_TXT.text = roundVal.ToString();

        roundVal = Math.Round(stoneAmount, 2);
        StoneAmount_TXT.text = roundVal.ToString();

        roundVal = Math.Round(spiritAmount, 2);
        SpiritAmount_TXT.text = roundVal.ToString();

        roundVal = Math.Round(prestigeAmount, 2);
        PrestigeAmount_TXT.text = roundVal.ToString();
    }
}
