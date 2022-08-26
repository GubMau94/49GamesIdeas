using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positions : MonoBehaviour
{
    private GameManager gameManager;
    private bool onCollision, checkDone;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        checkDone = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Button"))
        {
            onCollision = true;
        }        
    }

    private void LateUpdate()
    {
        if (!onCollision && !checkDone)
        {
            gameManager.FillEmptyPositionCoords(transform.position);
            gameManager.checkEmptyDone = true;
            checkDone = true;
            print("name: " + gameObject.name);
        }
    }
}
