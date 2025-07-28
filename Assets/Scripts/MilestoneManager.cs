using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MilestoneManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameManager gameManager;
    public string Milestone1;
    public string Milestone2;
    public string Milestone3;
    public string Milestone4;
    int milestone;

    public GameObject milestonepanel;
    public TextMeshProUGUI textwall;

    public void CheckMilestone()
    {
        if (milestone == 0)
        {
            milestone++;
            gameManager.enabled = false;
            textwall.text = Milestone1;
            milestonepanel.SetActive(true);
        }
        else if (milestone == 1)
        {
            milestone++;
            gameManager.enabled = false;
            textwall.text = Milestone2;
            milestonepanel.SetActive(true);
        }
        else if (milestone == 2)
        {
            milestone++;
            gameManager.enabled = false;
            textwall.text = Milestone3;
            milestonepanel.SetActive(true);
        }
        else if (milestone == 3)
        {
            milestone++;
            gameManager.enabled = false;
            textwall.text = Milestone4;
            milestonepanel.SetActive(true);
        }
    }

}
