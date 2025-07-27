using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Managers
    [SerializeField]
    UIManager uiManager;
    [SerializeField] MonumentManager monumentManager;
    //Resources
    float ankh = 0;
    float wood = 0;
    float stone = 0;
    float spirit = 0;
    float prestige = 1;
    public float time = 0;
    //Monuments
    float pyramid = 0;
    float totem = 0;
    float totemupgrade1 = 0, totemupgrade2 = 0, totemupgrade3 = 0;
    float stonehenge = 0;
    float stonehengeupgrade1 = 0, stonehengeupgrade2 = 0, stonehengeupgrade3 = 0;
    float obelisk = 0;
    float sundial = 0;
    float moyai = 0;
    void Start()
    {

    }
    public float GetCost(float currentAmount, float ramp, float baseCost)
    {
        return (currentAmount+1) * baseCost * Mathf.Pow(ramp, currentAmount);
    }
    public float RollCritChance(float level)
    {
        if (UnityEngine.Random.value < level / 100f)
        {
            return 1.5f;
        }
        return 1;
    }
    // Update is called once per frame
    void Update()
    {
        AnkhProduction();
        WoodProductions();
        WoodProductions();
        StoneProduction();
        SpiritProduction();
        uiManager.UpdateResources(ankh, wood, stone, spirit, prestige);
        uiManager.UpdateGatherAmounts(totem,stonehenge,pyramid, obelisk, sundial);

        time += Time.deltaTime;
        if (time > 600)
        {
            ResetProgress();
        }
    }
    #region Production
    public void GatherWood()
    {
        wood += (totemupgrade1 + 1) / 2 * ( totem + 1 ) *  RollCritChance(totemupgrade3);
    }
    public void GatherStone()
    {
        stone += (stonehengeupgrade1 + 1) / 4 * (stonehenge + 1) * RollCritChance(stonehengeupgrade3);
    }
    void AnkhProduction()
    {
        ankh += (pyramid / 100) * Time.deltaTime;
    }
    void WoodProductions()
    {
        wood += totem * totemupgrade2 * RollCritChance(totemupgrade3) * prestige * (1 + ankh)/2 * Time.deltaTime;
    }
    void StoneProduction()
    {
        stone += stonehenge / 2 * stonehengeupgrade2 * RollCritChance(stonehengeupgrade3) * prestige * (1 + ankh)/2 * Time.deltaTime;
    }
    void SpiritProduction()
    {
        spirit += (Mathf.Pow(obelisk, prestige) * (1 + ankh * 2)) * Time.deltaTime;
    }
    public void Prestige()
    {
        prestige += wood / 10000 + stone / 1000 + ankh / 100 + spirit / 100;
    }
    #endregion
    #region TryBuy
    public void TryBuyPyramid()
    {
        if (stone >= GetCost(pyramid, 1.4f, 250))
            if (wood >= GetCost(pyramid, 1.4f, 500))
            {
                if (pyramid == 0)
                    monumentManager.OnPyramidBuild();
                stone -= GetCost(pyramid, 1.4f, 500);
                wood -= GetCost(pyramid, 1.4f, 500);
                pyramid++;
            }
                
    }
    #region Totem
    public void TryBuyTotem()
    {
        if (wood >= GetCost(totem, 2f, 10))
        {
            if (totem == 0)
                monumentManager.OnTotemBuild();
            wood -= GetCost(totem, 2f, 10);
            totem++;
        }
    }
    //Clicker Improve
    public void TryBuyTotemUpgrade1()
    {
        if (wood >= GetCost(totemupgrade1, 1.1f, 10))
        {
            wood -= GetCost(totemupgrade1, 1.1f, 10);
            totemupgrade1++;
        }
    }
    //Auto Clicker
    public void TryBuyTotemUpgrade2()
    {
        if (wood >= GetCost(totemupgrade2, 1.3f, 50))
        {
            wood -= GetCost(totemupgrade2, 1.3f, 50);
            totemupgrade2++;
        }
    }
    //Crit Chance
    public void TryBuyTotemUpgrade3()
    {
        if (wood >= GetCost(totemupgrade3, 1.6f, 100))
        {
            wood -= GetCost(totemupgrade3, 1.6f, 100);
            totemupgrade3++;
        }
    }
    #endregion
    #region Stonehenge
    public void TryBuyStonehenge()
    {
        if (stone >= GetCost(stonehenge, 2f, 10))
        {
            if (stonehenge == 0)
                monumentManager.OnStoneHengeBuild();
            stone -= GetCost(stonehenge, 2f, 10);
            stonehenge++;
        }
    }
    public void TryBuyStonehengeUpgrade1()
    {
        if (stone >= GetCost(stonehengeupgrade1, 1.1f, 20))
        {
            stone -= GetCost(stonehengeupgrade1, 1.1f, 20);
            stonehengeupgrade1++;
        }
    }
    public void TryBuyStonehengeUpgrade2()
    {
        if (stone >= GetCost(stonehengeupgrade2, 1.3f, 60))
        {
            stone -= GetCost(stonehengeupgrade2, 1.3f, 60);
            stonehengeupgrade2++;
        }
    }
    public void TryBuyStonehengeUpgrade3()
    {
        if (stone >= GetCost(stonehengeupgrade3, 1.6f, 150))
        {
            stone -= GetCost(stonehengeupgrade3, 1.6f, 150);
            stonehengeupgrade3++;
        }
    }
    #endregion
    public void TryBuyObelisk()
    {
        if (ankh >= GetCost(obelisk, 1.6f, 2))
            if (wood >= GetCost(obelisk, 1.6f, 1000))
                if (stone >= GetCost(obelisk, 1.6f, 1000))
                {
                    if (obelisk == 0)
                        monumentManager.OnObeliskBuild();
                    ankh -= GetCost(obelisk, 1.6f, 2);
                    wood -= GetCost(obelisk, 1.6f, 1000);
                    stone -= GetCost(obelisk, 1.6f, 1000);
                    obelisk++;
                }
    }
    public void TryBuySundial()
    {
        if (wood >= GetCost(sundial, 1.3f, 250))
            if (stone >= GetCost(sundial, 1.3f, 250))
            {
                if (sundial == 0)
                    monumentManager.OnSundialBuild();
                time -= 30;
                wood -= GetCost(sundial, 1.3f, 250);
                stone -= GetCost(sundial, 1.3f, 250);
                sundial++;
            }
    }
    #endregion
    public void ResetProgress()
    {
        Prestige();
        wood = 0;
        stone = 0;
        ankh = 0;
        spirit = 0;
        totem = 0;
        stonehenge = 0;
        obelisk = 0;
        pyramid = 0;
        time = 0;
        monumentManager.OnResetProgress();
    }
}
