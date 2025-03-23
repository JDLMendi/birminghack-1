using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Function to load the menu scene
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Function to load the levels scene
    public void LoadLevels()
    {
        SceneManager.LoadScene("Levels");
    }
}

