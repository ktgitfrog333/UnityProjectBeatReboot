using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commons;
using Beans;

/// <summary>
/// 楽器を常にプレイヤー装備状態にするスクリプトクラス
/// </summary>
public class ScHoldInstrument : MonoBehaviour
{
    /// <summary>追尾対象のオブジェクト</summary>
    [SerializeField] private GameObject _player;
    /// <summary>プレイヤーオブジェクトのステータス</summary>
    [SerializeField] private Animator _playerStatus;

    /// <summary>オブジェクトの位置情報</summary>
    private Vector3 _position;
    /// <summary>オブジェクトの角度情報</summary>
    private Vector3 _rotation;

    void Start()
    {
        _position = transform.position;
        _rotation = transform.rotation.eulerAngles;
    }

    private void FixedUpdate()
    {
        PositionAdjustToPlayersAngle();
    }

    /// <summary>
    /// プレイヤーの回転に合わせて位置を調整
    /// </summary>
    private void PositionAdjustToPlayersAngle()
    {
        var playerRotation = _player.transform.rotation.eulerAngles;
        // 角度
        float angle = 2.0f * Mathf.PI * ((playerRotation.y / 360.0f) % 1);
        // 回転の行列
        Matrix4x4 mattixTransform = Matrix4x4.identity;
        // 単位行列
        mattixTransform.m00 = Mathf.Sin(angle); mattixTransform.m02 = Mathf.Cos(angle);
        mattixTransform.m20 = Mathf.Cos(angle); mattixTransform.m22 = -Mathf.Sin(angle);

        Vector3 v = mattixTransform * _position;
        transform.position = _player.transform.position + v;
        float tilt = 0f;
        if (_playerStatus.GetCurrentAnimatorStateInfo(0).IsName("Running(Loop)"))
        {
            tilt = -15f;
        }
        transform.eulerAngles = new Vector3(_rotation.x + tilt, playerRotation.y + 180f, _rotation.z);
    }
}
