using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{
    private GameObject playerObj = null;
    private GameObject transportObj = null;

    CapsuleCollider2D playerBody;
    // Start is called before the first frame update
    void Start()
    {
        if (playerObj == null)
        {
            playerObj = GameObject.Find("Player");
        }
        if (transportObj == null)
        {
           transportObj = GameObject.Find("TransportBack");
        }

        playerBody = playerObj.GetComponent<CapsuleCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        Teleport();
    }

    private void Teleport()
    {
        if (transform.localScale.x > 0 && playerBody.IsTouchingLayers(LayerMask.GetMask("Transportation")))
        {
            print("Hello");
            playerObj.transform.position = transportObj.transform.position;
        }
    }
}
