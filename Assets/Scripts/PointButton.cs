using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointButton : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject textParticlePrefab;
    [SerializeField] private GameObject researchPointParticlePrefab;

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    //on button press event
    public void PressPointButton()
    {
        gameManager.ChangePoints(gameManager.ButtonValue);
        if (gameManager.CheckRpRoll())
        {
            gameManager.IncrementRP();
            spawnTextParticle(researchPointParticlePrefab, 1);
        }
        spawnTextParticle(textParticlePrefab, gameManager.ButtonValue);
    }

    //spawn a new text particle, pass in prefab and number to display
    private void spawnTextParticle(GameObject particlePrefab,float textnumber)
    {
        GameObject newParticle = Instantiate(particlePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        newParticle.GetComponent<TextParticle>().number = textnumber;
        newParticle.transform.SetParent(canvas.GetComponent<Transform>());
        newParticle.transform.localPosition = new Vector3(Random.Range(-500.0f,500.0f), -290.0f, -15.0f);
    }
}
