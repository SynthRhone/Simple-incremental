using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleProduction : MonoBehaviour
{
    //amount owned, base cost, production/sec
    [SerializeField] private IdleProducerData[] idleProducerDataArray = new IdleProducerData[5];
    public IdleProducerData[] IdleProducerDataArray
    {
        get { return idleProducerDataArray; }
    }
    private MathHelper mathhelper;
    private GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        idleProducerDataArray[0].Owned = 0;
        idleProducerDataArray[0].BaseCost = 5.0f;
        idleProducerDataArray[0].Production = 0.2f;

        mathhelper = gameObject.GetComponent<MathHelper>();
        gamemanager = gameObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float earnings = 0.0f;
        foreach (IdleProducerData idleProducer in idleProducerDataArray)
        {
            earnings += Time.deltaTime * idleProducer.Owned * idleProducer.Production;
        }
        gamemanager.ChangePoints(earnings);
    }
    
    public void PurchaseIdleProducer(int producerID)
    {
        if (gamemanager.CheckSufficientPoints(GetIdleProducerCost(producerID)))
        {
            idleProducerDataArray[producerID].Owned++;
            return;
        }
        else { return; }
    }

    public float GetIdleProducerCost(int producerID)
    {
        return idleProducerDataArray[producerID].BaseCost;
    }
}
public struct IdleProducerData
{
    public int Owned;
    public float BaseCost, Production;
    public IdleProducerData(float cost, float production, int owned = 0)
    {
        Owned = owned;
        BaseCost = cost;
        Production = production;
    }
}