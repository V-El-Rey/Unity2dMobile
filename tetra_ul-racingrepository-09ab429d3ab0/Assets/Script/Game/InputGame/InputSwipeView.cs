using System;
using Tools;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.InputLogic
{
    internal sealed class InputSwipeView : BaseInputView, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            SetStartPosition(eventData.position);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            
        }

        public void OnDrag(PointerEventData eventData)
        {
            SetEndPosition(Camera.main.ScreenToWorldPoint(eventData.position));
        }
        
    }
}

