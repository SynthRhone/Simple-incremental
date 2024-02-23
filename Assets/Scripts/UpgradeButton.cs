using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private AnimationCurve upgradeCostCurve;
    [SerializeField] private GameManager gamemanager;
    [SerializeField] public float baseCost = 1;
    private MathHelper mathhelper;
    private float costCurvePosition;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        mathhelper = gameObject.GetComponent<MathHelper>();
        costCurvePosition = 1.0f / gamemanager.MaxButtonLevel;
        updateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void upgradeButtonPressed()
    {
        if (gamemanager.CheckSufficientPoints(GetUpgradeCost()))
        {
            gamemanager.ChargePoints(GetUpgradeCost());
            gamemanager.UpgradeButton();
            updateText();
        }
        else { Debug.Log("Fuck off."); }
    }

    public float GetUpgradeCost()
    {
        float output = upgradeCostCurve.Evaluate(gamemanager.ButtonLevel * costCurvePosition);
        output *= baseCost;
        output = mathhelper.Round(output, 2);
        return output;
    }

    private void updateText()
    {
        text.text = string.Format("+1 point per click\n(costs {0} points)", GetUpgradeCost());
    }
}
