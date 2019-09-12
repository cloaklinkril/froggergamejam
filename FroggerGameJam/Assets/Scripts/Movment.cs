using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    
    public float MoveTimer;
    public float ResetTimer;
    public bool tryey = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name==("log"))
        {
            tryey = true;
        }

        if(collision.gameObject.name!=("log"))
        {
            tryey = false;
        }
       
    }
    void Start()
    {
        MoveTimer = ResetTimer;
    }

    // Update is called once per frame
    void Update()
    {
       
       
        MoveTimer -= Time.deltaTime;
      
        //
        //print(MoveTimer);

        if (Input.GetKeyDown(KeyCode.W) && MoveTimer <= 0)
        {
            gameObject.transform.position += new Vector3(0,1,0);
            MoveTimer = ResetTimer;
            Debug.Log("brub");
            tryey = false;
        }
        if (Input.GetKeyDown(KeyCode.A) && MoveTimer <= 0)
        {
            gameObject.transform.position += new Vector3(-1,0,0);
            MoveTimer = ResetTimer;
            tryey = false;
        }
        if (Input.GetKeyDown(KeyCode.D) && MoveTimer <= 0)
        {
            gameObject.transform.position += new Vector3(1,0,0);
            MoveTimer = ResetTimer;
            tryey = false;
        }
        if (Input.GetKeyDown(KeyCode.S) && MoveTimer <= 0)
        {
            gameObject.transform.position += new Vector3(0,-1,0);
            MoveTimer = ResetTimer;
            tryey = false;
        }

        var log = FindObjectOfType<log>();
        if (tryey)
        {
            transform.position += new Vector3(0.09f, 0, 0);
        }
        else
        {
            tryey = false;
        }
        Vector3 bru = transform.position;
        bru.z = -7;
        transform.position = bru;
    }
}
