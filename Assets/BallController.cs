using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;

    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    //Score
    private int score = 0;

    //Score表示テキスト
    private GameObject ScoreText;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LargeStar")
        {
            score += 20;
        }
        if (collision.gameObject.tag == "SmallStar")
        {
            score += 30;
        }
        if (collision.gameObject.tag == "LargeCloud")
        {
            score += 50;
        }
        if (collision.gameObject.tag == "SmallCloud")
        {
            score += 40;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のScoreTextオブジェクトを取得
        this.ScoreText = GameObject.Find("ScoreText");
        
    }

    // Update is called once per frame
    void Update()
    {
        //Scoreを表示
        this.ScoreText.GetComponent<Text>().text = "Score:" + score;

        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameOverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }
}
