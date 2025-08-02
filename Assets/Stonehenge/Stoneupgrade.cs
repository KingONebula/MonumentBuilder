using UnityEngine;

public class Stoneupgrade : MonoBehaviour
{
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
        if (hit.collider.tag == "Totem")
        {
            costUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (gameManager.pyramid == 0)
                    TryBuyLevelOne();
                else if (gameManager.pyramid == 1)
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
        if (gameManager.stone > 15)
        {
            gameManager.stonehenge++;
            totem_1.SetActive(true);
        }
    }
    public void TryBuyLevelTwo()
    {
        if (gameManager.stone > 25)
        {
            gameManager.stonehenge++;
            totem_2.SetActive(true);
            totem_1.SetActive(false);
        }
    }
}
