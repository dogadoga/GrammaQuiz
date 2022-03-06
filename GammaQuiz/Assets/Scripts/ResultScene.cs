using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Text
using UnityEngine.SceneManagement;

public class ResultScene : MonoBehaviour
{
    public Text resultText;

    // Start is called before the first frame update
    void Start()
    {
        resultText.text = GameScene.score.ToString() + "/20";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void Retry()
    {
        SceneManager.LoadScene("GameScene");
    }

}
