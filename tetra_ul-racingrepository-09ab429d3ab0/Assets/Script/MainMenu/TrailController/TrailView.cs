using Game.InputLogic;
using UnityEngine;
using UnityEngine.EventSystems;

internal sealed class TrailView : BaseInputView, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private TrailRenderer _trail;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        _trail.enabled = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _trail.enabled = false;
    }
}
