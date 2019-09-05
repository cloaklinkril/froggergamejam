using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    float MoveTimer;
    // Start is called before the first frame update
    void Start()
    {
        MoveTimer = .05f;
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveTimer -= Time.deltaTime;

        print(MoveTimer);

        if (Input.GetKeyDown(KeyCode.W) && MoveTimer <= 0)
        {
            gameObject.transform.position += new Vector3(0,1,0);
            MoveTimer = .05f;
        }
        if (Input.GetKeyDown(KeyCode.A) && MoveTimer <= 0)
        {
            gameObject.transform.position += new Vector3(-1,0,0);
            MoveTimer = .05f;
        }
        if (Input.GetKeyDown(KeyCode.D) && MoveTimer <= 0)
        {
            gameObject.transform.position += new Vector3(1,0,0);
            MoveTimer = .05f;
        }
        if (Input.GetKeyDown(KeyCode.S) && MoveTimer <= 0)
        {
            gameObject.transform.position += new Vector3(0,-1,0);
            MoveTimer = .05f;
        }
    }
}
