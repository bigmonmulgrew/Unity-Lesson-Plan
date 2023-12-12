using UnityEngine;

public class Paddle : MonoBehaviour
{
    float screenWidthInUnits = 16f; // The width of the screen in world units
    float range = 8f; // Max X position the paddle can go to
    

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);

        // Convert mouse position to world units
        float mousePosInUnits = (Input.mousePosition.x / Screen.width * screenWidthInUnits) - (screenWidthInUnits / 2);

        // Clamp the position to keep the paddle within screen bounds
        paddlePos.x = Mathf.Clamp(mousePosInUnits, -range, range);

        transform.position = paddlePos;
    }
}
