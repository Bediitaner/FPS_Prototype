using System;
using UnityEngine;
using UnityEngine.AI;

namespace ProjectH.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        
        //TODO: @Halit : Refactor this class 
        
        private StateMachine _stateMachine;
        private NavMeshAgent _agent;
        public NavMeshAgent Agent => _agent;

        [SerializeField] private string _currentState;

        [SerializeField] private Path _path;
        [SerializeField] private float _eyeHeight;
        public Path Path => _path;

        private GameObject player;
        public float sightDistance = 20f;
        public float fieldOfView = 85f;


        private void Start()
        {
            _stateMachine = GetComponent<StateMachine>();
            _agent = GetComponent<NavMeshAgent>();
            _stateMachine.Initialize();
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            CanSeePlayer();
            _currentState = _stateMachine.activeState.ToString();
        }

        public bool CanSeePlayer()
        {
            if (player != null)
            {
                //is the player close enough to be seen? 
                if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
                {
                    Vector3 targetDirection = player.transform.position - transform.position - Vector3.up * _eyeHeight;
                    float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                    if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                    {
                        Ray ray = new Ray(transform.position + Vector3.up * _eyeHeight, targetDirection);
                        RaycastHit hitInfo = new RaycastHit();

                        if (Physics.Raycast(ray, out hitInfo, sightDistance))
                        {
                            if (hitInfo.transform.gameObject == player)
                            {
                                Debug.DrawRay(ray.origin, ray.direction * sightDistance, Color.red);
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}