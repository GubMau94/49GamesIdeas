using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddieManager : MonoBehaviour
{
    [SerializeField]
    private int points;

    private int baddieSpeed;
    private int movementType;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        baddieSpeed = Random.Range(1, 10);
        movementType = gameManager.SpawnerUsed();
    }

    // Update is called once per frame
    void Update()
    {
        MovementType(baddieSpeed, movementType);
    }

    /// <summary>
    /// Gestisce la direzione in cui muovere il nemico
    /// </summary>
    /// <param name="speed">velocità con cui si muoverà</param>
    /// <param name="type">direzione verso la quale si muoverà (0: up, 1: down, 2: left, 3: right)</param>
    private void MovementType(int speed, int type)
    {
        switch (type)
        {
            case 0:
                transform.position += Vector3.down * speed * Time.deltaTime;
                break;

            case 1:
                transform.position += Vector3.up * speed * Time.deltaTime;
                break;

            case 2:
                transform.position += Vector3.right * speed * Time.deltaTime;
                break;

            case 3:
                transform.position += Vector3.left * speed * Time.deltaTime;
                break;

            default:
                transform.position += Vector3.zero;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Field"))
        {
            gameManager.ScoreIncrease(points);
            Destroy(gameObject);
        }
    }

}
