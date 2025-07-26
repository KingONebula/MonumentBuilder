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
    float stonehenge = 0;
    float obelisk = 0;
    float sundail = 0;
    float moyai = 0;
    void Start()
    {

    }
    public float GetCost(float currentAmount, float ramp, float baseCost)
    {
        return (currentAmount+1) * baseCost * Mathf.Pow(ramp, currentAmount);
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

        time += Time.deltaTime;
        if (time > 600)
        {
            ResetProgress();
        }
    }
    #region Production
    public void GatherWood()
    {
        wood += totem + 1;
    }
    public void GatherStone()
    {
        stone += stonehenge + 1;
    }
    void AnkhProduction()
    {
        ankh += (pyramid / 100) * Time.deltaTime;
    }
    void WoodProductions()
    {
        wood += ((totem * (spirit+1) + stonehenge / 4) * prestige * (1 + ankh)) * Time.deltaTime;
    }
    void StoneProduction()
    {
        stone += ((stonehenge * (spirit+1) + totem / 4) * prestige * (1 + ankh)) * Time.deltaTime;
    }
    void SpiritProduction()
    {
        spirit += (Mathf.Pow(obelisk, prestige) * (1 + ankh * 2)) * Time.deltaTime;
    }
    public void Prestige()
    {
        prestige += wood / 1000 + stone / 1000 + ankh / 100 + spirit / 100;
    }
    #endregion
    #region TryBuy
    public void TryBuyPyramid()
    {
        if (stone >= GetCost(pyramid, 1.4f, 500))
            if (wood >= GetCost(pyramid, 1.4f, 500))
            {
                if (pyramid == 0)
                    monumentManager.OnPyramidBuild();
                stone -= GetCost(pyramid, 1.4f, 500);
                wood -= GetCost(pyramid, 1.4f, 500);
                pyramid++;
            }
                
    }
    public void TryBuyTotem()
    {
        if (wood >= GetCost(totem, 1.1f, 10))
        {
            if (totem == 0)
                monumentManager.OnTotemBuild();
            wood -= GetCost(totem, 1.1f, 10);
            totem++;
        }
    }
    public void TryBuyStonehenge()
    {
        if (stone >= GetCost(stonehenge, 1.1f, 10))
        {
            if (stonehenge == 0)
                monumentManager.OnStoneHengeBuild();
            stone -= GetCost(stonehenge, 1.1f, 10);
            stonehenge++;
        }
    }
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
        if (wood >= GetCost(sundail, 1.3f, 250))
            if (stone >= GetCost(sundail, 1.3f, 250))
            {
                if (sundail == 0)
                    monumentManager.OnSundialBuild();
                time -= 30;
                wood -= GetCost(sundail, 1.3f, 250);
                stone -= GetCost(sundail, 1.3f, 250);
                sundail++;
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
