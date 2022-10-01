using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class DataBase : MonoBehaviour
    {
        public Vector3 mouseDragOffset;
        public List<FigursCell> figursCells = new List<FigursCell>();
    }

    [System.Serializable]
    public class FigursCell
    {
        public int id = 0;
        public GameObject figure;
        public Sprite img;
        public List<Vector2> vertex;
    }
