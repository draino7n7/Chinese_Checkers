using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public class BoardSpace : MonoBehaviour
    {
        [SerializeField]    private int row;
        [SerializeField]    private int col;

        public int Row { get { return row; } }
        public int Col { get { return col; } } 

        // Start is called before the first frame update
        void Start()
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}