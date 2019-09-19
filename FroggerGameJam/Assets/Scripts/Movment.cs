using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    
    public float MoveTimer;
    public float ResetTimer;
    public bool logmover = false;
    public bool logmover2 = false;
    public GameObject yep;
    public bool othercheck = false;
    public float speed;
    
    // Start is called before the first frame update
    
    void Start()
    {
        MoveTimer = ResetTimer;

    }
    public void die()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<log>())
        {
            var logspeed = collision.GetComponent<log>().speed;
            speed = logspeed;
            logmover = true;
        }




        if (collision.gameObject.tag == ("water") && logmover == false)
        {
            die();

            Debug.Log("dead");
            if (collision.gameObject.tag != ("log") && logmover)
            {
                Debug.Log("nomore");
                //tryey = false;
                othercheck = true;
            }

        }



    }

    // Update is called once per frame
    void Update()
    {
       
       if(logmover == true)
       {
            Debug.Log("dsjflkdsfjlkdsfkjl");
       }
        MoveTimer -= Time.deltaTime;
      
        //
        //print(MoveTimer);

        if (Input.GetKeyDown(KeyCode.W) && MoveTimer <= 0)
        {
            gameObject.transform.position += new Vector3(0,1,0);
            MoveTimer = ResetTimer;
            transform.eulerAngles = Vector3.forward * 0;
            Debug.Log("brub");
            logmover = false;
            if(othercheck==true)
            {
                die();
            }

        }
        if (Input.GetKeyDown(KeyCode.A) && MoveTimer <= 0)
        {
            gameObject.transform.position += new Vector3(-1,0,0);
            MoveTimer = ResetTimer;
            transform.eulerAngles = Vector3.forward * 90;
            if (othercheck == true)
            {
                die();
            }
        }
        if (Input.GetKeyDown(KeyCode.D) && MoveTimer <= 0)
        {
            gameObject.transform.position += new Vector3(1,0,0);
            MoveTimer = ResetTimer;
            transform.eulerAngles = Vector3.forward * -90;
            if (othercheck == true)
            {
                die();
            }
        }
        if (Input.GetKeyDown(KeyCode.S) && MoveTimer <= 0)
        {
            gameObject.transform.position += new Vector3(0,-1,0);
            MoveTimer = ResetTimer;
            transform.eulerAngles = Vector3.forward * 180;
            logmover = false;
            if (othercheck == true)
            {
                die();
            }
        }

        var log = FindObjectOfType<log>();
        if (logmover)
        {
         
            transform.position += new Vector3(speed, 0, 0);
            Debug.Log("logiscolliding");

        }
       
        
        Vector3 bru = transform.position;
        bru.z = -7;
        transform.position = bru;
    }
    
}
