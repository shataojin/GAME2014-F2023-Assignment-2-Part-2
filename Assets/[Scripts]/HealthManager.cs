using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Image[] healthImages;
    public AudioSource damageSound; // Reference to the AudioSource for the damage sound

    private int currentHealth;
    public static HealthManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        currentHealth = healthImages.Length;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            healthImages[currentHealth].enabled = false;

            // Play the damage sound
            if (damageSound != null)
            {
                damageSound.Play();
            }

            if (currentHealth == 0)
            {
                // Call a function to handle changing the scene
                ChangeScene();
            }
        }
    }

    void ChangeScene()
    {
        

        // Load the next scene
        SceneManager.LoadScene("EndSence");
    }
}
