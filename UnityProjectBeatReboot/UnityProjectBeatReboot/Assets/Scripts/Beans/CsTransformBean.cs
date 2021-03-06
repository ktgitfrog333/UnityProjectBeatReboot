using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bean管理
/// </summary>
namespace Beans
{
    /// <summary>
    /// TransformBeanクラス
    /// </summary>
    public class CsTransformBean
    {
        /// <summary>位置_X</summary>
        public float position_x { get; set; } = 0f;
        /// <summary>位置_Y</summary>
        public float position_y { get; set; } = 0f;
        /// <summary>位置_Z</summary>
        public float position_z { get; set; } = 0f;

        /// <summary>回転角_X</summary>
        public float rotation_x { get; set; } = 0f;
        /// <summary>回転角_Y</summary>
        public float rotation_y { get; set; } = 0f;
        /// <summary>回転角_Z</summary>
        public float rotation_z { get; set; } = 0f;

        /// <summary>
        /// TransformBeanクラスのコンストラクタ
        /// </summary>
        /// <param name="position_x">位置_X</param>
        /// <param name="position_y">位置_Y</param>
        /// <param name="position_z">位置_Z</param>
        /// <param name="rotation_x">回転角_X</param>
        /// <param name="rotation_y">回転角_Y</param>
        /// <param name="rotation_z">回転角_Z</param>
        public CsTransformBean(float position_x, float position_y, float position_z, float rotation_x, float rotation_y, float rotation_z)
        {
            this.position_x = position_x;
            this.position_y = position_y;
            this.position_z = position_z;
            this.rotation_x = rotation_x;
            this.rotation_y = rotation_y;
            this.rotation_z = rotation_z;
        }

        /// <summary>
        /// TransformBeanクラスのコンストラクタ
        /// </summary>
        /// <param name="position_x">位置_X</param>
        /// <param name="position_y">位置_Y</param>
        /// <param name="position_z">位置_Z</param>
        public CsTransformBean(float position_x, float position_y, float position_z)
        {
            this.position_x = position_x;
            this.position_y = position_y;
            this.position_z = position_z;
        }

        /// <summary>
        /// TransformBeanクラスのコンストラクタ
        /// </summary>
        public CsTransformBean()
        {

        }
    }
}
