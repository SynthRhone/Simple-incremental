using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleProduction : MonoBehaviour
{
    //amount owned, base cost, production/sec
    [SerializeField] private IdleProducerData[] idleProducerDataArray = new IdleProducerData[5];
    [SerializeField] private AnimationCurve[] purchaseCostCurves = new AnimationCurve[5];
    [SerializeField] private int maxProducers = 100;
    private float costCurvePosition;
    public IdleProducerData[] IdleProducerDataArray
    {
        get { return idleProducerDataArray; }
    }
    //`private MathHelper mathhelper;
    private ResourceStorage resStor;
    // Start is called before the first frame update
    void Start()
    {
        costCurvePosition = 1.0f / maxProducers;
        idleProducerDataArray[0].Owned = 0;
        idleProducerDataArray[0].BaseCost = 5.0f;
        idleProducerDataArray[0].Production = 0.2f;
        idleProducerDataArray[0].CostCurve = purchaseCostCurves[0];

        //mathhelper = gameObject.GetComponent<MathHelper>();
        resStor = gameObject.GetComponent<ResourceStorage>();
    }

    // Update is called once per frame
    void Update()
    {
        float earnings = 0.0f;
        foreach (IdleProducerData idleProducer in idleProducerDataArray)
        {
            earnings += Time.deltaTime * idleProducer.Owned * idleProducer.Production;
        }
        resStor.ChangePoints(earnings);
    }
    
    public void PurchaseIdleProducer(int producerID)
    {
        if (resStor.CheckSufficientPoints(GetIdleProducerCost(producerID)))
        {
            resStor.ChargePoints(GetIdleProducerCost(producerID));
            idleProducerDataArray[producerID].Owned++;
            return;
        }
        else { return; }
    }

    public float GetIdleProducerCost(int producerID)
    {
        return idleProducerDataArray[producerID].BaseCost * idleProducerDataArray[producerID].CostCurve.Evaluate(costCurvePosition * (idleProducerDataArray[producerID].Owned + 1));
    }
}
public struct IdleProducerData
{
    public int Owned;
    public float BaseCost, Production;
    public AnimationCurve CostCurve;
    public IdleProducerData(AnimationCurve costcurve, float cost, float production, int owned = 0)
    {
        Owned = owned;
        BaseCost = cost;
        Production = production;
        CostCurve = costcurve;
    }
}