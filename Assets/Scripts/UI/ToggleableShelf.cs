using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleableShelf : MonoBehaviour
{
    [SerializeField] private Vector2 activeLocation;
    [SerializeField] private Vector2 inactiveLocation;
    private RectTransform rect;
    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
        setInactive();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setActive()
    {
        active = true;
        rect.anchoredPosition = activeLocation;
    }

    private void setInactive()
    {
        active = false;
        rect.anchoredPosition = inactiveLocation;
    }

    public void ToggleShelf()
    {
        if (!active)
        {
            setActive();
        }
        else
        {
            setInactive();
        }
    }
    public void SetShelf(bool setting)
    {
        if (setting)
        {
            setActive();
        }
        else
        {
            setInactive();
        }
    }
}
