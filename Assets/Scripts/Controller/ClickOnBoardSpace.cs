using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class ClickOnBoardSpace : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        void Update()
        {
            // Detect left mouse button click
            if (Input.GetMouseButtonDown(0))
            {
                // Raycast from the mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // Check if the object hit has the SpaceView script
                    View.BoardSpace spaceView = hit.collider.gameObject.GetComponent<View.BoardSpace>();
                    if (spaceView != null)
                    {
                        Debug.Log("SpaceView object clicked: " + hit.collider.gameObject.name);
                        HandleClick(spaceView);
                    }
                }
            }
        }

        private void HandleClick(View.BoardSpace spaceView)
        {
            // Add logic to handle what happens when the object is clicked
            Debug.Log($"Handling click on: {spaceView.gameObject.name} at row {spaceView.Row} and column {spaceView.Col}");
        }
    }
}
