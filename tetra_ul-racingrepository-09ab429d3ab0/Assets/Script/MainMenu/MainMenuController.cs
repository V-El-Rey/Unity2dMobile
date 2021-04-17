using Profile;
using Tools;
using UnityEngine;

namespace Ui
{
    internal sealed class MainMenuController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/mainMenu"};
        private readonly ProfilePlayer _profilePlayer;
        private readonly MainMenuView _view;
        
        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(StartGame);
            
            SubscriptionProperty<Vector2> startPosition = new SubscriptionProperty<Vector2>();
            SubscriptionProperty<Vector2> endPosition = new SubscriptionProperty<Vector2>();
            
            SwipeController swipeController = new SwipeController(startPosition, endPosition);
            AddController(swipeController);
            TrailController trailController = new TrailController(startPosition, endPosition);
            AddController(trailController);
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
            AddGameObjects(objectView);
            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
        }
    }
}

