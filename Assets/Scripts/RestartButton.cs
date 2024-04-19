using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(0);

        ///0번 인덱스의 씬을 다시 불러오는 것으로 게임을 다시 시작합니다.
        ///
        ///유니티 왼쪽 위 > File > Build Settings > Scene In Build 에 씬을 추가하고,
        ///
        ///오른쪽에 표시되는 인덱스를 통해 원하는 씬을 불러올 수 있습니다.
    }
}
