using Tools;
using UnityEngine;

namespace Game.InputLogic
{
    internal abstract class BaseInputView : MonoBehaviour
    {
        protected float _speed;
        private SubscriptionProperty<float> _leftMove;
        private SubscriptionProperty<float> _rightMove;
        private SubscriptionProperty<Vector2> _startPosition;
        private SubscriptionProperty<Vector2> _endPosition;
        
        public virtual void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove,
            float speed, SubscriptionProperty<Vector2> endPosition, SubscriptionProperty<Vector2> startPosition)
        {
            _leftMove = leftMove;
            _rightMove = rightMove;
            _startPosition = startPosition;
            _endPosition = endPosition;
            _speed = speed;
        }

        protected virtual void OnLeftMove(float value)
        {
            _leftMove.Value = value;
        }

        protected virtual void OnRightMove(float value)
        {
            _rightMove.Value = value;
        }

        protected virtual void SetStartPosition(Vector2 value)
        {
            _startPosition.Value = value;
        }
        
        protected virtual void SetEndPosition(Vector2 value)
        {
            _endPosition.Value = value;
        }
    }  
}

