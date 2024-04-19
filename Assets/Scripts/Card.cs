using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    #region 카드 초기화하기

    public int myIndex;
    public SpriteRenderer myFrontRenderer;
    public void Setting(int ind)
    {
        myIndex = ind;
        myFrontRenderer.sprite = Resources.Load<Sprite>($"rtan{myIndex}");

        /// 유니티에서 기본적으로 제공하는 기능입니다!
        /// 
        /// Assets/Resources 폴더 내에 있는 리소스에 상대 경로를 통해 접근할 수 있습니다.
        /// 
        /// Resources.Load<불러올_리소스의_자료형>("Resources 폴더 내에서의 상대 경로")
    }

    #endregion

    #region 카드 뒤집기

    public GameObject frontObj;
    public GameObject backObj;
    public Animator myAnim;
    public void OpenCard()
    {
        myAnim.SetBool("isOpen", true);
        frontObj.SetActive(true);
        backObj.SetActive(false);

        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        else
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.isMatched();
        }
    }

    #endregion

    #region 카드 파괴하기

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 0.5f);
    }
    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    #endregion

    #region 카드 다시 뒷면으로 표시하기

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }
    void CloseCardInvoke()
    {
        myAnim.SetBool("isOpen", false);
        frontObj.SetActive(false);
        backObj.SetActive(true);
    }

    #endregion
}
