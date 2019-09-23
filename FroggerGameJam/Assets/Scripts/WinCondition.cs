using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject[] goals;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        bool everythingDone = true;
        goals = GameObject.FindGameObjectsWithTag("Goal");
        foreach(GameObject checkGoal in goals)
        {
            if (checkGoal.GetComponent<GetHome>().frogHome == false)
            {
                everythingDone = false;
            }
        }
        if (everythingDone == true)
        {
            EventScript.current.GameWon();
        }
    }
}
