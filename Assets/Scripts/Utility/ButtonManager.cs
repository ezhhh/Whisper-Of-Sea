using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject exitPanel;
    public GameObject settingsPanel;
    public GameObject creditsPanel;

    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitButton()
    {
        mainMenuPanel.SetActive(false);
        exitPanel.SetActive(true);
    }

    public void CancelButton()
    {
        exitPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        // creditsPanel.SetActive(false);
        // settingsPanel.SetActive(false);
    }

    public void AcceptExitButton()
    {
        Application.Quit();
    }

    public void SettingsButton()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void ExitSettingsButton()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void CreditsButton()
    {
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void ExitCreditsButton()
    {
        mainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
}
