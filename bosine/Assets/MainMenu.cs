using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); // Assicurati che "GameScene" sia il nome esatto della tua scena
    }

    public void OpenOptions()
    {
        Debug.Log("Opzioni aperte");
    }

    public void QuitGame()
    {
        Debug.Log("Gioco chiuso");
        Application.Quit();
    }
}

