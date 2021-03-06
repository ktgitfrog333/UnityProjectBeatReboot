using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commons;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
/// <summary>
/// キャラクター操作制御スクリプトクラス
/// </summary>
public class ScCharacterController : MonoBehaviour
{
    /// <summary>プレイヤー移動のアニメーション</summary>
    [SerializeField] private Animator _animator;
    /// <summary>プレイヤー移動のコントローラー</summary>
    [SerializeField] private CharacterController _characterController;

    /// <summary>移動速度</summary>
    [SerializeField] private float _moveSpeed = 3f;
    /// <summary>ジャンプ力</summary>
    [SerializeField] private float _jumpPower = 3f;

    /// <summary>現在の移動スピード</summary>
    public float _movedSpeedToAnimator { get; set; }

    /// <summary>位置・回転を制御</summary>
    private Transform _transform;
    /// <summary>位置・回転を保存</summary>
    private Vector3 _moveVelocity;
    /// <summary>カメラのトランスフォーム</summary>
    private Transform _mainCameraTransform;
    /// <summary>カメラの正面補正</summary>
    private Vector3 _mainCameraForward;

    void Start()
    {
        _transform = transform;
        _moveVelocity = new Vector3();

        if (Camera.main != null)
        {
            _mainCameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        CharacterMovement();
    }

    /// <summary>
    /// キャラクターの操作制御
    /// </summary>
    private void CharacterMovement()
    {
        var h = CrossPlatformInputManager.GetAxis(CsNormalLevelDesignOfCommon.LEFT_HORIZONTAL);
        var v = CrossPlatformInputManager.GetAxis(CsNormalLevelDesignOfCommon.LEFT_VERTICAL);

        _moveVelocity.x = h * _moveSpeed;
        _moveVelocity.z = v * _moveSpeed;

        if (IsGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                // ジャンプ処理
                _moveVelocity.y = _jumpPower; // ジャンプの際は上方向に移動させる
            }
        }
        else
        {
            // 重力による加速
            _moveVelocity.y += Physics.gravity.y * Time.deltaTime;
        }

        if (_mainCameraTransform != null)
        {
            // calculate camera relative direction to move:
            _mainCameraForward = Vector3.Scale(_mainCameraTransform.forward, new Vector3(1, 0, 1)).normalized;
            _moveVelocity = _moveVelocity.z * _mainCameraForward + _moveVelocity.x * _mainCameraTransform.right;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            _moveVelocity = _moveVelocity.z * Vector3.forward + _moveVelocity.x * Vector3.right;
        }

        // 移動方向に向く
        _transform.LookAt(_transform.position + new Vector3(_moveVelocity.x, 0, _moveVelocity.z));

        // オブジェクトを動かす
        _characterController.Move(_moveVelocity * Time.deltaTime);

        _movedSpeedToAnimator = new Vector3(_moveVelocity.x, 0, _moveVelocity.z).magnitude;

        // 移動スピードをanimatorに反映
        _animator.SetFloat("MoveSpeed", _movedSpeedToAnimator);
    }

    /// <summary>
    /// 接地判定処理
    /// </summary>
    private bool IsGrounded
    {
        get
        {
            var ray = new Ray(_transform.position + new Vector3(0, 0.1f), Vector3.down);
            var raycastHits = new RaycastHit[1];
            var hitCount = Physics.RaycastNonAlloc(ray, raycastHits, 0.2f);
            return hitCount >= 1;
        }
    }
}
