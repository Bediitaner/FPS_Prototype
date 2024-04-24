using UnityEngine;

namespace ProjectH.Scripts.Enemy.States
{
    public class PatrolState : BaseState
    {
        public int waypointIndex;
        public float waitTimer;

        public override void Enter()
        {
        }

        public override void Perform()
        {
            PatrolCycle();
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }

        public void PatrolCycle()
        {
            if (Enemy.Agent.remainingDistance < 0.5f)
            {
                waitTimer += Time.deltaTime;
                if (waitTimer > 3)
                {
                    if (waypointIndex < Enemy.Path.ListWaypoint.Count - 1)
                        waypointIndex++;
                    else
                        waypointIndex = 0;
                    Enemy.Agent.SetDestination(Enemy.Path.ListWaypoint[waypointIndex].position);
                    waitTimer = 0;
                }
            }
        }
    }
}