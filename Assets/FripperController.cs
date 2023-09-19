using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //hingeJopintコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20.0f;
    //弾いた時の傾き
    private float flickAngle = -20.0f;

    // Start is called before the first frame update
    void Start()
    {

        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle (this.defaultAngle);

    }

    // Update is called once per frame
    void Update()
    {
        //左矢印キー、Aキーを押した時左フリッパーを動かす
        if(Input.GetKeyDown(KeyCode.LeftArrow)&& tag == "LeftFripperTag"||Input.GetKeyDown(KeyCode.A)&& tag == "LeftFripperTag")
        {
            SetAngle (this.flickAngle);
        }
        //右矢印キー、Dキーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow)&& tag == "RightFripperTag"||Input.GetKeyDown(KeyCode.D)&& tag== "RightFripperTag")
        {
            SetAngle(this.flickAngle);

        }
        //S,下矢印キーを押した時左右のフリッパーを動かす
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー,A,Dキーが離された時フリッパーを元に戻す
        if(Input.GetKeyUp(KeyCode.LeftArrow)&& tag == "LeftFripperTag"||Input.GetKeyUp(KeyCode.A)&& tag== "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);

        }
        if(Input.GetKeyUp(KeyCode.RightArrow)&& tag == "RightFripperTag" || Input.GetKeyUp(KeyCode.D) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        // Sキーまたは下矢印キーが離された時、左右のフリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            SetAngle(this.defaultAngle);
        }

        //タッチ操作
        for(int i =0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            //タッチした時
            if (touch.phase == TouchPhase.Began)
            {
                //画面左半分だった時、左フリッパーを動かす
                if(touch.position.x < Screen.width/2 && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                }

                //画面右半分だった時、右フリッパーを動かす
                if(touch.position.x > Screen.width/2 && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
            }

            //タッチが離された時
            if (touch.phase == TouchPhase.Ended)
            {
                //離したのが左半分だった時、左フリッパーを戻す
                if (touch.position.x < Screen.width/2 && tag == "LeftFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }

                //離したのが右半分だった時、右フリッパーを戻す
                if(touch.position.x > Screen.width/2 && tag == "RightFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
            }
        }
        
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
