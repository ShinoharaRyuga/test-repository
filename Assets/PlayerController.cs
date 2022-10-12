//これはサンプルのクラスになります。
//参考にしてください。
//クラスを構成する変数や関数の順番は下記のとおりにしてください

//①constやシングルトンパターン（インスタント）を定義する
//②インスペクターで操作したい変数を定義する
//③private変数を定義する
//④public変数を定義する(プロパティも)
//⑤Unity標準の関数 (startやUpdate)
//⑥privete関数
//⑦public関数


using UnityEngine;

/// <summary>プレイヤーを管理する為のクラス </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>最大体力 </summary>
    const int MAX_LIFE = 5;

    [SerializeField, Header("ゲーム開始時のライフ")]
    int _startLife = 3;
    [SerializeField, Header("プレイヤーの移動速度")]
    float _moveSpeed = 5f;
    [SerializeField, Tooltip("ジャンプ力")]
    float _jumpPower = 10f;

    /// <summary>現在の体力 </summary>
    int _currentLife = 0;
    /// <summary>攻撃力 </summary>
    int _attackPower = 10;
    /// <summary>アイテムの所持数 </summary>
    int _currentItemCount = 0;

    /// <summary>現在の体力 </summary>
    public int CurrentLife { get => _currentLife; set => _currentLife = value; }
    /// <summary>攻撃力 </summary>
    public int AttackPower { get => _attackPower; set => _attackPower = value; }

    void Start()
    {
        _currentLife = _startLife;
    }

    void Update()
    {
        PlayerMove();
    }

    /// <summary>移動処理 </summary>
    private void PlayerMove()
    {
        //移動処理
    }

    /// <summary>敵からダメージを受ける </summary>
    public void GetDamage(int damage)
    {
         _currentLife -= damage;

        if (_currentLife <= 0)
        {
            Debug.Log("死");
        }
    }

    /// <summary>
    /// 敵にダメージを与える
    /// アニメーショントリガーで呼び出す
    /// </summary>
    public void Attack()
    {
        var hitObjects = Physics.OverlapSphere(Vector3.zero, 10f);  //範囲内のオブジェクトを取得

        foreach (var obj in hitObjects)
        {
            if (obj.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("ダメージ与える");
            }
        }
    }
}
