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
        int fontSize;
        AnkhAmount_TXT.text = NumberConverter.ConvertFloat(ankhAmount, out fontSize);
        AnkhAmount_TXT.fontSize = fontSize;

        WoodAmount_TXT.text = NumberConverter.ConvertFloat(woodAmount, out fontSize);
        WoodAmount_TXT.fontSize = fontSize;

        StoneAmount_TXT.text = NumberConverter.ConvertFloat(stoneAmount, out fontSize);
        StoneAmount_TXT.fontSize = fontSize;

        SpiritAmount_TXT.text = NumberConverter.ConvertFloat(spiritAmount, out fontSize);
        SpiritAmount_TXT.fontSize = fontSize;

        PrestigeAmount_TXT.text = NumberConverter.ConvertFloat(prestigeAmount, out fontSize);
        PrestigeAmount_TXT.fontSize = fontSize;
    }

    public void UpdateGatherAmounts(float totem, float stonehenge, float pyramid, float obelisk, float sundial)
    {
        int fontSize;
        GatherWood_TXT.text = NumberConverter.ConvertFloat(totem + 1, out fontSize);
        GatherStone_TXT.text = NumberConverter.ConvertFloat(stonehenge + 1, out fontSize);

        BuildPyramid_TXT.text = "Wood: " + NumberConverter.ConvertFloat(GameManager.GetCost(pyramid, 1.4f, 500), out fontSize);
        BuildPyramid_TXT.text += " | Stone: " + NumberConverter.ConvertFloat(GameManager.GetCost(pyramid, 1.4f, 500), out fontSize);

        BuildTotem_TXT.text = "Wood: " + NumberConverter.ConvertFloat(GameManager.GetCost(totem, 1.1f, 10), out fontSize);

        BuildStonehenge_TXT.text = "Stone: " + NumberConverter.ConvertFloat(GameManager.GetCost(stonehenge, 1.1f, 10), out fontSize);

        BuildObelisk_TXT.text = "Ankh: " + NumberConverter.ConvertFloat(GameManager.GetCost(obelisk, 1.6f, 2), out fontSize);
        BuildObelisk_TXT.text += " | Wood: " + NumberConverter.ConvertFloat(GameManager.GetCost(obelisk, 1.6f, 1000), out fontSize);
        BuildObelisk_TXT.text += " | Stone: " + NumberConverter.ConvertFloat(GameManager.GetCost(obelisk, 1.6f, 1000), out fontSize);

        BuildSunDial_TXT.text = "Wood: " + NumberConverter.ConvertFloat(GameManager.GetCost(sundial, 1.3f, 250), out fontSize);
        BuildSunDial_TXT.text += " | Stone: " + NumberConverter.ConvertFloat(GameManager.GetCost(sundial, 1.3f, 250), out fontSize);
    }
}
