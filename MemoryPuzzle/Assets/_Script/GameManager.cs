using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Button[] buttons;

    [SerializeField]
    private RectTransform[] rectTransformImages;

    [SerializeField]
    private GameObject winGroup;

    private bool firstImageSelected, secondImageSelected;
    private int recordLoop, offsetX, offsetY, firstImageNumber, secondImageNumber, buttonOnePressedNum, buttonTwoPressedNum, randomNum;
    private List<int> numList = new List<int>();

    private const int mainImageNum = 24;

    // Start is called before the first frame update
    void Start()
    {
        firstImageSelected = false;
        secondImageSelected = false;

        winGroup.SetActive(false);

        FillNumberListAndShuffle();
        CardsDistribution();            
    }

    // Update is called once per frame
    void Update()
    {
        MatchCheck();
    }

    /// <summary>
    /// Dispone le carte sul piano da gioco
    /// </summary>
    private void CardsDistribution()
    {
        for (int i = 0; i < 8; i++)
        {
            offsetX = 0;
            for (int j = (0 + recordLoop); j < (6 + recordLoop); j++)
            {
                print("J:" + j);
                rectTransformImages[numList[j]].anchoredPosition = new Vector2(-227 + offsetX, 205 - offsetY);
                offsetX += 110;
            }
            recordLoop += 6;
            offsetY += 72;
        }
    }

    /// <summary>
    /// Verify if the cards are the same, otherwise turn it back
    /// </summary>
    private void MatchCheck()
    {
        if(firstImageSelected && secondImageSelected)
        {
            if (firstImageNumber == secondImageNumber)
            {
                print("WOW, COMPLIMENTI!!");
                firstImageSelected = false;
                secondImageSelected = false;

                DestroyButtonFinded(buttonOnePressedNum);
                DestroyButtonFinded(buttonTwoPressedNum);

                StartCoroutine(CheckButtonsAvailables());
            }
            else if (firstImageNumber != secondImageNumber)
            {
                print("PECCATO, RIPROVA!!");
                StartCoroutine(ButtonNotAlpha(buttonOnePressedNum));
                StartCoroutine(ButtonNotAlpha(buttonTwoPressedNum));
                firstImageSelected = false;
                secondImageSelected = false;
            }
        }
    }

    /// <summary>
    /// Verifica se ci sono ancora dei pulsanti, altrimenti decreta la fine della partita
    /// </summary>
    /// <returns></returns>
    private IEnumerator CheckButtonsAvailables()
    {
        yield return new WaitForSeconds(1);

        int buttonsNumber = FindObjectsOfType<Button>().Length;
        print("buttons remains: " + buttonsNumber);

        if(buttonsNumber == 0)
        {
            winGroup.SetActive(true);
        }
    }

    /// <summary>
    /// Turn on card
    /// </summary>
    /// <param name="buttonNum">card number</param>
    private void ButtonAlpha(int buttonNum)
    {
        buttons[buttonNum].enabled = false;
        buttons[buttonNum].image.enabled = false;
    }

    /// <summary>
    /// Rimuove dalla scena il pulsante
    /// </summary>
    /// <param name="buttonNum">numero del pulsante da rimuovere</param>
    private void DestroyButtonFinded(int buttonNum)
    {
        Destroy(buttons[buttonNum]);
    }

    /// <summary>
    /// Turn off card
    /// </summary>
    /// <param name="buttonNum">card number</param>
    /// <returns></returns>
    private IEnumerator ButtonNotAlpha(int buttonNum)
    {
        yield return new WaitForSeconds(0.8f);

        buttons[buttonNum].enabled = true;
        buttons[buttonNum].image.enabled = true;
    }

    /// <summary>
    /// Riempi di numeri la lista e li mescola, così da distribuire le immagini in modo casuale
    /// </summary>
    private void FillNumberListAndShuffle()
    {
        for(int i = 0; i < rectTransformImages.Length; i++)
        {
            numList.Add(i);
        }

        for (int i = 0; i < numList.Count - 1; i++)
        {
            int rnd = Random.Range(i, numList.Count);
            int tempGO = numList[rnd];
            numList[rnd] = numList[i];
            numList[i] = tempGO;
        }
    }

    /// <summary>
    /// Reinizia la partita
    /// </summary>
    public void RestartMatch()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    #region PUBLIC IMAGE BUTTONS

    public void Image_0()
    {
        int aux = 0;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }        
    }

    public void Image_1()
    {
        int aux = 1;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_2()
    {
        int aux = 2;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_3()
    {
        int aux = 3;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_4()
    {
        int aux = 4;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_5()
    {
        int aux = 5;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_6()
    {
        int aux = 6;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_7()
    {
        int aux = 7;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_8()
    {
        int aux = 8;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_9()
    {
        int aux = 9;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_10()
    {
        int aux = 10;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_11()
    {
        int aux = 11;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_12()
    {
        int aux = 12;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_13()
    {
        int aux = 13;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_14()
    {
        int aux = 14;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_15()
    {
        int aux = 15;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_16()
    {
        int aux = 16;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_17()
    {
        int aux = 17;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_18()
    {
        int aux = 18;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_19()
    {
        int aux = 19;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_20()
    {
        int aux = 20;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_21()
    {
        int aux = 21;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_22()
    {
        int aux = 22;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_23()
    {
        int aux = 23;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_24()
    {
        int aux = 24;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_25()
    {
        int aux = 25;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_26()
    {
        int aux = 26;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_27()
    {
        int aux = 27;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_28()
    {
        int aux = 28;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_29()
    {
        int aux = 29;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_30()
    {
        int aux = 30;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_31()
    {
        int aux = 31;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_32()
    {
        int aux = 32;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_33()
    {
        int aux = 33;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_34()
    {
        int aux = 34;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_35()
    {
        int aux = 35;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_36()
    {
        int aux = 36;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_37()
    {
        int aux = 37;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_38()
    {
        int aux = 38;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_39()
    {
        int aux = 39;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_40()
    {
        int aux = 40;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_41()
    {
        int aux = 41;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_42()
    {
        int aux = 42;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_43()
    {
        int aux = 43;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_44()
    {
        int aux = 44;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_45()
    {
        int aux = 45;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_46()
    {
        int aux = 46;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    public void Image_47()
    {
        int aux = 47;
        ButtonAlpha(aux);

        if (!secondImageSelected && firstImageSelected)
        {
            secondImageSelected = true;
            secondImageNumber = aux - mainImageNum;
            buttonTwoPressedNum = aux;
        }

        if (!firstImageSelected)
        {
            firstImageSelected = true;
            firstImageNumber = aux - mainImageNum;
            buttonOnePressedNum = aux;
        }
    }

    #endregion
}
