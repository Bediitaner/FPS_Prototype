using ProjectH.Scripts.Enemy.States;
using UnityEngine;

namespace ProjectH.Scripts.Enemy.States
{
    public class AttackState : BaseState
    {
        #region Fields

        private float _moveTimer;
        private float _losePlayerTimer;
        private float _shootTimer;

        #endregion

        #region Override: Enter | Perform | Exit

        public override void Enter()
        {
        }

        public override void Perform()
        {
            ChangeState();
        }

        public override void Exit()
        {
        }

        #endregion

        #region State: Change

        private void ChangeState()
        {
            if (Enemy.EnemyCanSeePlayer()) //player can be seen
            {
                //lock the lose player timer and increase the move and shoot timers
                _losePlayerTimer = 0;
                _moveTimer += Time.deltaTime;
                _shootTimer += Time.deltaTime;
                Enemy.transform.LookAt(Enemy.Player.transform);
                //if shot timer > fireRate
                if (_shootTimer > Enemy.FireRate)
                {
                    //shoot at the player
                    Enemy.Shoot();
                    _shootTimer = 0;
                }
                //move the enemy to a random position after a random time
                if (_moveTimer > Random.Range(3, 7))
                {
                    Enemy.Agent.SetDestination(Enemy.transform.position + (Random.insideUnitSphere * 5));
                    _moveTimer = 0;
                }

                Enemy.LastKnownPosition = Enemy.Player.transform.position;
            }
            else //lost sight of player
            {
                _losePlayerTimer += Time.deltaTime;
                if (_losePlayerTimer > 5)
                {
                    //change to search state
                    StateMachine.ChangeState(new SearchState());
                }
            }
        }

        #endregion
    }
}