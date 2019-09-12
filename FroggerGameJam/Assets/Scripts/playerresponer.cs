using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerresponer : MonoBehaviour
{
    Transform player;
    Vector3 respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        player = transform;
        respawnPoint = player.position;

    }

    public void returntospawn()
    {
        player.position = respawnPoint;
    }
}
