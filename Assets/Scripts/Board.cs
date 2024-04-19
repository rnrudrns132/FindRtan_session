using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myPrefab;
    void Start()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

        arr = arr.OrderBy(x => Random.Range(-1f, 1f)).ToArray();

        for (int i = 0; i < 16; i++)
        {
            GameObject tempObj = Instantiate(myPrefab, this.transform);

            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.0f;

            tempObj.transform.position = new Vector2(x, y);
            tempObj.GetComponent<Card>().Setting(arr[i]);
        }

        GameManager.Instance.CardCnt = arr.Length;
    }
}
