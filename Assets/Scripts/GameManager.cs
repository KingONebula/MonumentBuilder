
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Managers
    [SerializeField]
    UIManager uiManager;
    [SerializeField] MonumentManager monumentManager;
    [SerializeField] MilestoneManager milestoneManager;
    [SerializeField] PyramidBoost PyramidBoost;
    //Resources
    float ankh = 0;
    public float wood = 0;
    public float stone = 0;
    float spirit = 0;
    float prestige = 1;
    public float time = 0;
    //Monuments
    public float pyramid = 0;
    float ankhcollecttime = 0;
    public float totem = 0;
    float totemCollectTime = 0;
    public float totemBoost;
    public float stonehenge = 0;
    float stonehengeCollectTime;
    public float stonehengeBoost;
    public float moyai = 0;
    void Start()
    {

    }
    public float GetCost(float currentAmount, float ramp, float baseCost)
    {
        return (currentAmount + 1) * baseCost * Mathf.Pow(ramp, currentAmount);
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

        uiManager.UpdateResources(ankh, wood, stone, spirit, prestige);
        //uiManager.UpdateGatherAmounts(totem, totemupgrade1, totemupgrade2, totemupgrade3, stonehenge, stonehengeupgrade1, stonehengeupgrade2, stonehengeupgrade3, pyramid, obelisk, sundial);

        time += Time.deltaTime;
        if (time > 600)
        {
            ResetProgress();
        }
        TotemCollect();
        StoneCollect();
        AnkhCollection();
    }
    #region Production
    void TotemCollect()
    {
        if (totem >= 1 && totem < 4)
        {
            totemCollectTime += Time.deltaTime * totemBoost;
            if (totemCollectTime >= 5)
            {
                wood += Random.Range((int)3, (int)5);
                totemCollectTime = 0;
            }
        }
        if (totem >= 4)
        {
            totemCollectTime += Time.deltaTime * totemBoost;
            if (totemCollectTime >= 3)
            {
                wood += Random.Range((int)3, (int)5);
                totemCollectTime = 0;
            }
        }
    }
    void StoneCollect()
    {
        float ankhboost = 0;
        if (PyramidBoost.IsBoosted())
            ankhboost = 2;
        if (stonehenge >= 1 && stonehenge < 2)
            {
                stonehengeCollectTime += Time.deltaTime * stonehengeBoost;
                if (stonehengeCollectTime >= 5)
                {
                    stone += Random.Range((int)3, (int)6) + ankhboost;
                    stonehengeCollectTime = 0;
                }
            }
        if (stonehenge >= 2)
        {
            stonehengeCollectTime += Time.deltaTime * stonehengeBoost;
            if (stonehengeCollectTime >= 3)
            {
                stone += Random.Range((int)3, (int)6) + ankhboost;
                stonehengeCollectTime = 0;
            }
        }
    }
    void AnkhCollection()
    {
        float ankhboost = 0;
        if (PyramidBoost.IsBoosted())
            ankhboost = 5;
        if (pyramid >= 1 && pyramid < 4)
        {
            ankhcollecttime += Time.deltaTime * totemBoost;
            if (ankhcollecttime >= 5)
            {
                ankh += Random.Range((int)1, (int)3)+ ankhboost;
                ankhcollecttime = 0;
            }
        }
        if (pyramid >= 4)
        {
            ankhcollecttime += Time.deltaTime * totemBoost;
            if (ankhcollecttime >= 3)
            {
                ankh += Random.Range((int)1, (int)3)+ankhboost;
                ankhcollecttime = 0;
            }
        }
    }
    #endregion
    #region TryBuy

    #endregion
    public void ResetProgress()
    {

        uiManager.ActiveStonehengeUpgrades(false);
        uiManager.ActiveTotemUpgrades(false);
        wood = 0;
        stone = 0;
        ankh = 0;
        spirit = 0;
        totem = 0;
        stonehenge = 0;
        pyramid = 0;
        time = 0;
        monumentManager.OnResetProgress();
        milestoneManager.CheckMilestone();
    }

}
