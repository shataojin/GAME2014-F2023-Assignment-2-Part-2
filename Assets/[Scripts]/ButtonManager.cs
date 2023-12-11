using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //mian menu parts
    public bool InstructionOn = false;
    public GameObject playButton;
    public GameObject InstructionsButton;
    public GameObject QuitButton;
    public GameObject InstructionWords;
    public GameObject BackButton;
    //lose scene
    public GameObject Losereturntomenu;
    public GameObject LosePlayagain;
    //change scene in game
    public GameObject ChangetoWIN;
    public GameObject ChangetoLOSE;
    public void Play()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void Instruction()
    {
        // Set InstructionOn to true
        InstructionOn = true;

        // Hide and show things
        MainMenuVisibility(false);
        InstructionVisibility(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {


        // Hide and show things
        MainMenuVisibility(true);
        InstructionVisibility(false);
    }

    public void loseplayagain()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void loseReturntomenu()
    {

        SceneManager.LoadScene("MainMenu");
    }

    public void ChangetoWINS()
    {

        //SceneManager.LoadScene("MainMenu");
        Debug.Log("nothing happend for now");
    }
    public void ChangetoLOSES()
    {

        SceneManager.LoadScene("EndSence");
    }

    void Update()
    {
        if (InstructionOn)
        {
            Debug.Log("InstructionOn is true");
        }
        if (!InstructionOn)
        {
            Debug.Log("InstructionOn is false");
        }



    }

    void MainMenuVisibility(bool isVisible)
    {
        playButton.SetActive(isVisible);
        InstructionsButton.SetActive(isVisible);
        QuitButton.SetActive(isVisible);
    }
    void InstructionVisibility(bool isVisible)
    {
        InstructionWords.SetActive(isVisible);
        BackButton.SetActive(isVisible);
    }
}
