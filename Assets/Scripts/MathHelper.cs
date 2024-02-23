using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathHelper : MonoBehaviour
{
    public float Round(float round, int dp = 1)
    {
        float temp = round;
        temp *= Mathf.Pow(10,dp);
        temp = Mathf.Round(temp);
        temp /= Mathf.Pow(10, dp);
        return temp;
    }
}