using Game.InputLogic;
using Tools;
using UnityEngine;

internal sealed class SwipeController : BaseController
{
    private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/swipeInputView"};

    private float _speed;

    public SwipeController(SubscriptionProperty<Vector2> startPosition, SubscriptionProperty<Vector2> endPosition)
    {
        var view = LoadView();
        view.Init(new SubscriptionProperty<float>(), new SubscriptionProperty<float>(), _speed, endPosition, startPosition);
    }
    
    private BaseInputView LoadView()
    {
        GameObject objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
        AddGameObjects(objView);
        return objView.GetComponent<BaseInputView>();
    }
}
