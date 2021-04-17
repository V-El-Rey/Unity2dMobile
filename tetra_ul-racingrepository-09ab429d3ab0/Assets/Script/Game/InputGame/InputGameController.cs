﻿using Profile;
using Tools;
using UnityEngine;

namespace Game.InputLogic
{
    internal sealed class InputGameController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/endlessMove"};
        //private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/tapeInputView"};
        private readonly BaseInputView _view;
        
        public InputGameController(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, Car car)
        {
            _view = LoadView();
            _view.Init(leftMove, rightMove, car.Speed, 
                new SubscriptionProperty<Vector2>(), new SubscriptionProperty<Vector2>());
        }

        private BaseInputView LoadView()
        {
            GameObject objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objView);
            return objView.GetComponent<BaseInputView>();
        }
    } 
}

