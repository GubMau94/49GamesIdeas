using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform buttonParent, positionParent;
    [SerializeField] private GameObject winGroup;
    [SerializeField] private Button restartButton;

    private Transform[] buttons, positions;
    private Vector2[] buttonsCoordsShuffle;

    private Vector2 emptyPositionCoords;

    private Button[] buttonsOnGame;

    private float x, y;

    // Start is called before the first frame update
    void Start()
    {
        StoreAllButtonsAndPositions();
        ShuffleButtonsPositions();

        FindEmptyPosCoords();

        buttonsOnGame = FindObjectsOfType<Button>();
        for(int i = 0; i < buttonsOnGame.Length; i++)
        {
            buttonsOnGame[i].enabled = false;
        }

        FindNearestButtons();    
        
        winGroup.SetActive(false);
    }

    /// <summary>
    /// Trova le coordinate della posizoine vuota
    /// </summary>
    private void FindEmptyPosCoords()
    {
        for(int i = 0; i < positions.Length; i++)
        {
            for(int j = 0; j < buttons.Length; j++)
            {
                if(buttons[j].position == positions[i].position)
                {
                    //do nothing
                }
                else
                {
                    emptyPositionCoords = positions[i].position;
                }
            }
        }
    }

    /// <summary>
    /// Carico nell'array tutti i pulsanti e posizioni del campo da gioco
    /// </summary>
    private void StoreAllButtonsAndPositions()
    {
        buttons = new Transform[buttonParent.transform.childCount];
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i] = buttonParent.transform.GetChild(i);
        }

        positions = new Transform[positionParent.transform.childCount];
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = positionParent.transform.GetChild(i);
        }
    }

    /// <summary>
    /// Trova il/i pulsanti più vicino/i alla posizione vuota e lo/li abilita
    /// </summary>
    private void FindNearestButtons()
    {          
        for (int i = 0; i < buttons.Length; i++)
        {
            x = Mathf.Abs(buttons[i].transform.position.x - emptyPositionCoords.x);
            y = Mathf.Abs(buttons[i].transform.position.y - emptyPositionCoords.y);

            if ((x == 160 && y == 0) || (x == 0 && y == 160))
            {
                print("nome pulsante: " + buttons[i].name);
                for(int j = 0; j < buttonsOnGame.Length; j++)
                {
                    if (buttonsOnGame[j].name == buttons[i].name)
                    {
                        buttonsOnGame[j].enabled = true;
                    }
                }
            }
        }               
    }

    /// <summary>
    /// Mescola le posizioni dei pulsanti sul campo
    /// </summary>
    private void ShuffleButtonsPositions()
    {
        buttonsCoordsShuffle = new Vector2[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            buttonsCoordsShuffle[i] = buttons[i].transform.position;
        }

        for (int i = 0; i < buttonsCoordsShuffle.Length - 1; i++)
        {
            int rnd = Random.Range(i, buttonsCoordsShuffle.Length);
            Vector2 tempGO = buttonsCoordsShuffle[rnd];
            buttonsCoordsShuffle[rnd] = buttonsCoordsShuffle[i];
            buttonsCoordsShuffle[i] = tempGO;            
        }

        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].position = buttonsCoordsShuffle[i];
        }
    }

    /// <summary>
    /// Verifica se tutte le carte sono disposte nell'ordine giusto
    /// </summary>
    private void CheckWinConditions()
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            if(buttons[i].position == positions[i].position)
            {

            }
            else
            {
                print("non hai ancora vinto");
                return;
            }
        }

        print("hai vinto");
        restartButton.enabled = true;
        winGroup.SetActive(true);
    }

    /// <summary>
    /// Muove il pulsante alla posizione libera ed aggiorna la nuova posizione libera
    /// </summary>
    /// <param name="value">numero del pulsante</param>
    public void MoveButton(int value)
    {
        Vector2 actualPos = buttons[value - 1].transform.position;
        buttons[value - 1].transform.position = emptyPositionCoords;
        emptyPositionCoords = actualPos;

        for (int i = 0; i < buttonsOnGame.Length; i++)
        {
            buttonsOnGame[i].enabled = false;
        }

        CheckWinConditions();

        FindNearestButtons();        
    }

    /// <summary>
    /// Rincomincia la partita
    /// </summary>
    public void RestartMatch()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
