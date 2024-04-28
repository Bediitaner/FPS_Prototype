using UnityEngine;

namespace ProjectH.Scripts.Weapon
{
    public class WeaponSway : MonoBehaviour
    {
        #region Contents

        [SerializeField] private float _intensity;
        [SerializeField] private float _smooth;
        [SerializeField] private bool _isSwaying;

        #endregion

        #region Fields

        private Quaternion origin_rotation;

        #endregion

        
        #region Unity: Start | Update

        private void Start()
        {
            origin_rotation = transform.localRotation;
        }

        private void Update()
        {
            UpdateSway();
        }

        #endregion


        #region Sway: Update

        private void UpdateSway()
        {
            var t_x_mouse = Input.GetAxis("Mouse X");
            var t_y_mouse = Input.GetAxis("Mouse Y");

            if (!_isSwaying)
            {
                t_x_mouse = 0;
                t_y_mouse = 0;
            }

            var t_x_adj = Quaternion.AngleAxis(-_intensity * t_x_mouse, Vector3.up);
            var t_y_adj = Quaternion.AngleAxis(_intensity * t_y_mouse, Vector3.right);
            var target_rotation = origin_rotation * t_x_adj * t_y_adj;

            transform.localRotation = Quaternion.Lerp(transform.localRotation, target_rotation, Time.deltaTime * _smooth);
        }

        #endregion
    }
}