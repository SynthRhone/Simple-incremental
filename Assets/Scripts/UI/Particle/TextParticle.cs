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

    [SerializeField] private float velocityMin = 0.05f;
    [SerializeField] private float velocityMax = 1.0f;

    [SerializeField] private float scaleMin = 0.3f;
    [SerializeField] private float scaleMax = 2.0f;

    [SerializeField] private string messageFormat = "+{0} Points";
    //lifespan mult is used to calculate transparency
    private float lifespan, lifespanMult, velocity, scale;
    //value is passed in for text editing
    public float number;
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
        lifespan = Random.Range(lifeSpanMin, lifeSpanMax);
        velocity = Random.Range(velocityMin, velocityMax);
        scale = Random.Range(scaleMin, scaleMax);
        lifespanMult = 1.0f / lifespan;
        text.text = string.Format(messageFormat,number);
        transform.localScale = new Vector3(scale, scale, scale);
    }

    // Update is called once per frame
    void Update()
    {
        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(0,velocity,0);
        lifespan -= Time.deltaTime;
        text.color = new Color(1.0f, 1.0f, 1.0f, getTransparency()) ;
    }

    private float getTransparency()
    {
        return (1.0f - transparencyCurve.Evaluate(lifespan * lifespanMult));
    }
}
