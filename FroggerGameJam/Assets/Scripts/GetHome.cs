using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHome : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    // Start is called before the first frame update
    public bool frogHome = false; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(!frogHome)
                frogHome = true;
        }
    }
}
