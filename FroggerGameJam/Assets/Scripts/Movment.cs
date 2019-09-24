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
    float speed;
    SpriteRenderer spriteRenderer;
    public Sprite moveSprite;
    public Sprite idleSprite;
    public Sprite drownd1;
    public Sprite drownd2;
    public Sprite drownd3;
    public Sprite car1;
    public Sprite car2;
    public Sprite car3;
    public Sprite death;
    bool alive = true;
    bool drown = false;
    bool runover = false;
    char direction = ' ';
    public int maxFrames;
    int frames;

    // Start is called before the first frame update

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        EventScript.current.onGoalReached += onGoalReached;
        EventScript.current.onRespawnAfterDeath += respawn;
        EventScript.current.onPlayerRunOver += onPlayerRunOver;
        MoveTimer = ResetTimer;
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
            drown = true;
            alive = false;
            Debug.Log("dead");
            if (collision.gameObject.tag != ("log") && logmover)
            {
                Debug.Log("nomore");
                //tryey = false;
                othercheck = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<log>())
        {
            logmover = false;
        }
    }
        // Update is called once per frame
        void Update()
    {
       if(runover)
        {
            if (frames == 0)
                spriteRenderer.sprite = car1;
            if (frames == 32)
                spriteRenderer.sprite = car2;
            if (frames == 48)
                spriteRenderer.sprite = car3;
            if (frames == 62)
            {
                transform.eulerAngles = Vector3.forward * 0;
                spriteRenderer.sprite = death;
            }
            if (frames == 80)
                EventScript.current.RespawnAfterDeath();
            if (runover)
               frames++;
            Debug.Log(frames);
        }
       if(logmover == true)
       {
            // Debug.Log("dsjflkdsfjlkdsfkjl");
       }
        MoveTimer -= Time.deltaTime;

        //
        //print(MoveTimer);
        if (Input.GetKeyDown(KeyCode.W) && alive && direction == ' ')
        {
            GetComponents<AudioSource>()[0].Play();
            spriteRenderer.sprite = moveSprite;
            direction = 'w';
            MoveTimer = ResetTimer;
            transform.eulerAngles = Vector3.forward * 0;
        }
        if (Input.GetKeyDown(KeyCode.A) && alive && direction == ' ' && transform.position.x > -6.5)
        {
            GetComponents<AudioSource>()[0].Play();
            spriteRenderer.sprite = moveSprite;
            direction = 'a';
            MoveTimer = ResetTimer;
            transform.eulerAngles = Vector3.forward * 90;
        }
        if (Input.GetKeyDown(KeyCode.S) && alive && direction == ' ')
        {
            GetComponents<AudioSource>()[0].Play();
            spriteRenderer.sprite = moveSprite;
            direction = 's';
            MoveTimer = ResetTimer;
            transform.eulerAngles = Vector3.forward * 180;
        }
        if (Input.GetKeyDown(KeyCode.D) && alive && direction == ' ' && transform.position.x < 6.5)
        {
            GetComponents<AudioSource>()[0].Play();
            spriteRenderer.sprite = moveSprite;
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

        if (frames >= maxFrames && alive == true)
        {
            direction = ' ';
            spriteRenderer.sprite = idleSprite;
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
        //    Debug.Log("logiscolliding");
        }
       
        
        Vector3 bru = transform.position;
        bru.z = -7;
        transform.position = bru;

    }
    private void onGoalReached()
    {
        frames = 0;
        direction = ' ';
        spriteRenderer.sprite = idleSprite;
        transform.position = new Vector3(0.5f, -2.5f, 1.7f);
        transform.eulerAngles = Vector3.forward * 0;
        logmover = false;
    }
    private void respawn()
    {
        frames = 0;
        direction = ' ';
        spriteRenderer.sprite = idleSprite;
        transform.position = new Vector3(0.5f, -2.5f, 1.7f);
        transform.eulerAngles = Vector3.forward * 0;
        logmover = false;
        alive = true;
        runover = false;
        drown = false;
    }
    private void onPlayerRunOver()
    {
        GetComponents<AudioSource>()[2].Play();
        alive = false;
        frames = 0;
        direction = ' ';
        logmover = false;
        runover = true;
    }
}
