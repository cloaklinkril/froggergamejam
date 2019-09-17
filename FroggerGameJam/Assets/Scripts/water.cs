using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    public GameObject player;
    public bool part1 = false;
    public bool part2 = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //var logo = FindObjectOfType<log>();
        //if(logo.checkpls == true)
        //{
        //    part2 = true;
        //}
        //
        //if(part1&&part2)
        //{
        //    Destroy(player);
        //}
    }
}
