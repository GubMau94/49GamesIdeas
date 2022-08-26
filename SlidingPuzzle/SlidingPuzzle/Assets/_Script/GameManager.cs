using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform buttonParent, positionParent;

    private Transform[] buttons, positions;
    private Vector2[] buttonsCoords, positionsCoords;

    private Vector2 emptyPositionCoords;
    public bool checkEmptyDone;

    private Button[] buttonsOnGame;

    private float x, y;

    // Start is called before the first frame update
    void Start()
    {
        StoreAllButtonsAndPositions();
        SaveButtonsAndPositionsCoord();

        buttonsOnGame = FindObjectsOfType<Button>();
        for(int i = 0; i < buttonsOnGame.Length; i++)
        {
            buttonsOnGame[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        FindNearestButtons();
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
    /// Salvo le coordinate delle posizioni e dei pulsanti
    /// </summary>
    private void SaveButtonsAndPositionsCoord()
    {
        buttonsCoords = new Vector2[buttons.Length];
        for(int i = 0; i < buttons.Length; i++)
        {
            buttonsCoords[i] = buttons[i].transform.position;
        }

        positionsCoords = new Vector2[positions.Length];
        for (int i = 0; i < positions.Length; i++)
        {
            positionsCoords[i] = positions[i].transform.position;
        }
    }

    /// <summary>
    /// Trova il/i pulsanti più vicino/i alla posizione vuota e lo/li abilita
    /// </summary>
    private void FindNearestButtons()
    {
        if (checkEmptyDone)
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

        FindNearestButtons();
    }

    /// <summary>
    /// Trova le coordinate della posizione vuota
    /// </summary>
    /// <param name="posCoords">coordinate della posizione</param>
    public void FillEmptyPositionCoords(Vector2 posCoords)
    {
        emptyPositionCoords = posCoords;
    }
}
