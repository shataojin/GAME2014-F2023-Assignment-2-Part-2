using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem Instance;
    public TMP_Text ScoreText; // Use TMP_Text for TextMeshPro
    public int ScoreValue = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // Corrected GameObject.Find to find the "ScoreText" object
        GameObject scoreTextObject = GameObject.Find("ScoreText");

        // Check if the object was found before using it
        if (scoreTextObject != null)
        {
            ScoreText = scoreTextObject.GetComponent<TMP_Text>();
            UpdateEnergyTextLabel(); // Update the text initially
        }
        else
        {
            Debug.LogError("ScoreText object not found!");
        }
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            // Increment the score value
            ScoreValue++;

            // Update the UI text
            UpdateEnergyTextLabel();
        }

       
    }

    public void UpdateEnergyTextLabel()
    {
        ScoreText.text = "Score: " + ScoreValue.ToString();
    }

   
}
