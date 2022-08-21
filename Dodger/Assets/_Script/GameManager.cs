using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawner; //0: up, 1: down, 2: left, 3: right

    [SerializeField]
    private GameObject[] baddiePrefabs;

    [SerializeField]
    private TMP_Text time, score, scoreHigh;

    [SerializeField]
    private GameObject power;

    private int indexEnemy, indexSpawner, actualScore;
    private Vector3 offsetSpawn;

    private bool spawnDone;
    private float spawnTime, spawnReductionTime, spawnReductionCountdown, powerSpawnTime, min, sec;

    private const float maxSpawnPos = 5.0f, minSpawnPos = -5.0f;
    private const string HIGHEST_SCORE = "HIGHEST_SCORE"; 

    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + 0;
        scoreHigh.text = "High Score: " + PlayerPrefs.GetInt(HIGHEST_SCORE);
    }

    // Update is called once per frame
    void Update()
    {
        DelaySpawn();
        GameTime();
        ScoreManager();
        SpawnPower();
    }

    #region PRIVATE FUNCTIONS

    /// <summary>
    /// Gestisce la posizione di evocazione dei mostri
    /// </summary>
    private void Spawner()
    {
        indexEnemy = Random.Range(0, baddiePrefabs.Length);
        indexSpawner = Random.Range(0, spawner.Length);

        if(indexSpawner == 0 || indexSpawner == 1)
        {
            offsetSpawn = new Vector3(Random.Range(minSpawnPos, maxSpawnPos), transform.position.y, transform.position.z);
        }
        else if(indexSpawner == 2 || indexSpawner == 3)
        {
            offsetSpawn = new Vector3(transform.position.x, Random.Range(minSpawnPos, maxSpawnPos), transform.position.z);
        }

        Instantiate(baddiePrefabs[indexEnemy], spawner[indexSpawner].transform.position + offsetSpawn, Quaternion.identity);

        spawnDone = true;
    }

    /// <summary>
    /// Gestisce ogni quanto devono essere evocati i mostri
    /// </summary>
    private void DelaySpawn()
    {
        if (!spawnDone)
        {
            spawnTime += Time.deltaTime;
        }

        if(spawnTime >= (2.0f - spawnReductionTime))
        {
            spawnTime = 0;
            Spawner();
            spawnDone = false;            
        }

        spawnReductionCountdown += Time.deltaTime;
        if(spawnReductionCountdown >= 15.0f )
        {
            spawnReductionCountdown = 0;

            if(spawnReductionTime < 1.9f)
            {
                spawnReductionTime += 0.1f;
            }            
        }
    }

    /// <summary>
    /// Gestisce il tempo trascorso del gioco
    /// </summary>
    private void GameTime()
    {
        sec += Time.deltaTime;
        if(sec >= 60)
        {
            min++;
            sec = 0;
        }

        time.text = min + "' " + Mathf.FloorToInt(sec) + "''"; 
    }

    /// <summary>
    /// Gestisce la pubblicazione del punteggio attuale e massimo
    /// </summary>
    private void ScoreManager()
    {
        score.text = "Score: " + actualScore;

        if (actualScore > PlayerPrefs.GetInt(HIGHEST_SCORE))
        {
            PlayerPrefs.SetInt(HIGHEST_SCORE, actualScore);
            scoreHigh.text = "High Score: " + PlayerPrefs.GetInt(HIGHEST_SCORE);
        }
    }

    /// <summary>
    /// Instanzia il potere ogni 60 secondi
    /// </summary>
    private void SpawnPower()
    {
        powerSpawnTime += Time.deltaTime;
        if (powerSpawnTime >= 50.0f)
        {
            powerSpawnTime = 0;
            Instantiate(power, new Vector3(Random.Range(-4.75f, 4.75f), Random.Range(-4.75f, 4.75f), 0), Quaternion.identity);
        }
    }

    #endregion

    #region PUBLIC FUNCTIONS

    /// <summary>
    /// Rincomincia la partita
    /// </summary>
    public void RestartMatch()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Chiude il gioco
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Pubblica la posizione i cui vengono evocati i mostri
    /// </summary>
    /// <returns>0: up, 1: down, 2: left, 3: right</returns>
    public int SpawnerUsed()
    {
        return indexSpawner;
    }

    /// <summary>
    /// Incrementa il punteggio attuale in base al parametro
    /// </summary>
    /// <param name="score">di quanto aumentare il punteggio</param>
    public void ScoreIncrease(int score)
    {
        actualScore += score;
    }

    #endregion
}
