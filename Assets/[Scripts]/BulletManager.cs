using UnityEngine;
using UnityEngine.UI;

public class BulletManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform playerTransform;
    public Button fireButton;

    private bool movetoleft = false;
    Joystick _leftJoystick;
    void Start()
    {
        if (GameObject.Find("OnScreenController"))
        {
            _leftJoystick = GameObject.Find("LeftController").GetComponent<Joystick>();
        }
        fireButton.onClick.AddListener(CreateBullet);

    }

    void Update()
    {
        // Check joystick input
        if (_leftJoystick != null)
        {
            float horizontalInput = _leftJoystick.Horizontal;

            // Set movetoleft based on joystick input
            if (horizontalInput < 0)
            {
                movetoleft = true;
                Debug.Log("movetoleft = true");
            }
            else if (horizontalInput > 0)
            {
                movetoleft = false;
                Debug.Log("movetoleft = false");
            }
        }
    }



    void CreateBullet()
    {
        // Instantiate a new bullet at the player's position
        GameObject newBullet = Instantiate(bulletPrefab, playerTransform.position, Quaternion.identity);

        // Get the Rigidbody2D of the bullet if it has one
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();

        // Set the initial velocity of the bullet based on the player's direction
        if (bulletRb != null)
        {
            float bulletSpeed = 10f; // Adjust the speed as needed
           if (movetoleft == true)
            {
                // Set the velocity of the bullet using Rigidbody2D
                bulletRb.velocity = Vector2.left*bulletSpeed;
            }

            if (movetoleft == false)
            {
                // Set the velocity of the bullet using Rigidbody2D
                bulletRb.velocity = Vector2.right * bulletSpeed;
            }


        }
    }

   
}
