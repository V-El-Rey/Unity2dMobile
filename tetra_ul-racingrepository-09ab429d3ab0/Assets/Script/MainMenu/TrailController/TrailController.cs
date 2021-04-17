using Game.InputLogic;
using Tools;
using UnityEngine;

internal sealed class TrailController : BaseController
{
    private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/trailCursor"};
    private readonly BaseInputView _view;
    private readonly SubscriptionProperty<Vector2> _startPosition;
    private readonly SubscriptionProperty<Vector2> _endPosition;

    public TrailController(SubscriptionProperty<Vector2> startPosition, SubscriptionProperty<Vector2> endPosition)
    {
        _view = LoadView();
        _startPosition = startPosition;
        _endPosition = endPosition;
        _endPosition.SubscribeOnChange(SetTrail);
        _startPosition.SubscribeOnChange(SetStartPosition);
    }
    
    private BaseInputView LoadView()
    {
        GameObject objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
        AddGameObjects(objView);
        return objView.GetComponent<BaseInputView>();
    }

    private void SetTrail(Vector2 viewPosition)
    {
        viewPosition = _endPosition.Value;
        _view.transform.position = viewPosition;
    }

    private void SetStartPosition(Vector2 viewPosition)
    {
        viewPosition = _startPosition.Value;
        _view.transform.position = viewPosition;
    }
}
