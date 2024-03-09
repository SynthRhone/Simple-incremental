using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Button player presses to earn points
public class PointButton : MonoBehaviour
{
    [SerializeField] private ButtonManager buttMan;
    [SerializeField] private ResourceStorage resStor;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject textParticlePrefab;
    [SerializeField] private GameObject researchPointParticlePrefab;

    private uint buttonClicks = 0;
    public uint Clicks
    {
        get { return buttonClicks; }
    }

    //on button press event
    public void PressPointButton()
    {
        buttonClicks++;
        resStor.ChangePoints(buttMan.ButtonValue);
        if (resStor.CheckRPRoll())
        {
            resStor.IncrementRP();
            spawnTextParticle(researchPointParticlePrefab, 1);
        }
        spawnTextParticle(textParticlePrefab, buttMan.ButtonValue);
    }

    //spawn a new text particle, pass in prefab and number to display
    private void spawnTextParticle(GameObject particlePrefab,float textnumber)
    {
        GameObject newParticle = Instantiate(particlePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        newParticle.GetComponent<TextParticle>().number = textnumber;
        newParticle.transform.SetParent(canvas.GetComponent<Transform>());
        newParticle.transform.localPosition = new Vector3(Random.Range(-500.0f,500.0f), -290.0f, -15.0f);
    }

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
