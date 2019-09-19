using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerOnTimerEnd : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTimerEnd()
    {
        Debug.Log("Hi");
        Destroy(player);
        
    }
   
}
