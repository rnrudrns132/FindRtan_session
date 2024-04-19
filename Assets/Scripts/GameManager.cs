using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public void Awake()
    {
        Time.timeScale = 1;
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public Text timeText; 
    float time = 0.0f;

    private void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("N2");
        if (time >= 3)
        {
            GameOver();
        }
    }

    public Card firstCard;
    public Card secondCard;
    public int CardCnt;
    public GameObject EndText;
    public void isMatched()
    {
        if (firstCard.myIndex == secondCard.myIndex)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            CardCnt -= 2;
            if (CardCnt == 0)
            {
                GameOver();
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
        firstCard = null;
        secondCard = null;
    }

    void GameOver()
    {
        EndText.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
