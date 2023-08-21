using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Credits1Button()
    {
        LoadSceneByName("Credits");
    }

	public void Credits2Button()
	{
		LoadSceneByName("Credits 2");
	}

	public void Credits3Button()
	{
		LoadSceneByName("Credits 3");
	}

	public void StartGameButton()
    {
        LoadSceneByName("Karen");
    }

    public void BackToTitle()
    {
		LoadSceneByName("Title");
	}

    public void QuitGame()
    {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
	}

	public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
