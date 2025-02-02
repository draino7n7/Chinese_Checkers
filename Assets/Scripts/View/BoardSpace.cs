using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public class BoardSpace : MonoBehaviour
    {
        [SerializeField]    private int row;
        [SerializeField]    private int col;

        [SerializeField] private Material spaceHighlightMaterial;
        [SerializeField] private Material playerPieceMaterial;

        public int Row { get { return row; } }
        public int Col { get { return col; } }

        private MeshRenderer meshRenderer;

        public GlobalConstants.SpaceStates SpaceState
        {
            set
            {
                SpaceState = value;
                SetMaterial();
            }
            get { return SpaceState; } 
        }

        // Start is called before the first frame update
        void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void SetMaterial()
        {
            meshRenderer.enabled = true;
            meshRenderer.materials[0] = playerPieceMaterial;
            switch (SpaceState)
            {
                case GlobalConstants.SpaceStates.Empty:
                    meshRenderer.enabled = false;
                    break;
                case GlobalConstants.SpaceStates.Highlighted:
                    meshRenderer.materials[0] = spaceHighlightMaterial;
                    meshRenderer.materials[0].color = Utilities.SingletonMonoBehaviour<ColorPicker>.Instance.HighlightColor;
                    break;
                case GlobalConstants.SpaceStates.Player1Piece:
                    meshRenderer.materials[0].color = Utilities.SingletonMonoBehaviour<ColorPicker>.Instance.Player1Color;
                    break;
                case GlobalConstants.SpaceStates.Player2Piece:
                    meshRenderer.materials[0].color = Utilities.SingletonMonoBehaviour<ColorPicker>.Instance.Player2Color;
                    break;
                case GlobalConstants.SpaceStates.Player3Piece:
                    meshRenderer.materials[0].color = Utilities.SingletonMonoBehaviour<ColorPicker>.Instance.Player3Color;
                    break;
                case GlobalConstants.SpaceStates.Player4Piece:
                    meshRenderer.materials[0].color = Utilities.SingletonMonoBehaviour<ColorPicker>.Instance.Player4Color;
                    break;
                case GlobalConstants.SpaceStates.Player5Piece:
                    meshRenderer.materials[0].color = Utilities.SingletonMonoBehaviour<ColorPicker>.Instance.Player5Color;
                    break;
                case GlobalConstants.SpaceStates.Player6Piece:
                    meshRenderer.materials[0].color = Utilities.SingletonMonoBehaviour<ColorPicker>.Instance.Player6Color;
                    break;

            }
        }
    }
}