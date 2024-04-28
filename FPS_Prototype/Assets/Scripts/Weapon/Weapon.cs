using ProjectH.Scripts.ScriptableObjectsGen;
using UnityEngine;

namespace ProjectH.Scripts.Weapon
{
    public class Weapon : MonoBehaviour
    {
        #region Contents

        [Header("Loadout")] 
        [SerializeField]
        private Gun[] _loadoutArray;

        [SerializeField]
        private Transform _weaponParent;
        
        #endregion

        #region Fields

        private int _currentWeaponIndex;
        private GameObject _currentWeapon;

        #endregion

        
        #region Unity: Start | Update

        private void Start()
        {
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) WeaponEquip(0);

            if (_currentWeapon != null)
            {
                WeaponAim(Input.GetMouseButton(1));
            }
        }

        #endregion

        
        #region Weapon: Equip

        private void WeaponEquip(int index)
        {
            //TODO: @Halit - Needs Refactor.
            if (_currentWeapon != null)
                Destroy(_currentWeapon);

            _currentWeaponIndex = index;

            var newWeapon = Instantiate(_loadoutArray[index].Prefab, _weaponParent.position, _weaponParent.rotation,
                _weaponParent);

            newWeapon.transform.localPosition = Vector3.zero;
            newWeapon.transform.localEulerAngles = Vector3.zero;

            _currentWeapon = newWeapon;
        }

        #endregion

        #region Weapon: Aim

        private void WeaponAim(bool isAiming)
        {
            var weaponAnchor = _currentWeapon.transform.Find("Anchor"); 
            var stateAds = _currentWeapon.transform.Find("States/ADS"); 
            var stateHip = _currentWeapon.transform.Find("States/Hip"); 
            
            
            if (isAiming)
            {
                weaponAnchor.position = Vector3.Lerp(weaponAnchor.position, stateAds.position, Time.deltaTime * _loadoutArray[_currentWeaponIndex].AimSpeed);
            }
            else
            {
                weaponAnchor.position = Vector3.Lerp(weaponAnchor.position, stateHip.position, Time.deltaTime * _loadoutArray[_currentWeaponIndex].AimSpeed);
            }
        }

        #endregion
    }
}