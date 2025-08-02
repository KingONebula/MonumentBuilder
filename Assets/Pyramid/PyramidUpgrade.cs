using UnityEngine;

public class PyramidUpgrade : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created [SerializeField] GameManager gameManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject totem_1, totem_2, totem_3, totem_4;
    [SerializeField] GameObject costUI;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (hit.collider != null && hit.collider.tag == "Pyramid")
        {
            costUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (gameManager.pyramid == 0)
                    TryBuyLevelOne();
                else if (gameManager.pyramid == 1)
                    TryBuyLevelTwo();
                else if (gameManager.pyramid == 2)
                    TryBuyLevelThree();
                else if (gameManager.pyramid == 3)
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
        if (gameManager.stone >= 15)
        {
            gameManager.milestoneManager.MilestoneThree();
            gameManager.pyramid++;
            totem_1.SetActive(true);
        }
    }
    public void TryBuyLevelTwo()
    {
        if (gameManager.stone >= 35 && gameManager.ankh >= 15)
        {
            gameManager.pyramid++;
            totem_2.SetActive(true);
            totem_1.SetActive(false);
        }
    }
    public void TryBuyLevelThree()
    {
        if (gameManager.wood > 40 && gameManager.stone >= 100 && gameManager.ankh >= 30)
        {
            gameManager.pyramid++;
            totem_3.SetActive(true);
            totem_2.SetActive(false);
        }
    }
    public void TryBuyLevelFour()
    {
        if (gameManager.wood > 75 && gameManager.stone >= 130 && gameManager.ankh >= 50)
        {
            gameManager.pyramid++;
            totem_4.SetActive(true);
            totem_3.SetActive(false);
        }
    }
}
