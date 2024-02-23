using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject textParticlePrefab;

    [SerializeField] private GameObject canvas;
    private MathHelper mathhelper;
    private float rpChance;

    private float points;
    public float Points
    {
        get { return points; }
    }

    //public method to add points
    public void ChangePoints(float addPoint)
    {
        points += addPoint;
        points = mathhelper.Round(points, 2);
    }

    //public method for subtracting points (e.g. purchasing)
    public void ChargePoints(float subPoint)
    {
        points -= subPoint;
        points = mathhelper.Round(points, 2);
    }

    public bool CheckSufficientPoints(float check)
    {
        if (points >= check) { return true; }
        else { return false; }
    }

    private int rp;
    public int ResearchPoints
    {
        get { return rp; }
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

    public float GetRpChance
    {
        get { return rpChance; }
    }

    public bool CheckRpRoll()
    {
        if (Random.value <= rpChance) { return true; }
        else { return false; }
    }

    private int buttonLevel;
    public int ButtonLevel
    {
        get { return buttonLevel; }
    }

    public float ButtonValue
    {
        get { return 1 * buttonLevel; }
    }

    public void UpgradeButton()
    {
        buttonLevel += 1;
    }

    [SerializeField] private int maxButtonLevel = 10;
    public int MaxButtonLevel
    {
        get { return maxButtonLevel; }
    }

    public bool isButtonMaxed
    {
        get
        {
            if (buttonLevel == maxButtonLevel) { return true; }
            else { return false; } 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        points = 0.0f;
        rp = 0;
        rpChance = 0.05f;
        buttonLevel = 1;
        mathhelper = gameObject.GetComponent<MathHelper>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(points);
    }
}
