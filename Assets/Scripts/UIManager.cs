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
    public TMP_Text BuildPyramidWood_TXT;
    public TMP_Text BuildPyramidStone_TXT;
    public TMP_Text BuildObeliskAnkh_TXT;
    public TMP_Text BuildObeliskWood_TXT;
    public TMP_Text BuildObeliskStone_TXT;
    public TMP_Text BuildSunDialWood_TXT;
    public TMP_Text BuildSunDialStone_TXT;
    //Upgrade Costs
    public TMP_Text TotemUpgrade1_TXT;
    public TMP_Text TotemUpgrade2_TXT;
    public TMP_Text TotemUpgrade3_TXT;
    public TMP_Text StonehengeUpgrade1_TXT;
    public TMP_Text StonehengeUpgrade2_TXT;
    public TMP_Text StonehengeUpgrade3_TXT;

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

    public void UpdateGatherAmounts(float totem, float totemupgrade1, float totemupgarde2, float totemupgrade3, float stonehenge, float stonehengeupgrade1, float stonehengeupgrade2, float stonehengeupgrade3, float pyramid, float obelisk, float sundial)
    {
        int fontSize;
        #region Gather Resources
        GatherWood_TXT.text = NumberConverter.ConvertFloat((totemupgrade1 + 1) / 2 * (totem + 1), out fontSize);
        GatherStone_TXT.text = NumberConverter.ConvertFloat((stonehengeupgrade1 + 1) / 4 * (stonehenge + 1), out fontSize);
        #endregion

        #region Build Costs
        BuildPyramidWood_TXT.text = "" + NumberConverter.ConvertFloat(GameManager.GetCost(pyramid, 1.4f, 500), out fontSize);
        BuildPyramidStone_TXT.text = "" + NumberConverter.ConvertFloat(GameManager.GetCost(pyramid, 1.4f, 250), out fontSize);

        BuildTotem_TXT.text = "" + NumberConverter.ConvertFloat(GameManager.GetCost(totem, 2, 10), out fontSize);

        BuildStonehenge_TXT.text = "" + NumberConverter.ConvertFloat(GameManager.GetCost(stonehenge, 2, 10), out fontSize);

        BuildObeliskAnkh_TXT.text = "" + NumberConverter.ConvertFloat(GameManager.GetCost(obelisk, 1.6f, 2), out fontSize);
        BuildObeliskWood_TXT.text = "" + NumberConverter.ConvertFloat(GameManager.GetCost(obelisk, 1.6f, 1000), out fontSize);
        BuildObeliskStone_TXT.text = "" + NumberConverter.ConvertFloat(GameManager.GetCost(obelisk, 1.6f, 1000), out fontSize);

        BuildSunDialWood_TXT.text = "" + NumberConverter.ConvertFloat(GameManager.GetCost(sundial, 1.3f, 250), out fontSize);
        BuildSunDialStone_TXT.text = "" + NumberConverter.ConvertFloat(GameManager.GetCost(sundial, 1.3f, 250), out fontSize);
        #endregion

        #region Upgrade Costs
        TotemUpgrade1_TXT.text = "" + NumberConverter.ConvertFloat(GameManager.GetCost(totemupgrade1, 1.1f, 10), out fontSize);
        TotemUpgrade2_TXT.text = "" + NumberConverter.ConvertFloat(GameManager.GetCost(totemupgarde2, 1.3f, 50), out fontSize);
        TotemUpgrade3_TXT.text = "" + NumberConverter.ConvertFloat(GameManager.GetCost(totemupgrade3, 1.6f, 100), out fontSize);

        StonehengeUpgrade1_TXT.text = "" + NumberConverter.ConvertFloat(GameManager.GetCost(stonehengeupgrade1, 1.1f, 20), out fontSize);
        StonehengeUpgrade2_TXT.text = "" + NumberConverter.ConvertFloat(GameManager.GetCost(stonehengeupgrade2, 1.3f, 60), out fontSize);
        StonehengeUpgrade3_TXT.text = "" + NumberConverter.ConvertFloat(GameManager.GetCost(stonehengeupgrade3, 1.6f, 150), out fontSize);
        #endregion
    }
}
