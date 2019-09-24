using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    
    public float MoveTimer;
    public float ResetTimer;
    public float deathtimer;
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
        EventScript.current.onPlayerDrown += onPlayerDrown;
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
           
            Debug.Log("dead");
            deathtimer -= Time.deltaTime;
            Debug.Log(deathtimer);
            if (collision.gameObject.tag != ("log") && logmover == false && deathtimer<= 0)
            {
                EventScript.current.PlayerDrown();
                drown = true;
                Debug.Log("nomore");
                //gmover = false;
                //die();
            }
        }
    }
    void die()
    {
        Destroy(gameObject);
    }
        // Update is called once per frame
        void Update()
    {
        if (runover)
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
        }
        if (drown)
        {
            if (frames == 0)
                spriteRenderer.sprite = drownd1;
            if (frames == 32)
                spriteRenderer.sprite = drownd2;
            if (frames == 48)
                spriteRenderer.sprite = drownd3;
            if (frames == 62)
            {
                transform.eulerAngles = Vector3.forward * 0;
                spriteRenderer.sprite = death;
            }
            if (frames == 80)
                EventScript.current.RespawnAfterDeath();
            if (drown)
                frames++;
        }

        MoveTimer -= Time.deltaTime;
        
        //
        //print(MoveTimer);
        if (Input.GetKeyDown(KeyCode.W) && !(drown || runover) && direction == ' ')
        {
            GetComponents<AudioSource>()[0].Play();
            logmover = false;
            spriteRenderer.sprite = moveSprite;
            direction = 'w';
            MoveTimer = ResetTimer;
            
                transform.eulerAngles = Vector3.forward * 0;

        }
        if (Input.GetKeyDown(KeyCode.A) && !(drown || runover) && direction == ' ' && transform.position.x > -6.5)
        {
            GetComponents<AudioSource>()[0].Play();
            spriteRenderer.sprite = moveSprite;
            direction = 'a';
            MoveTimer = ResetTimer;
           
            transform.eulerAngles = Vector3.forward * 90;
        }
        if (Input.GetKeyDown(KeyCode.S) && !(drown || runover) && direction == ' ')
        {
            GetComponents<AudioSource>()[0].Play();
            logmover = false;
            spriteRenderer.sprite = moveSprite;
            direction = 's';
            MoveTimer = ResetTimer;
           
            transform.eulerAngles = Vector3.forward * 180;
        }
        if (Input.GetKeyDown(KeyCode.D)  && !(drown || runover) && direction == ' ' && transform.position.x < 6.5)
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
            Debug.Log(frames);
        }
        if (direction == 'a')
        {
            gameObject.transform.position -= new Vector3((float)(1 / (float)maxFrames), 0, 0);
            frames++;
            Debug.Log(frames);
        }
        if (direction == 's')
        {
            gameObject.transform.position -= new Vector3(0, (float)(1 / (float)maxFrames), 0);
            frames++;
            Debug.Log(frames);
        }
        if (direction == 'd')
        {
            gameObject.transform.position += new Vector3((float)(1 / (float)maxFrames), 0, 0);
            frames++;
            Debug.Log(frames);
        }

        if (frames >= maxFrames && !(drown || runover))
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
            
            transform.position += new Vector3(speed * 60 / (1 / Time.deltaTime), 0, 0);
            Debug.Log("logiscolliding");
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
        runover = false;
        drown = false;
    }
    private void onPlayerRunOver()
    {
        GetComponents<AudioSource>()[2].Play();
        frames = 0;
        direction = ' ';
        logmover = false;
        runover = true;
    }
    private void onPlayerDrown()
    {
        Debug.Log("WORKED");
        GetComponents<AudioSource>()[1].Play();
        frames = 0;
        direction = ' ';
        logmover = false;
        drown = true;
    }

}
