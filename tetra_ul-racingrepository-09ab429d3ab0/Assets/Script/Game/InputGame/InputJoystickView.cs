﻿using JoostenProductions;
using Tools;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Game.InputLogic
{
    internal sealed class InputJoystickView : BaseInputView
    {
        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, 
            float speed, SubscriptionProperty<Vector2> endPosition, SubscriptionProperty<Vector2> startPosition)
        {
            base.Init(leftMove, rightMove, speed, endPosition, startPosition);
            UpdateManager.SubscribeToUpdate(Move);
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
        }

        private void Move()
        {
            float moveStep = 10 * Time.deltaTime * CrossPlatformInputManager.GetAxis("Horizontal");
            if(moveStep > 0)
                OnRightMove(moveStep);
            else if(moveStep < 0)
                OnLeftMove(moveStep); 
        }
    }
}

