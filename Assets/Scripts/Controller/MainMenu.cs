using Model;
using UnityEngine;
using UnityEngine.UIElements;
using Utilities;

namespace Controller
{
    public class MainMenu : SingletonMonoBehaviour<MainMenu>
    {
        private Button newGameButton;

        void Start()
        {
            // Get the root VisualElement from the UIDocument component
            var root = GetComponent<UIDocument>().rootVisualElement;

            // Query the button by its name
            newGameButton = root.Q<Button>("newGameButton");

            // Ensure the button was found
            if (newGameButton != null)
            {
                // Register a callback for the click event
                newGameButton.clicked += OnNewGameButtonClick;
            }
            else
            {
                Debug.LogError("newGameButton not found. Ensure the name is correct and the button exists in the UXML.");
            }
        }

        private void OnNewGameButtonClick()
        {
            Debug.Log("New Game button clicked!");
            GlobalVariables.Instance.GameState = GlobalConstants.GameStates.NewGame;
        }
    }
}
