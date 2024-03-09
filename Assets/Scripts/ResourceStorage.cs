using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//manages and stores values for resources such as points and RP
public class ResourceStorage : MonoBehaviour
{
    private MathHelper mathhelper;
    
    // Start is called before the first frame update
    void Start()
    {
        points = 0.0f;
        rp = 0;
        mathhelper = gameObject.GetComponent<MathHelper>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    [SerializeField] private float baseRPChance = 0.05f;
    public float RPChance
    {
        get { return baseRPChance; }
    }

    public int rp;
    public int ResearchPoints
    {
        get { return rp; }
    }
    public float points;
    public float Points
    {
        get { return points; }
    }
    public string PointsAsText
    {
        get
        {
            return string.Format("{0:N2}",points);
        }
    }

    //public method to add points
    public void ChangePoints(float addPoint)
    {
        points += addPoint;
    }

    public void AddIdlePoints(float add)
    {
        points += add;
    }

    //public method for subtracting points (e.g. purchasing)
    public void ChargePoints(float subPoint)
    {
        points -= subPoint;
    }

    public bool CheckSufficientPoints(float check)
    {
        if (points >= check) { return true; }
        else { return false; }
    }

    public void IncrementRP()
    {
        rp++;
    }

    public void ChargeRP(int cost)
    {
        rp -= cost;
    }

    public bool checkSufficientRp(int cost)
    {
        if (rp <= cost) { return true; }
        else { return false; }
    }

    public bool CheckRPRoll()
    {
        if (Random.value <= baseRPChance) { return true; }
        else { return false; }
    }
}
