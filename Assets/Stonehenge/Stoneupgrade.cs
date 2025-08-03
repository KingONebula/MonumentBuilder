using UnityEngine;

public class Stoneupgrade : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject totem_1, totem_2;
    [SerializeField] GameObject costUI;
    [SerializeField] StoneBoosts stoneBoosts;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (hit.collider != null && hit.collider.tag == "Stone")
        {
            costUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (gameManager.stonehenge == 0)
                    TryBuyLevelOne();
                else if (gameManager.stonehenge == 1)
                    TryBuyLevelTwo();
                    
            }
        }
        else
        {
            costUI.SetActive(false);
        }
    }
    public void TryBuyLevelOne()
    {
        if (gameManager.wood >= 70)
        {
            gameManager.stonehenge++;
            gameManager.wood -= 70;
            

            gameManager.milestoneManager.MilestoneTwo();
            totem_1.SetActive(true);
        }
    }
    public void TryBuyLevelTwo()
    {
        if (gameManager.stone >= 40 && gameManager.wood >= 100)
        {
            stoneBoosts.LevelTwo();
            gameManager.stonehenge++;
            gameManager.wood -= 100;
            gameManager.stone -= 40;
            totem_2.SetActive(true);
            totem_1.SetActive(false);
        }
    }
}
