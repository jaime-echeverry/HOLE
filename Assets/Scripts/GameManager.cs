using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputManagerSO inputManager;
    [SerializeField] private GameObject pausePanel;


    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        inputManager.OnPause += Pause;
    }

    private void OnDisable()
    {
        inputManager.OnPause -= Pause;
    }

    private void Pause()
    {
        SoundManager.instance.PlaySfx(3);
        if (Time.timeScale == 0)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ContinueGame() {
        SoundManager.instance.PlaySfx(2);
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SoundManager.instance.PlaySfx(2);
        Destroy(GameObject.FindWithTag("Player"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void QuitGame() {
        SoundManager.instance.PlaySfx(2);
        Application.Quit();
    }
}
