using Model;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controller
{
    public class ClickOnBoardSpace : Utilities.SingletonMonoBehaviour<ClickOnBoardSpace>
    {
        private Camera mainCamera;
        private PlayerInputActions inputActions;

        protected override void Awake()
        { 
            base.Awake();
            Debug.Log("ClickOnBoardSpace Singleton Initialized");
            mainCamera = Camera.main;
            inputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            inputActions.Gameplay.Click.performed += OnPointerClick;
            inputActions.Gameplay.Enable();
        }

        private void OnDisable()
        {
            inputActions.Gameplay.Click.performed -= OnPointerClick;
            inputActions.Gameplay.Disable();
        }

        private void OnPointerClick(InputAction.CallbackContext context)
        {
            if (GlobalVariables.Instance.WindowState == Utilities.GlobalConstants.WindowStates.Game && GlobalVariables.Instance.GameState == Utilities.GlobalConstants.GameStates.PlayerTurn)
            {
                Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    View.BoardSpace spaceView = hit.collider.gameObject.GetComponent<View.BoardSpace>();
                    if (spaceView != null)
                    {
                        Debug.Log("SpaceView object clicked: " + hit.collider.gameObject.name);
                        HandleClick(spaceView);
                    }
                }
            }
        }

        private void HandleClick(View.BoardSpace spaceView)
        {
            Debug.Log($"Handling click on: {spaceView.gameObject.name} at row {spaceView.Row} and column {spaceView.Col}");
        }
    }
}
