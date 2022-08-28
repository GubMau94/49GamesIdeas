using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Lo scopo del gioco è quello di cliccare sui colori in ordine corretto precedentemente mostrati
//Numerazione dei bottoni:
//    1 --> giallo
//    2 --> blu
//    3 --> verde
//    4 --> rosso


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject buttonParent;
    private Button[] buttons;

    [SerializeField] private TMP_Text roundText, gameStatusText;
    [SerializeField] private Button gameExplainButton;

    [SerializeField] private float timerOn, timerOff;

    private gameStatus status;
    private enum gameStatus
    {
        loading,
        showingColors,
        playing,
        pause,
        gameOver
    }

    private int actualRound, index, indexPattern;
    private bool patternCorrect;

    private List<int> patternList = new List<int>();


    // Start is called before the first frame update
    void Start()
    {
        buttons = buttonParent.GetComponentsInChildren<Button>();

        //All'inizio della partita imposta l'alpha di tutti i pulsanti a 0.4
        for(int i = 0; i < buttons.Length; i++)
        {
            ReduceButtonAlpha(i);
        }

        actualRound = 0;
        indexPattern = 0;
        roundText.text = "Round: " + actualRound;        

        status = gameStatus.loading;
    }

    // Update is called once per frame
    void Update()
    {
        GameStatusTextDisplay();
        EnableDisableButtons();
        UpdateActualRound();        
    }

    /// <summary>
    /// Riduce l'alpha del pulsante a 0.4
    /// </summary>
    /// <param name="buttonNum">pulsante su cui operare</param>
    private void ReduceButtonAlpha(int buttonNum)
    {
        Color tmpAlpha = buttons[buttonNum].image.color;
        tmpAlpha.a = 0.40f;
        buttons[buttonNum].image.color = tmpAlpha;
    }

    /// <summary>
    /// Aumenta l'alpha del pulsante a 1.0
    /// </summary>
    /// <param name="buttonNum">pulsante su cui operare</param>
    private void IncreaseButtonsAlpha(int buttonNum)
    {
        Color tmpAlpha = buttons[buttonNum].image.color;
        tmpAlpha.a = 1.0f;
        buttons[buttonNum].image.color = tmpAlpha;
    }

    /// <summary>
    /// Illumina i pulsanti in un ordine casuali in base al livello attuale
    /// </summary>
    /// <returns></returns>
    private IEnumerator ColorsLogic()
    {
        if(status == gameStatus.showingColors)
        {
            for(int i = 0; i < actualRound; i++)
            {
                index = Random.Range(0, 4);
                
                IncreaseButtonsAlpha(index);
                yield return new WaitForSeconds(timerOn);

                ReduceButtonAlpha(index);
                yield return new WaitForSeconds(timerOff);

                patternList.Add(index);
            }            
        }

        status = gameStatus.playing;
    }

    /// <summary>
    /// Mostra a schermo lo stato del gioco
    /// </summary>
    private void GameStatusTextDisplay()
    {
        if (status == gameStatus.showingColors)
        {
            gameStatusText.text = "Displaying pattern...";
        }

        if (status == gameStatus.playing)
        {
            gameStatusText.text = "Repeat pattern...";
        }

        if(status == gameStatus.loading)
        {
            gameStatusText.text = "";
        }
    }

    /// <summary>
    /// Abilita e disabilita i pulsanti in base allo stato del gioco
    /// </summary>
    private void EnableDisableButtons()
    {
        if(status == gameStatus.showingColors)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].enabled = false;
            }
        }

        if (status == gameStatus.playing)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].enabled = true;
            }
        }

        if (status == gameStatus.loading)
        {
            gameExplainButton.enabled = true;

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].enabled = false;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void UpdateActualRound()
    {
        roundText.text = "Round: " + actualRound;

        if (patternCorrect)
        {
            actualRound++;
            patternCorrect = false;

            status = gameStatus.showingColors;
            StartCoroutine(ColorsLogic());
        }
    }

    private IEnumerator ButtonClick(int buttonNum)
    {
        IncreaseButtonsAlpha(buttonNum);
        yield return new WaitForSeconds(0.3f);

        ReduceButtonAlpha(buttonNum);

        if(buttonNum == patternList[indexPattern])
        {
            indexPattern++;
            print("corretto");
        }
        else
        {
            print("game over");
        }

        if(indexPattern == actualRound)
        {
            indexPattern = 0;
            patternCorrect = true;
            patternList.Clear();
        }
    }

    /// <summary>
    /// Avvia la coroutine ButtonClick
    /// </summary>
    /// <param name="buttonNum">numero del puslante premuto</param>
    public void StartButtonCoroutine(int buttonNum)
    {
        StartCoroutine(ButtonClick(buttonNum -1));
    }    

    /// <summary>
    /// Chiude la schermata delle istruzioni ed inizializza la partita
    /// </summary>
    public void StartMatch()
    {
        actualRound = 1;

        status = gameStatus.showingColors;
        gameExplainButton.gameObject.SetActive(false);

        StartCoroutine(ColorsLogic());
    }
}
