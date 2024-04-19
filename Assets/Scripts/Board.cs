using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject myPrefab;
    void Start()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

        arr = arr.OrderBy(x => Random.Range(-1f, 1f)).ToArray(); 

        /// LINQ 기능, 그냥 배열을 랜덤으로 섞어줬다고 생각해주세요!
        /// 추가로, LINQ를 사용하지 않고 어떻게 랜덤하게 섞어줄까? 하는 방법에 대해 고민해보는 것도 좋습니다.

        for (int i = 0; i < 16; i++)
        {
            GameObject tempObj = Instantiate(myPrefab, this.transform);

            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.0f;

            tempObj.transform.position = new Vector2(x, y);
            tempObj.GetComponent<Card>().Setting(arr[i]);

            /// GetComponent
            /// 
            /// 현재 접근한 게임 오브젝트 인스턴스, 혹은 접근한 컴포넌트 인스턴스가 부착되어있는 게임 오브젝트 인스턴스에 대해
            /// 
            /// 해당 게임 오브젝트 인스턴스에 부착되어있는 <접근하려는_컴포넌트_자료형>에 맞는 컴포넌트 인스턴스에 접근합니다.
            /// (여기선 Card 컴포넌트가 되겠죠?)
        }

        GameManager.Instance.CardCnt = arr.Length;

        /// Q. GameManager.Instance 라고만 써도 게임 매니져에 접근할 수 있는 이유가 뭘까요?
        /// 
        /// A. 정적 변수로 Instance를 선언해줬기 때문에, GameManager 클래스 자체에서 Instance를 접근할 수 있습니다.
        /// 
        /// 자세한 설명은 GameManager 클래스에 다시 적어놨습니다!
    }
}
