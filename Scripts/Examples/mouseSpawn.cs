using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseSpawn : MonoBehaviour
{
    public GameObject objectToSpawn;

    public GameObject[] balls = new GameObject[10];  

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void mouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in screen coordinates
            Vector3 mouseScreenPosition = Input.mousePosition;

            // Convert the mouse screen position to world position
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
            mouseWorldPosition.z = 0f; // Optionally, you can set the z-coordinate to 0

            // Spawn the object at the mouse world position
            Instantiate(objectToSpawn, mouseWorldPosition, Quaternion.identity);
        }
    }
}
