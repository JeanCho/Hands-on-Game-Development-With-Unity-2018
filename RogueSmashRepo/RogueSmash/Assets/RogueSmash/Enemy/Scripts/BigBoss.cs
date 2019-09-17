
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MyCompany.GameFramework.EnemyAI.Interfaces;
using MyCompany.GameFramework.EnemyAI;

namespace MyCompany.RogueSmash.Enemies
{
    public class BigBoss : MonoBehaviour
    {
        protected IMovementBehavior movementBehavior;
        protected Dictionary<IActionCondition, IEnemyAbility> abilities =
            new Dictionary<IActionCondition, IEnemyAbility>();

        protected NavMeshAgent agent;
        protected GameObject player;
        [SerializeField] protected GameObject projectilePrefab;

        private void Awake()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();
            player = GameObject.FindWithTag("Player");

            /* Initializing Interfaces */
            movementBehavior = new RoamBehavior(agent, 8);
            SetupAbilities();
        }

        private void SetupAbilities()
        {
            BurstAttack ba = new BurstAttack(4, transform, projectilePrefab);
            ba.onBegin += () => { agent.isStopped = true; };
            ba.onComplete += () => { agent.isStopped = false; };
            RangeCondition rc = new RangeCondition(transform, player.transform, 12);
            abilities.Add(rc, ba);
        }

        private void Update()
        {
            if(!agent.hasPath)
            {
                movementBehavior.SetNextTargetPosition();
            }
            CheckConditions();
        }

        private void CheckConditions()
        {
            foreach(var kvp in abilities)
            {
                if(kvp.Key.CheckCondition())
                {
                    kvp.Value.UseAbility();
                }
            }
        }
    }

}
