using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    float timer = 16;
    public GameObject car;
    SpriteRenderer spriteRenderer;
    public Sprite turtle1;
    public Sprite turtle2;
    public Sprite turtle3;
    public Sprite turtle4;
    public Sprite turtle5;
    public float respawnAtX = 8;
    public bool checkpls = false;
    public bool drowners = false;
    public bool dissablecollider = false;
    public float speed;
    float sinkTimer = 0;
    int playAlong = 0;
    bool play = false;
    public int sinkPhase = 1;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == ("player"))
        {
            checkpls = true;
            // Debug.Log("yes");
            dissablecollider = true;
        }
        else
        {
            dissablecollider = false;
            // Debug.Log("bruh");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (checkpls == true)
        {
            // Debug.Log("uououououoo");
        }
        if(drowners)
        {
                if(play)
                {
                    if (timer % 48 == 0)
                    {
                        playAlong++;
                        spriteRenderer.sprite = turtle1;
                    }
                    if (timer % 48 == 16)
                    {
                        playAlong++;
                        spriteRenderer.sprite = turtle2;
                    }
                    if (timer % 48 == 32)
                    {
                        playAlong++;
                        spriteRenderer.sprite = turtle3;
                    }
                    if (playAlong >= 3)
                    {
                        playAlong = 0;
                        sinkTimer = timer;
                        play = false;
                    }
                }
                else
            {
                if (sinkTimer % 56 == 00 && sinkPhase == 0)
                {
                    sinkPhase++;
                    spriteRenderer.sprite = turtle4;
                }
                if ((sinkTimer % 56 == 24 && sinkPhase == 1)|| (sinkTimer % 56 == 48 && sinkPhase == 3))
                {
                    sinkPhase++;
                    spriteRenderer.sprite = turtle5;
                }
                if (sinkTimer % 56 == 40 && sinkPhase == 2)
                {
                    sinkPhase++;
                    spriteRenderer.sprite = null;
                }
                if (sinkTimer % 56 == 0 && sinkPhase == 4)
                {
                    play = true;
                    spriteRenderer.sprite = turtle4;
                    sinkPhase = 0;
                }
            }
        }
        else
        {
            if (timer % 48 == 0)
                spriteRenderer.sprite = turtle1;
            if (timer % 48 == 16)
                spriteRenderer.sprite = turtle2;
            if (timer % 48 == 32)
                spriteRenderer.sprite = turtle3;
        }

        transform.position += new Vector3(speed * 60 / (1 / Time.deltaTime), 0, 0);
        if (speed > 0)
        {
            if (transform.position.x >= respawnAtX)
                transform.position = new Vector3(-respawnAtX, transform.position.y, transform.position.z);
        }
        else if (speed < 0)
        {
            if (transform.position.x <= respawnAtX)
                transform.position = new Vector3(-respawnAtX, transform.position.y, transform.position.z);
        }
        if (checkpls)
        {

        }
        timer++;
        sinkTimer++;
    }
}