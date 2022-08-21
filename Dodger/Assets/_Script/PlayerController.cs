using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(1, 50)]
    private int playerSpeed;

    [SerializeField]
    private GameObject gameOver;

    [SerializeField]
    private AudioClip gameOverClip;

    private BoxCollider2D _boxCollider;
    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;

    private Vector3 position;

    private float powerTime;
    private bool powerActive;

    // Start is called before the first frame update
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();

        gameOver.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement(playerSpeed);
        PowerManager();
    }

    /// <summary>
    /// Permette di muovere il player con le frecce direzionali
    /// </summary>
    /// <param name="speed">velocità con cui muovere il giocatore</param>
    private void PlayerMovement(int speed)
    {
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y <= 4.75f)
        {
            position = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y >= -4.75f)
        {
            position = Vector3.down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -4.75f)
        {
            position = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 4.75f)
        {
            position = Vector3.right;
        }
        else
        {
            position = Vector3.zero;
        }

        transform.position += position * speed * Time.deltaTime;
    }

    /// <summary>
    /// Gestisce la disattivazione del potere dopo 5 secondi
    /// </summary>
    private void PowerManager()
    {
        if (powerActive)
        {
            powerTime += Time.deltaTime;
            if(powerTime >= 5.0f)
            {
                powerTime = 0;
                powerActive = false;

                _boxCollider.enabled = true;

                Color tmp = _spriteRenderer.color;
                tmp.a = 1f;
                _spriteRenderer.color = tmp;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
            _audioSource.PlayOneShot(gameOverClip);
        }

        if (collision.CompareTag("Power"))
        {
            _boxCollider.enabled = false;
            
            Color tmp = _spriteRenderer.color;
            tmp.a = 0.48f;
            _spriteRenderer.color = tmp;

            powerActive = true;

            Destroy(collision.gameObject);
        }
    }
}
