using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region 게임매니져를 초기화 해주는 부분입니다.

    /// static 키워드를 활용해, Instance를 변수를 정적 변수로 만듭니다.
    /// 
    /// 정적 변수의 경우, 해당 클래스를 기반으로 생성된 객체들이 모두 '공유하는' 변수가 됩니다.
    /// 
    /// 그렇기 때문에, 다른 객체에서 정적 변수에 접근할 때는 객체가 아닌 클래스 자체에서 접근을 할 수 있게 됩니다.
    /// 
    /// 어차피 어떤 객체에서 접근하든 동일한 데이터일 테니까요!

    public static GameManager Instance;

    public void Awake()
    {
        Time.timeScale = 1;
        if (Instance == null)
        {
            Instance = this;
        }
    }

    #endregion

    #region 게임의 진행 시간을 측정해주는 부분입니다.

    public Text timeText;
    float time = 0.0f;

    private void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("N2");
        if (time >= 30)
        {
            GameOver();
        }
    }

    #endregion

    #region 선택된 카드 두 개가 서로 같은 카드인지 판단하고, 그에 따라 적합한 행동을 해주는 부분입니다.
    
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

    #endregion

    // 게임 오버가 되면 아래 메서드가 실행됩니다.
    void GameOver()
    {
        EndText.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
