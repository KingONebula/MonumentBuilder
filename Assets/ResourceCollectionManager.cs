using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCollectionManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject WoodOutline;
    [SerializeField] GameObject StrategemUIObject;
    [SerializeField] Image StrategemUI;
    [SerializeField] Sprite WSprite, ASprite, SSprite, DSprite;
    [SerializeField] Image LetterSprite;
    [SerializeField] RectTransform TimeBar;
    [SerializeField] StrategemGame strategemGame;


    float chanceTime;
    float rechargeTime;
    bool canPlaygame;


    void Start()
    {
        chanceTime = Random.Range((int)3, (int)7);
    }

    // Update is called once per frame
    void Update()
    {
        LetterSprite.sprite = GetLetterSprite(strategemGame.currentDirection);
        TimeBar.localScale = new Vector3(strategemGame.strategemtime / strategemGame.strategemlimit, 1, 1);

        if (!strategemGame.enabled && !canPlaygame)
        {
            rechargeTime += Time.deltaTime;
        }
        if (rechargeTime >= chanceTime)
        {
            canPlaygame = true;
            rechargeTime = 0;
            chanceTime = Random.Range((int)3, (int)7);
            WoodOutline.SetActive(true);
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (canPlaygame && hit.collider.tag == "Wood" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            strategemGame.enabled = true;
            StrategemUI.color = Color.white;
            StrategemUIObject.SetActive(true);
            
            WoodOutline.SetActive(false);
        }

        if (strategemGame.cooldowntime == 0 && !strategemGame.startgame && !canPlaygame)
        {
            strategemGame.enabled = false;
            StrategemUIObject.SetActive(false);
        }    
    }
    public void AddResources()
    {
        canPlaygame = false;
        gameManager.wood += strategemGame.mult;
        StrategemUI.color = Color.red;
    }
    Sprite GetLetterSprite(int letter)
    {
        if (letter == 0)
            return WSprite;
        if (letter == 1)
            return ASprite;
        if (letter == 2)
            return SSprite;
        if (letter == 3)
            return DSprite;
        return null;
    }
    void Game()
    {
        
    }
}
