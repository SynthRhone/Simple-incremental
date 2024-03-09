using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//does not store data about the idle producers, that is held in idle production
public class PurchaseIdleEarnerButton : MonoBehaviour
{
    [SerializeField] private AnimationCurve purchaseCostCurve;
    [SerializeField] private ResourceStorage resStor;
    [SerializeField] private ButtonManager buttMan;
    [SerializeField] private IdleProduction idleproduction;
    [SerializeField] private int producerID = 0;
    [SerializeField] private string purchaseButtonText = "Buy item for {0:N2}\nproduces {1}/sec\n({2} owned)";
    //private MathHelper mathhelper;
    private float costCurvePosition;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        //mathhelper = gameObject.GetComponent<MathHelper>();

        costCurvePosition = 1.0f / buttMan.MaxButtonLevel;
        updateText();
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void purchaseButtonPressed()
    {
        if (resStor.CheckSufficientPoints(idleproduction.GetIdleProducerCost(producerID)))
        {
            idleproduction.PurchaseIdleProducer(producerID);
            updateText();
        }
        else { Debug.Log("Fuck off."); }
    }


    private void updateText()
    {
        text.text = string.Format(purchaseButtonText, idleproduction.GetIdleProducerCost(producerID), getIdleProducerData().Production, getIdleProducerData().Owned);
    }

    private IdleProducerData getIdleProducerData()
    {
        return idleproduction.IdleProducerDataArray[producerID];
    }
}
