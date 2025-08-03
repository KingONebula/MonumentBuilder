using UnityEngine;

public class MilestoneManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject milestoneone, mtwo, mthree, mfour;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            milestoneone.SetActive(false);
            mtwo.SetActive(false);
            mthree.SetActive(false);
        }
    }
    public void Milestone()
    {
        milestoneone.SetActive(true);
    }
    public void MilestoneTwo()
    {
        mtwo.SetActive(true);
    }
    public void MilestoneThree()
    {
        mthree.SetActive(true);
    }
    public void MilestoneFour()
    {
        mfour.SetActive(true);
    }
}
