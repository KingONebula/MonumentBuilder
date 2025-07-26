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
    float prestige = 0;
    float time = 0;
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
    void AnkhProduction()
    {
        ankh += (pyramid / 100) * Time.deltaTime;
    }
    void WoodProductions()
    {
        wood += ((totem * spirit + stonehenge / 2) * prestige * (1 + ankh)) * Time.deltaTime;
    }
    void StoneProduction()
    {
        stone += ((stonehenge * spirit + totem / 2) * prestige * (1 + ankh)) * Time.deltaTime;
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
        if (stone > GetCost(pyramid, 1.4f, 500))
            if (wood > GetCost(pyramid, 1.4f, 500))
            {
                if (pyramid == 0)
                    monumentManager.OnPyramidBuild();
                pyramid++;
            }
                
    }
    public void TryBuyTotem()
    {
        if (wood > GetCost(totem, 1.1f, 10))
        {
            if (totem == 0)
                monumentManager.OnTotemBuild();
            totem++;   
        }
    }
    public void TryBuyStonehenge()
    {
        if (stone > GetCost(stonehenge, 1.1f, 10))
        {
            if (stonehenge == 0)
                monumentManager.OnStoneHengeBuild();
            totem++;
        }
    }
    public void TryBuyObelisk()
    {
        if (ankh > GetCost(obelisk, 1.6f, 2))
            if (wood > GetCost(obelisk, 1.6f, 1000))
                if (stone > GetCost(obelisk, 1.6f, 1000))
                {
                    if (obelisk == 0)
                        monumentManager.OnObeliskBuild();
                    obelisk++;
                }
    }
    public void TryBuySundial()
    {
        if (wood > GetCost(sundail, 1.3f, 250))
            if (stone > GetCost(sundail, 1.3f, 250))
            {
                if (sundail == 0)
                    monumentManager.OnSundialBuild();
                sundail++;
                time -= 30;
            }
    }
    #endregion
    public void ResetProgress()
    {
        wood = 0;
        stone = 0;
        ankh = 0;
        spirit = 0;
        totem = 0;
        stonehenge = 0;
        obelisk = 0;
        Prestige();
    }
}
