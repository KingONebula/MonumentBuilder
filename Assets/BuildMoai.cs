using Unity.VisualScripting;
using UnityEngine;

public class BuildMoai : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject totem_1;
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
        if (hit.collider != null && hit.collider.tag == "Moai")
        {
            costUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (gameManager.moyai == 0)
                {
                    TryBuyLevelOne();
                    Debug.Log("Try Buy Moyai");
                }
                     
            }
        }
        else
        {
            costUI.SetActive(false);
        }
    }
    public void TryBuyLevelOne()
    {
        if (gameManager.wood >= 200 && gameManager.stone >= 150 && gameManager.ankh >= 75)
        {
            gameManager.moyai++;
            gameManager.wood -= 200;
            gameManager.stone -= 150;
            gameManager.ankh -= 75;
            gameManager.milestoneManager.MilestoneFour();
            totem_1.SetActive(true);
        }
    }
}
