using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    
    public float MoveTimer;
    public float ResetTimer;
    // Start is called before the first frame update
    void Start()
    {
        MoveTimer = ResetTimer;
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveTimer -= Time.deltaTime;

        //print(MoveTimer);

        if (Input.GetKeyDown(KeyCode.W) /*&& MoveTimer <= 0*/)
        {
            gameObject.transform.position += new Vector3(0,1,0);
            MoveTimer = ResetTimer;
            Debug.Log("brub");
        }
       // if (Input.GetKeyDown(KeyCode.A) && MoveTimer <= 0)
       // {
       //     gameObject.transform.position += new Vector3(-1,0,0);
       //     MoveTimer = ResetTimer;
       // }
       // if (Input.GetKeyDown(KeyCode.D) && MoveTimer <= 0)
       // {
       //     gameObject.transform.position += new Vector3(1,0,0);
       //     MoveTimer = ResetTimer;
       // }
       // if (Input.GetKeyDown(KeyCode.S) && MoveTimer <= 0)
       // {
       //     gameObject.transform.position += new Vector3(0,-1,0);
       //     MoveTimer = ResetTimer;
       // }
    }
}
