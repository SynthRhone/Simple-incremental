using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TextParticle : MonoBehaviour
{
    [SerializeField] private AnimationCurve transparencyCurve;
    [SerializeField] private float lifeSpanMin = 2.0f;
    [SerializeField] private float lifeSpanMax = 5.0f;
    [SerializeField] private string messageFormat = "+{0} Points";
    private float lifespan, lifespanMult;
    //value is passed in for text editing
    public float number;
    //public float x, y;
    private TextMeshProUGUI text;
    //private Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
        //transform = gameObject.GetComponent<Transform>();
        //transform.position = new Vector3(x, y, 0);
        lifespan = Random.Range(lifeSpanMin, lifeSpanMax);
        lifespanMult = 1.0f / lifespan;
        text.text = string.Format(messageFormat,number);
    }

    // Update is called once per frame
    void Update()
    {
        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(0,0.1f,0);
        lifespan -= Time.deltaTime;
        //Debug.Log(getTransparency());
        text.color = new Color(1.0f, 1.0f, 1.0f, getTransparency()) ;
    }

    private float getTransparency()
    {
        return (1.0f - transparencyCurve.Evaluate(lifespan * lifespanMult));
    }
}
