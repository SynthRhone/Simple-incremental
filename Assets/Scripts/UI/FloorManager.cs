using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] private GameObject[] floors;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchFloors(int floornum = 0)
    {
        foreach (GameObject floor in floors)
        {
            floor.SetActive(false);
        }
        floors[floornum].SetActive(true);
    }
}
