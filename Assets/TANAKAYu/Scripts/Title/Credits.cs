using UnityEngine;
using UnityEngine.Events;

public class Credits : OverlapScene
{
    private void Update()
    {
        if (!canControl)
        {
            return;
        }
        
        // 閉じるチェック
        if (Input.GetButtonDown("Cancel"))
        {
            Hide();
        }
    }
}
