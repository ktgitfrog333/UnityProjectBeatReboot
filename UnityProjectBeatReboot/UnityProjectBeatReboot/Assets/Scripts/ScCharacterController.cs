using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commons;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(CharacterController))]
/// <summary>
/// キャラクター操作制御スクリプトクラス
/// </summary>
public class ScCharacterController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float moveSpeed = 3; // 移動速度
    [SerializeField] private float jumpPower = 3; // ジャンプ力
    private CharacterController _characterController; // CharacterControllerのキャッシュ
    private Transform _transform; // Transformのキャッシュ
    private Vector3 _moveVelocity; // キャラの移動速度情報

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

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>(); // 毎フレームアクセスするので、負荷を下げるためにキャッシュしておく
        _transform = transform; // Transformもキャッシュすると少しだけ負荷が下がる

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(IsGrounded ? "地上にいます" : "空中です");

        //if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        //{
        //    // Fire1ボタン（デフォルトだとマウス左クリック）で攻撃
        //    _attack.AttackIfPossible();
        //}

        //if (_status.IsMovable) // 移動可能な状態であれば、ユーザー入力を移動に反映する
        //{
        //    // 入力軸による移動処理（慣性を無視しているので、キビキビ動く）
        _moveVelocity.x = CrossPlatformInputManager.GetAxis(CsNormalLevelDesignOfCommon.LEFT_HORIZONTAL) * moveSpeed;
        _moveVelocity.z = CrossPlatformInputManager.GetAxis(CsNormalLevelDesignOfCommon.LEFT_VERTICAL) * moveSpeed;

        // 移動方向に向く
        _transform.LookAt(_transform.position + new Vector3(_moveVelocity.x, 0, _moveVelocity.z));
        //}
        //else
        //{
        //    _moveVelocity.x = 0;
        //    _moveVelocity.z = 0;
        //}

        if (IsGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                // ジャンプ処理
                Debug.Log("ジャンプ！");
                _moveVelocity.y = jumpPower; // ジャンプの際は上方向に移動させる
            }
        }
        else
        {
            // 重力による加速
            _moveVelocity.y += Physics.gravity.y * Time.deltaTime;
        }

        // オブジェクトを動かす
        _characterController.Move(_moveVelocity * Time.deltaTime);

        // 移動スピードをanimatorに反映
        animator.SetFloat("MoveSpeed", new Vector3(_moveVelocity.x, 0, _moveVelocity.z).magnitude);
    }
}
