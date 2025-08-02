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
        if (hit.collider.tag == "Totem")
        {
            costUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (gameManager.moyai == 0)
                    TryBuyLevelOne();   
            }
        }
        else
        {
            costUI.SetActive(false);
        }
    }
    public void TryBuyLevelOne()
    {
        if (gameManager.wood > 15)
        {
            gameManager.moyai++;
            totem_1.SetActive(true);
        }
    }
}
