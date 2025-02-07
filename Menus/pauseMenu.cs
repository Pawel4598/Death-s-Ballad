using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class pauseMenu : MonoBehaviour
{
    public GameObject Pausemenu;
    public GameObject PlayerScreen;
    public Button Resume;
    public Button ReturnToMenu;
    public Button Quit;

    // Start is called before the first frame update
    void Start()
    {
        PlayerScreen.SetActive(true);
        Pausemenu.SetActive(false);
        Resume = Resume.GetComponent<Button>();
        ReturnToMenu = ReturnToMenu.GetComponent<Button>();
        Quit = Quit.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerScreen.SetActive(false);
            Pausemenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    public void ResumeGame()
    {
        PlayerScreen.SetActive(true);
        Pausemenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void RTM()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        EditorApplication.ExitPlaymode();
    }
}
