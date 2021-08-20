using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;


    void Start()
    {
        //このGameObjectのHingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの初期の傾きを設定
        SetAngleDefault();
    }

    void Update()
    {

        //左矢印キーを押した時このGameObjectが左フリッパーなら動かす
        //このスクリプトが張り付いている左右のフリッパーを区別するのにtagを使っている
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngleFlick();
        }
        //右矢印キーを押した時このGameObjectが右フリッパーなら動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngleFlick();
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngleDefault();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngleDefault();
        }
    }

    //フリッパーの初期の傾きに戻す
    public void SetAngleDefault()
    {
        //JointSpringは構造体なので値型だから後で入れ直してる
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = this.defaultAngle;
        this.myHingeJoint.spring = jointSpr;
    }

    //フリッパーの弾いた時の傾きに戻す
    public void SetAngleFlick()
    {
        //JointSpringは構造体なので値型だから後で入れ直してる
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = this.flickAngle;
        this.myHingeJoint.spring = jointSpr;
    }


}
