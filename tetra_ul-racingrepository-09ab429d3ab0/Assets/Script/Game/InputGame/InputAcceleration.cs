using JoostenProductions;
using Tools;
using UnityEngine;

namespace Game.InputLogic
{
    internal sealed class InputAcceleration : BaseInputView
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
            Vector3 direction = Vector3.zero; 
            direction.x = -Input.acceleration.y;
            direction.z = Input.acceleration.x;
            
            if (direction.sqrMagnitude > 1)
                direction.Normalize();
            
            OnRightMove(direction.sqrMagnitude / 20 * _speed);
        }
    }
}

