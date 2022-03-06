using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScene : MonoBehaviour
{
    public void Move2InOrTr()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
