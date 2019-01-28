using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;
    public AudioMixer musicMixer, sfxMixer;
    public static float musicVol, sfxVol;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        FindObjectOfType<PauseMenu>().Resume();
        SceneManager.LoadScene(0);
    }

    public void SliderValues(){
        musicMixer.GetFloat("MainVolume", out musicVol);
        musicSlider.value = musicVol;

        sfxMixer.GetFloat("SFXVolume", out sfxVol);
        sfxSlider.value = sfxVol;
    }
}

