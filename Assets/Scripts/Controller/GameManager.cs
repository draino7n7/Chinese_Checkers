using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Controller
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [SerializeField] private GameObject mainMenu;

        protected override void Awake()
        {
            base.Awake();
        }

        // Start is called before the first frame update
        void Start()
        {
            GlobalVariables.Instance.WindowState = GlobalConstants.WindowStates.MainMenu;
            GlobalVariables.Instance.GameState = GlobalConstants.GameStates.PreGame;
        }

        // Update is called once per frame
        void Update()
        {
            switch (GlobalVariables.Instance.WindowState) 
            {
                case GlobalConstants.WindowStates.MainMenu:
                    mainMenu.SetActive(true); 
                    break;
                case GlobalConstants.WindowStates.Game:
                    mainMenu.SetActive(false);
                    break;
                default:
                    break;
            }

            switch (GlobalVariables.Instance.GameState) 
            {
                case GlobalConstants.GameStates.PreGame:
                    break;
                case GlobalConstants.GameStates.NewGame:
                    SetupNewGame();
                    break;
                default:
                    break;
            }
        }

        private void SetupNewGame()
        {
            GlobalVariables.Instance.WindowState = GlobalConstants.WindowStates.Game;
            GlobalVariables.Instance.GameState = GlobalConstants.GameStates.PlayerTurn;
        }
    }
}
