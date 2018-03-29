using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAndExit : MonoBehaviour {
    public GameObject Camera;
    public GameObject Player;
    public GameObject Canvas;
    public Button Play;
    public Button Exit;
    public GameObject PlayButton;
    public GameObject ExitButton;
    public bool state = true;

    public GameObject[] ballonnen;
    // Use this for initialization
    void Start () {
        Play.onClick.AddListener(PlayGame);
        Exit.onClick.AddListener(ExitGame);
    }
	
	// Update is called once per frame
	void Update () {
        ballonnen = GameObject.FindGameObjectsWithTag("Ballon");
        Debug.Log(state);

        if(ballonnen.Length == 0)
        {
            Cursor.lockState = state ? CursorLockMode.Locked : CursorLockMode.None;
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                state = !state;
                Player.SetActive(!state);
                Camera.SetActive(state);
            }
            Cursor.lockState = !state ? CursorLockMode.Locked : CursorLockMode.None;
            Canvas.SetActive(state);
        }
        
	}

    void PlayGame()
    {
        state = !state;
        Destroy(PlayButton);
        ExitButton.SetActive(true);
        Camera.SetActive(false);
        Player.SetActive(true);
    }

    void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
