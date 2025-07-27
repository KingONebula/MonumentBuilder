using UnityEngine;
using TMPro;
using System;

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
    public TMP_Text GatherWood_TXT;
    public TMP_Text GatherStone_TXT;
    //Monument Costs
    public TMP_Text BuildTotem_TXT;
    public TMP_Text BuildStonehenge_TXT;
    public TMP_Text BuildPyramid_TXT;
    public TMP_Text BuildObelisk_TXT;
    public TMP_Text BuildSunDial_TXT;

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

    public void UpdateGatherAmounts(float totem, float stonehenge, float pyramid, float obelisk, float sundial)
    {
        GatherWood_TXT.text = (totem + 1).ToString();
        GatherStone_TXT.text = (stonehenge + 1).ToString();

        BuildPyramid_TXT.text = "Wood: " + GameManager.GetCost(pyramid, 1.4f, 500);
        BuildPyramid_TXT.text += " | Stone: " + GameManager.GetCost(pyramid, 1.4f, 500);

        BuildTotem_TXT.text = "Wood: " + GameManager.GetCost(totem, 1.1f, 10);

        BuildStonehenge_TXT.text = "Stone: " + GameManager.GetCost(stonehenge, 1.1f, 10);

        BuildObelisk_TXT.text = "Ankh: " + GameManager.GetCost(obelisk, 1.6f, 2);
        BuildObelisk_TXT.text += " | Wood: " + GameManager.GetCost(obelisk, 1.6f, 1000);
        BuildObelisk_TXT.text += " | Stone: " + GameManager.GetCost(obelisk, 1.6f, 1000);

        BuildSunDial_TXT.text = "Wood: " + GameManager.GetCost(sundial, 1.3f, 250);
        BuildSunDial_TXT.text += " | Stone: " + GameManager.GetCost(sundial, 1.3f, 250);
    }
}
