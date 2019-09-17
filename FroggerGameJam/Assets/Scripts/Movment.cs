using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    
    public float MoveTimer;
    public float ResetTimer;
    public bool tryey = false;
    public GameObject yep;
    public bool othercheck = false;
    // Start is called before the first frame update
    
    void Start()
    {
        MoveTimer = ResetTimer;
    }
    public void die()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       
       if(tryey == true)
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
            tryey = false;
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
            tryey = false;
            if (othercheck == true)
            {
                die();
            }
        }

        var log = FindObjectOfType<log>();
        if (tryey)
        {
            transform.position += new Vector3(0.09f, 0, 0);
            
        }
        
        Vector3 bru = transform.position;
        bru.z = -7;
        transform.position = bru;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("log"))
        {
            Debug.Log("onlog");
            tryey = true;

        }


       
        if (collision.gameObject.tag == ("water") && tryey==false)
        {
            die();

            Debug.Log("dead");
            if (collision.gameObject.tag != ("log") && tryey)
            {
                Debug.Log("nomore");
                //tryey = false;
                othercheck = true;
            }

        }
       


    }
}
