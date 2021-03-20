using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

/// <summary>
/// プレイヤーが触れた際に何かしらの処理を実行する
/// </summary>
public class ScPlayedTrigger : MonoBehaviour
{
    /// <summary>FPSCのコントローラー</summary>
    [SerializeField] private ScFPSCController _controller;
    /// <summary>プレイヤー</summary>
    [SerializeField] private GameObject _player;
    /// <summary>プレイヤーカメラ</summary>
    [SerializeField] private GameObject _playerMainCamera;
    /// <summary>演奏開始アニメーション再生フラグ</summary>
    private bool _startPlayFlag = true;
    /// <summary>演奏開始カメラ</summary>
    [SerializeField] private GameObject _startPlayCamera;
    /// <summary>演奏開始カットシーン</summary>
    [SerializeField] private GameObject _startPlayCut;

    [SerializeField] private GameObject _targetObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals(_player.name))
        {
            if (_startPlayFlag == true)
            {
                StartCoroutine(_player.GetComponent<ScCharacterController>().CharacterWalkInPlace(this.gameObject));
            }
        }
    }

    /// <summary>
    /// プレイヤーの動きを止めて演出映像を動かす
    /// </summary>
    public void StopPlayerAndStartProductionMovie()
    {
        _player.GetComponent<ScCharacterController>()._playerControllerFlag = false;
        _playerMainCamera.SetActive(false);
        _startPlayCamera.SetActive(true);
        _startPlayCut.SetActive(true);
        _startPlayFlag = false;
        if (_startPlayCut.activeSelf == true)
        {
            var playable = _startPlayCut.GetComponent<PlayableDirector>();
            StartCoroutine(RuningStatusForCinematicCamera(playable));
        }
    }

    /// <summary>
    /// 映像開始アニメーションのタイムラインを監視<param/>
    /// 停止したら映像カメラを無効にしてプレイヤーのメインカメラを有効にする
    /// </summary>
    /// <param name="playable">演奏開始カットシーン</param>
    /// <returns></returns>
    private IEnumerator RuningStatusForCinematicCamera(PlayableDirector playable)
    {
        yield return null;
        if (playable.state.ToString().Equals("Playing"))
        {
            StartCoroutine(RuningStatusForCinematicCamera(playable));
        }
        else if (playable.state.ToString().Equals("Paused"))
        {
            _controller.EnableFPS();
            _startPlayCamera.SetActive(false);
            _startPlayCut.SetActive(false);
            _startPlayFlag = true;
            _player.GetComponent<ScCharacterController>()._playerControllerFlag = true;
            StopCoroutine(RuningStatusForCinematicCamera(playable));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals(_player.name))
        {
            _controller.DisableFPS();
            _playerMainCamera.SetActive(true);
        }
    }
}
