using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    //objが持つpoint
    private int ScorePoint;
    //ScoreTextゲームオブジェクト用の宣言
    private GameObject scoreText;

    void Start()
    {
        //ScoreTextゲームオブジェクトををインスタンス化
        this.scoreText = GameObject.Find("ScoreText");

    }


    void OnCollisionEnter(Collision collision)
    {
        //TagによってgameObjectPointを変更
        switch (collision.gameObject.tag)
        {
            case "SmallStarTag":
                this.ScorePoint += 10;
                break;
            case "LargeStarTag":
                this.ScorePoint += 50;
                break;
            case "SmallCloudTag":
                this.ScorePoint += 30;
                break;
            case "LargeCloudTag":
                this.ScorePoint += 100;
                break;
        }


        this.scoreText.GetComponent<Text>().text = $"Score:{this.ScorePoint}";
    }




}
