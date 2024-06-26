﻿  using System;
  using Gameplay.Player.Logic;
  using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerLogic: MonoBehaviour
    {
        private PlayerInfo _playerInfo;
        private LevelController _levelController;
        private InfinityForwardMovement _infinityForwardMovement;
        private JumpLogic _jumpLogic;
        
        private void Awake()
        {
            _playerInfo = GetComponent<PlayerInfo>();
        }

        public void Initialize(LevelController levelController)
        {
            _levelController = levelController;
            _playerInfo.Rigidbody.isKinematic = false;
            InitializeLogic();
        }

        private void InitializeLogic()
        {
            _infinityForwardMovement = new InfinityForwardMovement(_playerInfo.MoveSpeed, transform, _playerInfo.Animator);
            _jumpLogic = new JumpLogic(_playerInfo.JumpLogicInfo, _playerInfo.Rigidbody, _playerInfo.Animator);

            EnterLogic();
        }

        private void EnterLogic()
        {
            _infinityForwardMovement.Enter();
            _jumpLogic.Enter();
        }
        
        public void IsGrounded(bool isGrounded)
        {
            _jumpLogic.SetGrounded(isGrounded);
        }
    }
}