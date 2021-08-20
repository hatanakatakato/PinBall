using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    //GameObjectを宣言
    private GameObject rightFripper;
    private GameObject leftFripper;

    private void Start()
    {
        //同じシーンないのGameObjectの取得
        this.rightFripper = GameObject.Find("RightFripper");
        this.leftFripper = GameObject.Find("LeftFripper");
    }


    void Update()
    {

        //このフレームでのタッチ情報を取得
        Touch[] myTouches = Input.touches;

        //検出されている指の数だけ回す
        for (int i = 0; i < myTouches.Length; i++)
        {
            Debug.Log("タッチされています");

            //左画面タッチ開始
            if (myTouches[i].phase == TouchPhase.Began && myTouches[i].position.x <= Screen.width / 2)
            {
                this.leftFripper.GetComponent<FripperController>().SetAngleFlick();
            }

            //右画面タッチ開始
            if (myTouches[i].phase == TouchPhase.Began && myTouches[i].position.x > Screen.width / 2)
            {
                this.rightFripper.GetComponent<FripperController>().SetAngleFlick();

            }

            //左画面タッチ終了
            if (myTouches[i].phase == TouchPhase.Ended && myTouches[i].position.x <= Screen.width / 2)
            {
                this.leftFripper.GetComponent<FripperController>().SetAngleDefault();
            }

            //右画面タッチ終了
            if (myTouches[i].phase == TouchPhase.Ended && myTouches[i].position.x > Screen.width / 2)
            {
                this.rightFripper.GetComponent<FripperController>().SetAngleDefault();
            }

        }


    }
}
