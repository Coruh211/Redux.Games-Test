﻿using System;
using Gameplay.BlockGeneratorLogic;
using Gameplay.TrapLogic;
using UnityEditor;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerInteractionController : MonoBehaviour
    {
        [SerializeField] private PlayerLogic playerLogic;
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                playerLogic.ChangeIsGroundedState(true);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("ChangeDirection"))
            {
                DirectionSwitchTrap currentBlock = other.GetComponentInParent<DirectionSwitchTrap>();
                playerLogic.ChangeDirection(currentBlock.CurrentContainer.transform, currentBlock.transform.position);
            }
            else if (other.CompareTag("DamageTrigger"))
            {
                int damage = other.GetComponent<DamageTrigger>().Damage * -1;
                playerLogic.ChangeHp(damage, true);
            }
            else if (other.CompareTag("KillBox"))
            {
                int damage = other.GetComponent<DamageTrigger>().Damage * -1;
                playerLogic.Fell(damage, true);
            }
        }
    }
}