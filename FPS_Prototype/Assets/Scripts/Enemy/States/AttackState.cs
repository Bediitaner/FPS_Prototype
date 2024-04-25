using ProjectH.Scripts.Enemy.States;
using UnityEngine;

namespace ProjectH.Scripts.Enemy.States
{
    public class AttackState : BaseState
    {
        private float moveTimer;
        private float losePlayerTimer;
        
        public override void Enter()
        {
            
        }

        public override void Perform()
        {
            if (Enemy.CanSeePlayer())
            {
                losePlayerTimer = 0;
                moveTimer += Time.deltaTime;
                if (moveTimer > Random.Range(3,7))
                {
                    Enemy.Agent.SetDestination(Enemy.transform.position + (Random.insideUnitSphere * 5));
                    moveTimer = 0;
                }
            }
            else
            {
                losePlayerTimer += Time.deltaTime;
                if (losePlayerTimer > 5)
                {
                    StateMachine.ChangeState(new PatrolState());
                }
            }
        }

        public override void Exit()
        {
            
        }
    }
}