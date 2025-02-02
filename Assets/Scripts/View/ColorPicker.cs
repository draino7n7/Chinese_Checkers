using UnityEngine;
using Utilities;

namespace View
{
    public class ColorPicker : SingletonMonoBehaviour<ColorPicker>
    {
        [Header("Highlight Color")]
        [SerializeField] private Color highlightColor;

        [Header("Player Colors")]
        [SerializeField] private Color player1Color;
        [SerializeField] private Color player2Color;
        [SerializeField] private Color player3Color;
        [SerializeField] private Color player4Color;
        [SerializeField] private Color player5Color;
        [SerializeField] private Color player6Color;

        protected override void Awake()
        {
            base.Awake();
        }

        public Color HighlightColor { get { return highlightColor; } }
        public Color Player1Color { get { return player1Color; } }
        public Color Player2Color { get { return player2Color; } }
        public Color Player3Color { get { return player3Color; } }
        public Color Player4Color { get { return player4Color; } }
        public Color Player5Color { get { return player5Color; } }
        public Color Player6Color { get { return player6Color; } }
    }
}
