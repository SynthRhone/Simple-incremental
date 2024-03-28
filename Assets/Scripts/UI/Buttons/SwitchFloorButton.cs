using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchFloorButton : MonoBehaviour
{
    [SerializeField] private int floorDestination;
    [SerializeField] private FloorManager floorMan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchFloor()
    {
        floorMan.SwitchFloors(floorDestination);
    }
}
