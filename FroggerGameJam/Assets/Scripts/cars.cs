using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cars : MonoBehaviour
{
    public GameObject car;
    public int respawnAtX = 8;
    public bool activate = false;
    public float Move;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == ("player"))
        {
            activate = true;
            Debug.Log("lkdskdskjldsfjkljkdsfkjlfkljfkjlfdsjkl");
        }
    }

    // Update is called once per frame
    void Update()
    {
        var logscript = FindObjectOfType<log>();
        transform.position += new Vector3(Move * 60 / (1 / Time.deltaTime), 0, 0);
        if (Move > 0)
        {
            if(transform.position.x >= respawnAtX)
                transform.position = new Vector3(-respawnAtX, transform.position.y, transform.position.z);
        }
        else if (Move < 0)
        {
            if (transform.position.x <= respawnAtX)
                transform.position = new Vector3(-respawnAtX, transform.position.y, transform.position.z);
        }
            if (activate && logscript.checkpls)
        {
            Destroy(car);
            activate = false;
        }
    }
}
