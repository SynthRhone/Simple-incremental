using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfToggleButton : MonoBehaviour
{
    private ShelfManager shelfman;
    [SerializeField] private ToggleableShelf associatedShelf;
    [SerializeField] float positionDelta = 250.0f;
    //if shelf is active, but not the parent shelf
    private bool active = false;
    public bool ParentActive
    {
        get { return parentActive; }
    }
    private RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        shelfmanager = gameObject.GetComponentInParent<ShelfManager>();
        associatedShelf = gameObject.GetComponentInParent<ToggleableShelf>();
        rect = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //called when parent shelf is activated
    public void ButtonPressed()
    {
        active = !active;
        shelfman.SetButtons(active);
    }

    //called when another button is pressed
    public void MoveButton(bool set)
    {
        DeactivateShelf();
        if (buttonMove == false)
        {
            buttonMove = true;
            rect.Translate(new Vector3(-positionDelta, 0, 0));
        }
        else
        {
            buttonMove = false;
            rect.Translate(new Vector3(positionDelta, 0, 0));
        }

    }
}
