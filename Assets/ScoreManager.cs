using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;

    public static void AddPoints(string tag)
    {
        //得点
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

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
