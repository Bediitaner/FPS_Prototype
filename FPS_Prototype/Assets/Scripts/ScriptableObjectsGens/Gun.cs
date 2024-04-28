using UnityEngine;

namespace ProjectH.Scripts.ScriptableObjectsGen
{
    [CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
    public class Gun : ScriptableObject
    {
        [SerializeField] 
        private string _gunName;
        public string GunName => _gunName;

        [SerializeField] 
        private float _fireRate;
        public float FireRate => _fireRate;
        
        [SerializeField] 
        private float _aimSpeed;
        public float AimSpeed => _aimSpeed;
        
        [SerializeField]
        private GameObject _prefab;
        public GameObject Prefab => _prefab;
    }
}