using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputManagerSO inputManager;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private GameObject mainPanel;
    

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
            hudPanel.SetActive(true);
            Time.timeScale = 1;
        }
        else
        {
            hudPanel.SetActive(false);
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

    public void Autum() {
        Destroy(GameObject.FindWithTag("Crab"));
        SoundManager.instance.PlaySfx(2);
        SoundManager.instance.PlayMusic(0);
        SceneManager.LoadScene("Autumm-level1");
    }

    public void Controls()
    {
        SoundManager.instance.PlaySfx(2);
        controlsPanel.SetActive(true);
        mainPanel.SetActive(false);

    }

    public void ReturnToMain()
    {
        SoundManager.instance.PlaySfx(2);
        controlsPanel.SetActive(false);
        mainPanel.SetActive(true);

    }

    public void ReturnToMainMenu()
    {
        Destroy(GameObject.FindWithTag("Player"));
        SoundManager.instance.PlayMusic(1);
        SoundManager.instance.PlaySfx(2);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void Crystal() {
        SoundManager.instance.PlaySfx(2);
    }
}
