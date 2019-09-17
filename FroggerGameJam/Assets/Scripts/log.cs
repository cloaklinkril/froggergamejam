using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : MonoBehaviour
{
 public float timer;
 float timertemp;
 public GameObject car;
 public Vector3 bruh;
 public bool checkpls = false;
 public bool dissablecollider = false;
    public float speed;

    // Start is called before the first frame update
void Start()
{
    timertemp = timer;
    bruh = transform.position;
}

private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.name == ("player"))
    {
            checkpls = true;
            Debug.Log("yes");
            dissablecollider = true;
    }
    else
    {
            dissablecollider = false;
            Debug.Log("bruh");
    }
}

// Update is called once per frame
void Update()
{
    if (checkpls==true)
    {
            Debug.Log("uououououoo");
    }
    
    timer -= Time.deltaTime;
    transform.position += new Vector3(speed, 0, 0);
    if (timer <= 0)
    {
        transform.position = bruh;

        timer = timertemp;
    }
    if (checkpls)
    {

    }

}
}
