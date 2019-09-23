using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHome : MonoBehaviour
{
    SpriteRenderer spriteR;
    public Sprite frog;
    // Start is called before the first frame update
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    public bool frogHome = false; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!frogHome)
            {
                spriteR.sprite = frog;
                frogHome = true;
                EventScript.current.GoalReached();
            }
        }
    }
}
