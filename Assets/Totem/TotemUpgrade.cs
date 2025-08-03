using UnityEngine;

public class TotemUpgrade : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject totem_1, totem_2, totem_3, totem_4;
    [SerializeField] GameObject costUI;
    [SerializeField] TotemBoost totemBoost;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (hit.collider != null && hit.collider.tag == "Totem")
        {
            costUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (gameManager.totem == 0)
                    TryBuyLevelOne();
                else if (gameManager.totem == 1)
                    TryBuyLevelTwo();
                else if (gameManager.totem == 2)
                    TryBuyLevelThree();
                else if (gameManager.totem == 3)
                    TryBuyLevelFour();
                    
            }
        }
        else
        {
            costUI.SetActive(false);
        }
    }
    public void TryBuyLevelOne()
    {
        if (gameManager.wood >= 15)
        {
            gameManager.totem++;
            gameManager.wood -= 15;
            totem_1.SetActive(true);
            gameManager.milestoneManager.Milestone();
        }
    }
    public void TryBuyLevelTwo()
    {
        if (gameManager.wood >= 35)
        {
            gameManager.totem++;
            gameManager.wood -= 35;
            totem_2.SetActive(true);
            totem_1.SetActive(false);
            totemBoost.LevelTwo();
        }
    }
    public void TryBuyLevelThree()
    {
        if (gameManager.wood >= 50)
        {
            gameManager.wood -= 50;
            gameManager.totem++;
            totem_3.SetActive(true);
            totem_2.SetActive(false);
            totemBoost.LevelThree();
        }
    }
    public void TryBuyLevelFour()
    {
        if (gameManager.wood >= 150)
        {
            gameManager.totem++;
            gameManager.wood -= 150;
            totem_4.SetActive(true);
            totem_3.SetActive(false);
        }
    }
}
