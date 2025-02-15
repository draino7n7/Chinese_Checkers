using UnityEngine;
using Utilities;

namespace View
{
    public class BoardSpace : MonoBehaviour
    {
        [SerializeField] private Material spaceHighlightMaterial;
        [SerializeField] private Material playerPieceMaterial;

        public int Q {  get; private set; }
        public int R { get; private set; }
        public int S { get; private set; }

        private MeshRenderer meshRenderer;
        private GlobalConstants.SpaceStates spaceState;
        private bool spaceHighlighted;
        private GameObject outline;

        public GlobalConstants.SpaceStates SpaceState
        {
            set
            {
                spaceState = value;
                SetMaterial();
            }
            get { return spaceState; } 
        }

        public bool SpaceHighlighted
        {
            set
            {
                spaceHighlighted = value;
                outline.SetActive(spaceHighlighted);
            }
            get { return spaceHighlighted; }
        }

        // Start is called before the first frame update
        void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            outline = transform.Find("Outline")?.gameObject;

            if (outline != null) 
                outline.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Initialize(int q, int r, int s)
        {
            Q = q;
            R = r;
            S = s;
            Vector3 newPosition = new Vector3(CalculateX(), 0f, CalculateZ());
            transform.position = newPosition;
        }

        private float CalculateX()
        {
            return (R - S) * 0.5f;
        }

        private float CalculateZ() 
        { 
            return (1.5f * Q) / Mathf.Sqrt(3);
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
                    meshRenderer.materials[0].color = ColorPicker.Instance.HighlightColor;
                    break;
                case GlobalConstants.SpaceStates.Player1Piece:
                    meshRenderer.materials[0].color = ColorPicker.Instance.Player1Color;
                    break;
                case GlobalConstants.SpaceStates.Player2Piece:
                    meshRenderer.materials[0].color = ColorPicker.Instance.Player2Color;
                    break;
                case GlobalConstants.SpaceStates.Player3Piece:
                    meshRenderer.materials[0].color = ColorPicker.Instance.Player3Color;
                    break;
                case GlobalConstants.SpaceStates.Player4Piece:
                    meshRenderer.materials[0].color = ColorPicker.Instance.Player4Color;
                    break;
                case GlobalConstants.SpaceStates.Player5Piece:
                    meshRenderer.materials[0].color = ColorPicker.Instance.Player5Color;
                    break;
                case GlobalConstants.SpaceStates.Player6Piece:
                    meshRenderer.materials[0].color = ColorPicker.Instance.Player6Color;
                    break;

            }
        }
    }
}