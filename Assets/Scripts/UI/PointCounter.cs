using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointCounter : MonoBehaviour
{
    [SerializeField] private ResourceStorage resStor;
    [SerializeField] private string messageFormat = "{0}\nPoints";
    [SerializeField] private int points;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeText();
        //text.text = string.Format("{0}\nPoints",gamemanager.Points);
    }

    void ChangeText()
    {
        text.text = string.Format(messageFormat, resStor.PointsAsText);
    }
}