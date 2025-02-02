using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public class SpaceView : MonoBehaviour
    {
        [SerializeField]    private int row;
        [SerializeField]    public int col;

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