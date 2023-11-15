using UnityEngine;

public class Opportunity_Timer : MonoBehaviour
{
    private int opportunity;
    // Start is called before the first frame update
    void Start()
    {
        opportunity = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        opportunity++;
    }

    public int getOpportunity() { return this.opportunity; }

    public void setOpportunity(int opportunity) { this.opportunity = opportunity; }

    public bool state() { return this.gameObject.GetComponent<Opportunity_Timer>().enabled; }
}
