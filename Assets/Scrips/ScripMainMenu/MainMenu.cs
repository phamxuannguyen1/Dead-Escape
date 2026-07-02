using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject _settingsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenSettings()
    {
        _settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        _settingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}