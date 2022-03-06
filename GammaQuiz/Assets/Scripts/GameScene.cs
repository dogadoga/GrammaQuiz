using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Text
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    public static int score = 0;//score
    private int number = 0;
    private int answer = 100;
    public Text scoreText;
    public Text numberText;
    public Text wordText;
    public Text seikaiText;
    //public GameObject Seikai;
    //public GameObject Fuseikai;
    private bool gameEnd=false;
    private Dictionary<string,int> InOrTr = new Dictionary<string, int>()
        {
            {"Address",0 },
            {"Answer",0 },
            {"Approach",0 },
            {"Attend",0 },
            {"Discuss",0},
            {"Enter(場所に入る)",0 },
            {"Excel",0 },
            {"Leave(去る)",0 },
            {"Marry",0 },
            {"Obey",0 },
            {"Oppose",0},
            {"Reach(到達する)",0 },
            {"Resemble",0 },
            {"Apologize",1 },
            {"Graduate",1 },
            {"Hope",1 },
            {"Reply",1 },
            {"Talk",1 },
            {"Think",1 },
            {"Wait",1 }
        };
    private string[] intrary = new string[] {"Address","Answer","Approach",
    "Attend","Discuss","Enter(場所に入る)","Excel","Leave(去る)","Marry","Obey","Oppose","Reach(到達する)",
    "Resemble","Apologize","Graduate","Hope","Reply","Talk","Think","Wait" };

    // Start is called before the first frame update
    void Start()
    {
        RandomizeAry();
        score = 0;
        number = 0;
        answer = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnd == false)
        {
            if (number != intrary.Length - 1) //ゲーム終了判定
            {
                scoreText.text = "Score:" + score.ToString();
                numberText.text = "Number" + (number + 1).ToString() + "/" + intrary.Length.ToString();
                wordText.text = intrary[number];
                //Debug.Log(intrary[number]);
                //Debug.Log(number);
                if (answer == 0 || answer == 1)
                {
                    Debug.Log(intrary[number-1]);
                    Debug.Log("正解は"+InOrTr[intrary[number]].ToString()+"解答は"+answer.ToString());
                    Debug.Log("問題番号"+number.ToString());
                    if (InOrTr[intrary[number-1]] == answer)//正解判定
                    {
                        score++;
                        seikaiText.text = "正解！\n"+ intrary[number - 1]+"は"+JudgeIOT(InOrTr[intrary[number]]);
                    }
                    else
                    {
                        seikaiText.text = "誤り\n"+ intrary[number - 1]+"は"+JudgeIOT(InOrTr[intrary[number]]);
                    }
                    answer = 10;
                }

            }
            else
            {
                gameEnd = true;
            }
        }
        else
        {
            Move2Rezult();
        }
    }

    private void StartInOrTr()
    {
        
    }

    public void Move2Rezult()
    {
        SceneManager.LoadScene("ResultScene");
    }

    private void RandomizeAry()
    {
        System.Random rng = new System.Random();
        int n = intrary.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            string tmp = intrary[k];
            intrary[k] = intrary[n];
            intrary[n] = tmp;
        }
    }

    public void PushIntransitive()
    {
        answer = 1;
        number++;
    }

    public void PushTransitive()
    {
        answer = 0;
        number++;
    }

    public string JudgeIOT(int a)
    {
        if (a == 1) return "自動詞";
        else if (a == 0) return "他動詞";
        else return "";
    }
}
