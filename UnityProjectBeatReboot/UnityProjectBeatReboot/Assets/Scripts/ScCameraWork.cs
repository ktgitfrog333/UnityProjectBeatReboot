using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Commons;
using UnityStandardAssets.CrossPlatformInput;

public class ScCameraWork : MonoBehaviour
{
    /// <summary>マウス操作の補正値</summary>
    private float moveSpeed = 7f;

    /// <summary>エディタでVirtual Cameraをアタッチ</summary>
    [SerializeField] private CinemachineVirtualCamera _camera;
    /// <summary>CinemachineOrbitalTransposerをスクリプト制御</summary>
    private CinemachineOrbitalTransposer _transposer;
    /// <summary>座標</summary>
    private Transform _transform;

    /// <summary>移動座標補正</summary>
    private Vector3 _moveVelocity;
    /// <summary>全体座標補正</summary>
    private Vector3 _world_moveVelocity;
    /// <summary>カメラ座標補正</summary>
    private Vector3 _cameraRotation;

    void Start()
    {
        _transposer = _camera.GetCinemachineComponent<CinemachineOrbitalTransposer>();
        _transform = transform;

        _moveVelocity = Vector3.zero;
        _world_moveVelocity = Vector3.zero;
        _cameraRotation = Vector3.zero;
    }

    void Update()
    {
        _world_moveVelocity = Vector3.zero;
        _moveVelocity = Vector3.zero;

        _cameraRotation.x = CrossPlatformInputManager.GetAxisRaw(CsNormalLevelDesignOfCommon.RIGHT_HORIZONTAL);
        _cameraRotation.z = CrossPlatformInputManager.GetAxisRaw(CsNormalLevelDesignOfCommon.RIGHT_VERTICAL);

        if (_cameraRotation.magnitude >= 0.1)
        {
            _transposer.m_Heading.m_Bias += _cameraRotation.x * 0.35f; //Biasを操作

            if (0.3f < _transposer.m_FollowOffset.y && _transposer.m_FollowOffset.y < 3.0f)
            {
                _transposer.m_FollowOffset.y -= _cameraRotation.z / 40f; //Follow Offsetを操作
            }

            if (_transposer.m_FollowOffset.y <= 0.3f)
            {
                _transposer.m_FollowOffset.y = 0.301f;
            }

            if (3.0f < _transposer.m_FollowOffset.y)
            {
                _transposer.m_FollowOffset.y = 2.999f;
            }
        }

        _moveVelocity.x = CrossPlatformInputManager.GetAxisRaw(CsNormalLevelDesignOfCommon.LEFT_HORIZONTAL) * moveSpeed;
        _moveVelocity.z = CrossPlatformInputManager.GetAxisRaw(CsNormalLevelDesignOfCommon.LEFT_VERTICAL) * moveSpeed;

        if (_moveVelocity.magnitude >= 0.01)
        {
            //座標系の補正
            _world_moveVelocity = Quaternion.AngleAxis(_transposer.m_Heading.m_Bias, Vector3.up) * _moveVelocity;

            Vector3 targetPositon = _transform.position + _world_moveVelocity;
            //向かせたい方向
            Quaternion targetRotation = Quaternion.LookRotation(targetPositon - _transform.position);

            _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, 0.2f);
        }
    }
}
