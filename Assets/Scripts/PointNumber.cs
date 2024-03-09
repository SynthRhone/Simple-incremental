using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PointNumber
{
    private double mantissa;
    //unsigned is used here, because if it's too small, I don't give a fuck
    private ushort exponent;
    bool positive;

    public override string ToString()
    {
        //if it's in the 10billion ranges
        if (exponent > 10)
        {
            if (!positive) { return string.Format("-{0} x 10^{1}", Mathf.Round((float)mantissa * 10000) / 10000, exponent); }
            return string.Format("{0} x 10^{1}", Mathf.Round((float)mantissa * 10000) / 10000, exponent);
        }
        else
        {
            if (!positive) { return string.Format("-{0}", Mathf.Round((float)mantissa * 10000) / 10000); }
            return string.Format("{0}", Mathf.Round((float)mantissa * 10000) / 10000);
        }
    }

    public void SetNumber(int newNum)
    {
        exponent = 1;
        positive = true;
        if (newNum < 0)
        {
            newNum *= -1;
            positive = false;
        }
        if (newNum >= 10)
        {
            while (newNum >= 10)
            {
                newNum /= 10;
                exponent += 1;
            }
            mantissa = newNum;
        }
    }

    public double GetNumber()
    {
        if (positive) { return mantissa * Mathf.Pow(10, exponent); }
        else { return -mantissa * Mathf.Pow(10, exponent); }
    }
}
