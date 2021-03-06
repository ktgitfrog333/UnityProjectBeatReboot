using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーが触れた際に何かしらの処理を実行する
/// </summary>
public class ScPlayedTrigger : MonoBehaviour
{
    /// <summary>FPSCのコントローラー</summary>
    [SerializeField] private ScFPSCController _controller;
    /// <summary>プレイヤー</summary>
    [SerializeField] private GameObject _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals(_player.name))
        {
            _controller.EnableFPS();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals(_player.name))
        {
            _controller.DisableFPS();
        }
    }
}
