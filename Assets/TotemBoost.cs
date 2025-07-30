using UnityEngine;
using UnityEngine.UI;

public class TotemBoost : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject WoodOutline;
    [SerializeField] GameObject StrategemUIObject;
    [SerializeField] Image StrategemUI;
    [SerializeField] Sprite WSprite, ASprite, SSprite, DSprite;
    [SerializeField] Image LetterSprite;
    [SerializeField] RectTransform TimeBar;
    [SerializeField] StrategemGame strategemGame;



    float boostTime;


    float chanceTime;
    float chanceMin = 5, chanceMax = 10;
    float rechargeTime;
    bool canPlaygame;


    void Start()
    {
        chanceTime = Random.Range(chanceMin, chanceMax);
    }

    // Update is called once per frame
    void Update()
    {
        LetterSprite.sprite = GetLetterSprite(strategemGame.currentDirection);
        TimeBar.localScale = new Vector3(strategemGame.strategemtime / strategemGame.strategemlimit, 1, 1);
        boostTime = Mathf.Clamp(boostTime - Time.deltaTime, 0, Mathf.Infinity);
        if (!strategemGame.enabled && !canPlaygame)
        {
            rechargeTime += Time.deltaTime;
        }
        if (rechargeTime >= chanceTime)
        {
            canPlaygame = true;
            rechargeTime = 0;
            chanceTime = Random.Range(chanceMin, chanceMax);
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
    public void BoostResources()
    {
        canPlaygame = false;
        boostTime += strategemGame.mult;
        StrategemUI.color = Color.red;
    }
    public bool IsBoosted()
    {
        if (boostTime > 0)
        {
            return true;
        }
        return false;
    }
    public void LevelTwo()
    {
        chanceMax = 10;
        chanceMin = 5;
    }
    public void LevelThree()
    {
        chanceMax = 7;
        chanceMin = 4;
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
}
