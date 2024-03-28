using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//manages buttons
public class ButtonManager : MonoBehaviour
{

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
        buttonLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(points);
    }
}
