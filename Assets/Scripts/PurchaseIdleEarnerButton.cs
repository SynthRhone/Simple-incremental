using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PurchaseIdleEarnerButton : MonoBehaviour
{
    [SerializeField] private AnimationCurve purchaseCostCurve;
    [SerializeField] private GameManager gamemanager;
    [SerializeField] private IdleProduction idleproduction;
    [SerializeField] private int producerID = 0;
    [SerializeField] private string purchaseButtonText = "Buy item for {0}\nproduces {1}/sec\n({2} owned)";
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

    public void purchaseButtonPressed()
    {
        if (gamemanager.CheckSufficientPoints(idleproduction.GetIdleProducerCost(producerID)))
        {
            idleproduction.PurchaseIdleProducer(producerID);
            updateText();
        }
        else { Debug.Log("Fuck off."); }
    }


    private void updateText()
    {
        text.text = string.Format(purchaseButtonText, getIdleProducerData().BaseCost, getIdleProducerData().Production,getIdleProducerData().Owned);
    }

    private IdleProducerData getIdleProducerData()
    {
        return idleproduction.IdleProducerDataArray[producerID];
    }
}
