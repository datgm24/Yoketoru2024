using UnityEngine;

/// <summary>
/// 入力デバイスを取りまとめて制御するクラス
/// </summary>
public class InputController
{
    /// <summary>
    /// 対応する入力デバイスのインスタンスを定義
    /// </summary>
    IInput[] inputs = {
        new KeyInput(),
    };

    /// <summary>
    /// 更新処理を呼び出す。
    /// </summary>
    public void Update()
    {

    }

    /// <summary>
    /// FixedUpdateから呼び出して、入力デバイスから移動量を読み取って、返す。
    /// </summary>
    /// <returns>移動を指示するVector2の値</returns>
    public Vector2 GetAndClear()
    {
        return Vector2.zero;
    }
}
