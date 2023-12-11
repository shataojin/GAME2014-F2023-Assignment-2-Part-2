using UnityEngine;

public class QuitGameOnEscape : MonoBehaviour
{
    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Debug.Log("game quit by esc");
            Application.Quit();
        }
    }
}
