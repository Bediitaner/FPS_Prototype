using System;
using UnityEngine;
using UnityEngine.AI;

namespace ProjectH.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        private StateMachine _stateMachine;
        private NavMeshAgent _agent;
        public NavMeshAgent Agent => _agent;

        [SerializeField] 
        private string _currentState;
        
        [SerializeField]
        private Path _path;
        public Path Path => _path;


        private void Start()
        {
            _stateMachine = GetComponent<StateMachine>();
            _agent = GetComponent<NavMeshAgent>();
            _stateMachine.Initialize();
        }

        private void Update()
        {
            
        }
    }
}