using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int myIndex;
    public SpriteRenderer myFrontRenderer;
    public void Setting(int ind)
    {
        myIndex = ind;
        myFrontRenderer.sprite = Resources.Load<Sprite>($"rtan{myIndex}");
    }

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

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 0.5f);
    }
    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

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
}
