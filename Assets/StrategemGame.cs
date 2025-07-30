using UnityEngine;
using UnityEngine.Events;

public class StrategemGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public UnityEvent endgame;
    public float strategemtime = 0;
    public float strategemlimit = 0;
    public float cooldown;
    public float cooldowntime;
    public int currentDirection;
    public int multStep;
    public int mult;
    public int baseMult;
    public bool startgame;
    void Start()
    {
        currentDirection = Random.Range((int)0, (int)4);
    }

    // Update is called once per frame
    void Update()
    {
        cooldowntime = Mathf.Clamp(cooldowntime - Time.deltaTime, 0, cooldown);
        if (cooldowntime == 0)
        {
            if (GetInputDirection() == currentDirection && !startgame)
            {
                startgame = true;
                currentDirection = Random.Range((int)0, (int)3);
            }
            else if (startgame)
            {
                Game();
            }
        }
    }
    void Game()
    {
        if (GetInputDirection() == currentDirection)
        {
            mult += multStep;
            strategemlimit = Mathf.Clamp(strategemlimit - 0.1f, 0.5f, 2);
            strategemtime = 0;
                currentDirection = Random.Range((int)0, (int)4);
            }
        else if (GetInputDirection() != -1)
        {
            EndGame();
        }
        strategemtime += Time.deltaTime;
        if (strategemtime >= strategemlimit)
        {
            EndGame();
        }
    }
    //omg like the movie
    void EndGame()
    {
        cooldowntime = cooldown;
        endgame.Invoke();
        strategemlimit = 2;
        startgame = false;
        mult = baseMult;
    }
    int GetInputDirection()
    {
        if (Input.GetKeyDown(KeyCode.W))
            return 0;
        if (Input.GetKeyDown(KeyCode.A))
            return 1;
        if (Input.GetKeyDown(KeyCode.S))
            return 2;
        if (Input.GetKeyDown(KeyCode.D))
            return 3;
        return -1;
    }
}
