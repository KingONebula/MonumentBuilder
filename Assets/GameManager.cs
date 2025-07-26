using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Resources
    float ankh = 0;
    float wood = 0;
    float stone = 0;
    float spirit = 0;
    float prestige = 0;
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
        return currentAmount * baseCost * Mathf.Pow(ramp, baseCost);
    }
    // Update is called once per frame
    void Update()
    {
        AnkhProduction();
        WoodProductions();
        WoodProductions();
        StoneProduction();
        SpiritProduction();
    }
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
}
