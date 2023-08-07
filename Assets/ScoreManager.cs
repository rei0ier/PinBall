using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //テキストを参照
    public Text ScoreText;


    //スコアの更新
    void UpdateScoreText()
    {
        ScoreText.text = "score: " + score;
    }
    public static ScoreManager instance;

    //スコア
    public static int score = 0;

   
    // Start is called before the first frame update
    void Awake()
    {

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }


    }
    public static void AddPoints(string tag)
    {

        //加算
        switch (tag)
        {
            case "SmallStarTag":
                score += 20;
                break;
            case "LargeStarTag":
                score += 10;
                break;
            case "SmallCloudTag":
                score += 30;
                break;
            case "LargeCloudTag":
                score += 40;
                break;

        }
        Debug.Log("score: " + score);
        instance.UpdateScoreText();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
