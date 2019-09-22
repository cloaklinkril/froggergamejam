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
    AudioSource hop;
    float speed;
    SpriteRenderer spriteR;
    public Sprite moveSprite;
    public Sprite idleSprite;
    bool alive = true;
    char direction = ' ';
    public int maxFrames;
    int frames;

    // Start is called before the first frame update

    void Start()
    {
        MoveTimer = ResetTimer;
        spriteR = gameObject.GetComponent<SpriteRenderer>();
    }
    public void die()
    {
        alive = false;
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
        if(frames == maxFrames)
        {
            if(collision.gameObject.tag != ("log") && logmover)
            {
                logmover = false;
            }
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
        if (Input.GetKeyDown(KeyCode.W) && alive && direction == ' ')
        {
            AudioManager.PlayHop();
            spriteR.sprite = moveSprite;
            direction = 'w';
            MoveTimer = ResetTimer;
            transform.eulerAngles = Vector3.forward * 0;
        }
        if (Input.GetKeyDown(KeyCode.A) && alive && direction == ' ')
        {
            spriteR.sprite = moveSprite;
            direction = 'a';
            MoveTimer = ResetTimer;
            transform.eulerAngles = Vector3.forward * 90;
        }
        if (Input.GetKeyDown(KeyCode.S) && alive && direction == ' ')
        {
            spriteR.sprite = moveSprite;
            direction = 's';
            MoveTimer = ResetTimer;
            transform.eulerAngles = Vector3.forward * 180;
        }
        if (Input.GetKeyDown(KeyCode.D) && alive && direction == ' ')
        {
            spriteR.sprite = moveSprite;
            direction = 'd';
            MoveTimer = ResetTimer;
            transform.eulerAngles = Vector3.forward * -90;
        }

        if (direction == 'w')
        {
            gameObject.transform.position += new Vector3(0, (float)(1 / (float)maxFrames), 0);
            frames++;
        }
        if (direction == 'a')
        {
            gameObject.transform.position -= new Vector3((float)(1 / (float)maxFrames), 0, 0);
            frames++;
        }
        if (direction == 's')
        {
            gameObject.transform.position -= new Vector3(0, (float)(1 / (float)maxFrames), 0);
            frames++;
        }
        if (direction == 'd')
        {
            gameObject.transform.position += new Vector3((float)(1 / (float)maxFrames), 0, 0);
            frames++;
        }

        if (frames >= maxFrames)
        {
            direction = ' ';
            spriteR.sprite = idleSprite;
            frames = 0;
        }
        //if (Input.GetKeyDown(KeyCode.W) && MoveTimer <= 0)
        //{
        //    gameObject.transform.position += new Vector3(0,0.25f,0);
        //    MoveTimer = ResetTimer;
        //    logmover = false;
        //    if(othercheck==true)
        //    {
        //        die();
        //    }
        //
        //}
        //if (Input.GetKeyDown(KeyCode.A) && MoveTimer <= 0)
        //{
        //    gameObject.transform.position += new Vector3(-0.25f, 0,0);
        //    MoveTimer = ResetTimer;
        //    if (othercheck == true)
        //    {
        //        die();
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.D) && MoveTimer <= 0)
        //{
        //    gameObject.transform.position += new Vector3(0.25f, 0,0);
        //    MoveTimer = ResetTimer;
        //    if (othercheck == true)
        //    {
        //        die();
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.S) && MoveTimer <= 0)
        //{
        //    gameObject.transform.position += new Vector3(0,-0.25f, 0);
        //    MoveTimer = ResetTimer;
        //    logmover = false;
        //    if (othercheck == true)
        //    {
        //        die();
        //    }
        //}

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
