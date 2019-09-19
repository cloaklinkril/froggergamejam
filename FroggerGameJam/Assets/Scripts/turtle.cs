using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtle : MonoBehaviour
{
    public float under = 1;
    public float whileunder = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        under -= Time.deltaTime;
        if(under<=0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            whileunder -= 1;
            whileunder -= Time.deltaTime;
           
        }
        if (whileunder >= -1)
        {
            under = 1;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }


    }
}
