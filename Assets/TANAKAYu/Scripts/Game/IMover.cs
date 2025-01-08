using UnityEngine;

public interface IMover
{
    /// <summary>
    /// 0-1の大きさの移動ベクトルを受け取って、移動させる。
    /// </summary>
    /// <param name="move">0-1の範囲の移動方向ベクトル</param>
    void Move(Vector2 move);
}
