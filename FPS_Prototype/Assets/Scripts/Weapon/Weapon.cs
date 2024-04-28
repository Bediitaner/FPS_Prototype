using ProjectH.Scripts.ScriptableObjectsGen;
using UnityEngine;

namespace ProjectH.Scripts.Weapon
{
    public class Weapon : MonoBehaviour
    {
        #region Contents

        [SerializeField] private Gun[] _loadoutArray;

        [SerializeField] private Transform _weaponParent;

        #endregion

        #region Fields

        private GameObject currentWeapon;

        #endregion

        
        #region Unity: Start | Update

        private void Start()
        {
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) WeaponEquip(0);
        }

        #endregion

        
        #region Weapon: Equip

        private void WeaponEquip(int p_ind)
        {
            //TODO: @Halit - Needs Refactor.
            if (currentWeapon != null)
                Destroy(currentWeapon);

            var t_newWeapon = Instantiate(_loadoutArray[p_ind].Prefab, _weaponParent.position, _weaponParent.rotation,
                _weaponParent);

            t_newWeapon.transform.localPosition = Vector3.zero;
            t_newWeapon.transform.localEulerAngles = Vector3.zero;

            currentWeapon = t_newWeapon;
        }

        #endregion
    }
}