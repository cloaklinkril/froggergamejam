using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cars : MonoBehaviour
{
    public float timer;
    float timertemp;
    public GameObject car;
    public float x;
    public float y;
    public float z;
    // Start is called before the first frame update
    void Start()
    {
        timertemp = timer;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == ("player"))
        {
            Destroy(car);
            Debug.Log("lkdskdskjldsfjkljkdsfkjlfkljfkjlfdsjkl");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        transform.position += new Vector3(0.09f, 0, 0);
        if(timer<=0)
        {
            transform.position = new Vector3(x, y, z);

            timer = timertemp;   
        }
    }
}
