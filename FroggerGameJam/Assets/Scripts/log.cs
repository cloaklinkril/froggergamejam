using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : MonoBehaviour
{
 public float timer;
 float timertemp;
 public GameObject car;
    public float respawnAtX = 8;
    public bool checkpls = false;
 public bool dissablecollider = false;
    public float speed;

    // Start is called before the first frame update
void Start()
{
    timertemp = timer;
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
    if (checkpls==true)
    {
            // Debug.Log("uououououoo");
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

}
}
