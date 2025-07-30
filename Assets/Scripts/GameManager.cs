
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Managers
    [SerializeField]
    UIManager uiManager;
    [SerializeField] MonumentManager monumentManager;
    [SerializeField] MilestoneManager milestoneManager;
    //Resources
    float ankh = 0;
    public float wood = 0;
    float stone = 0;
    float spirit = 0;
    float prestige = 1;
    public float time = 0;
    //Monuments
    float pyramid = 0;
    public float totem = 0;
    float totemCollectTime = 0;
    public float totemBoost;
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
        obelisk = 0;
        pyramid = 0;
        time = 0;
        monumentManager.OnResetProgress();
        milestoneManager.CheckMilestone();
    }

}
