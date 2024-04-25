using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ProjectH.Scripts.Enemy.States
{
    public class SearchState : BaseState
    {
        private float _searchTimer;
        private float _moveTimer;

        #region Override: Enter | Perform | Exit

        public override void Enter()
        {
            Enemy.Agent.SetDestination(Enemy.LastKnownPosition);
        }

        public override void Perform()
        {
            if (Enemy.EnemyCanSeePlayer())
                StateMachine.ChangeState(new AttackState());

            if (Enemy.Agent.remainingDistance < Enemy.Agent.stoppingDistance)
            {
                _searchTimer += Time.deltaTime;
                _moveTimer += Time.deltaTime;
                if (_moveTimer > Random.Range(3, 5))
                {
                    Enemy.Agent.SetDestination(Enemy.transform.position + (Random.insideUnitSphere * 10));
                    _moveTimer = 0;
                }
                
                if (_searchTimer > Random.Range(5f,10f))
                {
                    StateMachine.ChangeState(new PatrolState());
                }
            }
        }

        public override void Exit()
        {
        }

        #endregion
    }
}