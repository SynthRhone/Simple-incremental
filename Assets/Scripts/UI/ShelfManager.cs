using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfManager : MonoBehaviour
{
    [SerializeField] private List<ShelfToggleButton> shelfButtons;
    private bool buttonsActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetButtons(bool set)
    {
        buttonsActive = set;
        foreach (ShelfToggleButton shelfbutt in shelfButtons)
        {
            shelfbutt.MoveButton(buttonsActive);
        }
    }
}
