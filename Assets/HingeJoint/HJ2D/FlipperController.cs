using UnityEngine;

/// <summary>
/// フリッパーを操作する 
/// フリッパーの角度制限はインスペクターから
/// 設定した方が分かりやすいと思う
/// </summary>
public class FlipperController : MonoBehaviour
{
    [SerializeField, Tooltip("左フリッパー")] HingeJoint2D _leftFlipper = default;
    [SerializeField, Tooltip("右フリッパー")] HingeJoint2D _rightFlipper = default;
    [SerializeField, Header("フリッパーの移動速度")] float _flipperSpeed = 500;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))　//左フリッパーを操作　押している間は上げた状態を維持する
        {
            LeftUp();
        }
        else
        {
            LeftDown();
        }

        if (Input.GetKey(KeyCode.D))  //右フリッパーを操作
        {
            RightUp();
        }
        else 
        {
            RightDown();
        }
    }

    /// <summary>
    /// 右フリッパーを上げる 
    /// </summary>
    void RightUp()
    {
        _rightFlipper.useMotor = true;              //フリッパーに力を加える
        JointMotor2D moter = _rightFlipper.motor;　 //JointMotor2Dを使わないとフリッパーの移動速度を変更出来ない　
        moter.motorSpeed = _flipperSpeed;
        _rightFlipper.motor = moter;                //変更した速度を適用する
    }

    /// <summary>
    /// 右フリッパーを下げる 
    /// </summary>
    void RightDown()
    {
        _rightFlipper.useMotor = false;　
        JointMotor2D moter = _rightFlipper.motor;
        moter.motorSpeed = -_flipperSpeed;　        //フリッパーを下げる為にマイナスの値にする　
        _rightFlipper.motor = moter;
    }

    /// <summary>
    /// 左フリッパーを上げる 
    /// </summary>
    void LeftUp()
    {
        _leftFlipper.useMotor = true;
        JointMotor2D moter = _leftFlipper.motor;
        moter.motorSpeed = -_flipperSpeed;          //右とは逆の動きをさせる為にマイナスの値にする
        _leftFlipper.motor = moter;
    }

    /// <summary>
    /// 左フリッパーを下げる 
    /// </summary>
    void LeftDown()
    {
        _leftFlipper.useMotor= false;
        JointMotor2D moter = _leftFlipper.motor;
        moter.motorSpeed = _flipperSpeed;          
        _leftFlipper.motor = moter;
    }
}
