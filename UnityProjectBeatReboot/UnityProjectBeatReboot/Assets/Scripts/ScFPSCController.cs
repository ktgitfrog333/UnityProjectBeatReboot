using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FPSを有効・無効を切り替える
/// </summary>
public class ScFPSCController : MonoBehaviour
{
    /// <summary>FPSController</summary>
    [SerializeField] private GameObject _FPS;
    /// <summary>プレイヤー</summary>
    [SerializeField] private GameObject _player;
    /// <summary>プレイヤーを追跡するフラグ</summary>
    private bool trackFlag;

    private void Update()
    {
        if (trackFlag == true)
        {
            FPSTrackingPlayer();
        }
    }

    /// <summary>
    /// FPSがプレイヤーを追跡
    /// </summary>
    private void FPSTrackingPlayer()
    {
        var position = _player.transform.position;
        var rotation = _player.transform.rotation.eulerAngles;
        _FPS.transform.position = position;
        _FPS.transform.eulerAngles = rotation;
    }

    /// <summary>
    /// FPSを有効にする
    /// </summary>
    public void EnableFPS()
    {
        _FPS.SetActive(true);
        trackFlag = true;
    }

    /// <summary>
    /// FPSを無効にする
    /// </summary>
    public void DisableFPS()
    {
        _FPS.SetActive(false);
        trackFlag = false;
    }
}
