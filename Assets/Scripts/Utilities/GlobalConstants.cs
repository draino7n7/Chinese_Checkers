using System;
using UnityEditor.PackageManager;

namespace Model
{
    public static class GlobalConstants
    {
        public enum Players
        {
            Player1,
            Player2,
            Player3,
            Player4,
            Player5,
            Player6
        }

        public enum SpaceStates
        {
            Empty,
            Highlighted,
            Player1Piece,
            Player2Piece,
            Player3Piece,
            Player4Piece,
            Player5Piece,
            Player6Piece
        }

    }
}
