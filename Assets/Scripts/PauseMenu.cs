using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool gameIsPaused = false;
    public GameObject pauseMenu, optionsMenu;

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (gameIsPaused){
                Resume();
            } else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        FindObjectOfType<Audio_Manager>().Stop("Pause");
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);

    }

    public void Pause()
    {
        FindObjectOfType<Audio_Manager>().Play("Pause");
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

}
    