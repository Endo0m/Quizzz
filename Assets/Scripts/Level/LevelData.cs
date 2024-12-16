    using UnityEngine;

    [System.Serializable]
    public class LevelSettings
    {
        public int Rows;
        public int Columns;
        public int CellCount => Rows * Columns;
    }
