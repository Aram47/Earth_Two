

// using UnityEngine;

// public class PlanetSpin : MonoBehaviour
// {
//     private bool isDragging = false;
//     private Vector2 lastTouchPosition;
//     private float dragSpeed = 5f; // Adjust sensitivity
//     private float inertiaDecay = 0.98f; // Rate of inertia decay
//     private Vector2 currentVelocity; // Current spinning velocity
//     private float autoRotationSpeed = 10f; // Adjust auto rotation speed

//     void Update()
//     {
//         // Apply auto rotation
//         transform.Rotate(Vector3.up, autoRotationSpeed * Time.deltaTime, Space.World);

//         // Handle touch input for swipes
//         if (Input.touchCount > 0)
//         {
//             Touch touch = Input.GetTouch(0);
//             switch (touch.phase)
//             {
//                 case TouchPhase.Began:
//                     isDragging = true;
//                     lastTouchPosition = touch.position;
//                     currentVelocity = Vector2.zero; // Reset velocity when starting to drag
//                     break;
//                 case TouchPhase.Moved:
//                     if (isDragging)
//                     {
//                         Vector2 deltaTouchPosition = touch.position - lastTouchPosition;
//                         transform.Rotate(Vector3.up, -deltaTouchPosition.x * dragSpeed * Time.deltaTime, Space.World); // Rotate horizontally based on touch movement
//                         transform.Rotate(transform.right, deltaTouchPosition.y * dragSpeed * Time.deltaTime, Space.World); // Rotate vertically based on touch movement

//                         lastTouchPosition = touch.position;
//                     }
//                     break;
//                 case TouchPhase.Ended:
//                 case TouchPhase.Canceled:
//                     isDragging = false;
//                     currentVelocity = touch.deltaPosition * dragSpeed * Time.deltaTime; // Calculate initial velocity
//                     break;
//             }
//         }

//         if (!isDragging && currentVelocity.magnitude > 0.01f) // Apply inertia if not dragging
//         {
//             transform.Rotate(Vector3.up, currentVelocity.x * Time.deltaTime, Space.World); // Apply inertia rotation horizontally
//             transform.Rotate(transform.right, currentVelocity.y * Time.deltaTime, Space.World); // Apply inertia rotation vertically
//             currentVelocity *= inertiaDecay; // Decay velocity over time
//         }
//     }
// }


using UnityEngine;

public class PlanetSpin : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 lastMousePosition;
    private float dragSpeed = 90f; // Adjust sensitivity
    private float inertiaDecay = 0.98f; // Rate of inertia decay
    private Vector3 currentVelocity; // Current spinning velocity
    private float autoRotationSpeed = 10f; // Adjust auto rotation speed

    void Update()
    {
        // Apply auto rotation
        transform.Rotate(Vector3.up, autoRotationSpeed * Time.deltaTime, Space.World);

        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
            //currentVelocity = Vector3.zero; // Reset velocity when starting to drag
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            currentVelocity = (Input.mousePosition - lastMousePosition) * dragSpeed * Time.deltaTime; // Calculate initial velocity
        }

        if (isDragging)
        {
            Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition;
            transform.Rotate(Vector3.up, -deltaMousePosition.x * dragSpeed * Time.deltaTime, Space.World); // Rotate horizontally based on mouse movement
            transform.Rotate(transform.right, deltaMousePosition.y * dragSpeed * Time.deltaTime, Space.World); // Rotate vertically based on mouse movement

            lastMousePosition = Input.mousePosition;
        }
        else if (currentVelocity.magnitude > 0.01f) // Apply inertia if not dragging
        {
            transform.Rotate(Vector3.up, currentVelocity.x * Time.deltaTime, Space.World); // Apply inertia rotation horizontally
            transform.Rotate(transform.right, currentVelocity.y * Time.deltaTime, Space.World); // Apply inertia rotation vertically
            currentVelocity *= inertiaDecay; // Decay velocity over time
        }
    }
}
    
