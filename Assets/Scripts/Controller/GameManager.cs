using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using View;

namespace Controller
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject boardSpacePrefab;
        [SerializeField] private GameObject boardSpacesParent;

        protected override void Awake()
        {
            base.Awake();
        }

        // Start is called before the first frame update
        void Start()
        {
            GenerateBoardSpaces();
            GlobalVariables.Instance.WindowState = GlobalConstants.WindowStates.MainMenu;
            GlobalVariables.Instance.GameState = GlobalConstants.GameStates.PreGame;
        }

        void GenerateBoardSpaces()
        {
            int limit = 8;
            for (int q = -limit; q <= limit; q++)
            {
                for (int r = Mathf.Max(-limit, -q - limit); r <= Mathf.Min(limit, -q + limit); r++)
                {
                    int s = -q - r;
                    if (IsWithinPlayableArea(q, r, s))
                    {
                        CreateBoardSpace(q, r, s);
                    }
                }
            }
        }

        bool IsWithinPlayableArea(int q, int r, int s)
        {
            int absQ = Mathf.Abs(q);
            int absR = Mathf.Abs(r);
            int absS = Mathf.Abs(s);

            // Check if the coordinates are within the playable area
            return (absQ <= 4 || (absR <= 4 && absS <= 4)) &&
                   (absR <= 4 || (absQ <= 4 && absS <= 4)) &&
                   (absS <= 4 || (absQ <= 4 && absR <= 4));
        }

        void CreateBoardSpace(int q, int r, int s)
        {
            GameObject tmp = Instantiate(boardSpacePrefab, boardSpacesParent.transform);
            tmp.GetComponent<BoardSpace>().Initialize(q, r, s);
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
