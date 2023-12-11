using UnityEngine;
using UnityEngine.SceneManagement;

public class ScorSaver : MonoBehaviour
{
    private ScoreSystem scoreSystem;
    public int Savingscore;

    private void Start()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();

        if (scoreSystem == null)
        {
            Debug.LogError("ScoreSystem not found in the scene!");
        }
    }

    private void Update()
    {
        CheckForSceneChange();
    }

    private void CheckForSceneChange()
    {
        if (SceneManager.GetActiveScene().name == "EndSence")
        {
            // Retrieve Savingscore and add it to the score
            scoreSystem.ScoreValue += Savingscore;
            scoreSystem.UpdateEnergyTextLabel();

            // Destroy the ScoreSaver GameObject in the end game scene
            Destroy(gameObject);
        }
    }
}
