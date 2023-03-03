using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{

    [SerializeField] private Text HeightText;
    public Text heightText { get { return HeightText; } set { HeightText = value; } }
    [SerializeField] private Slider HeightSlider;
    [SerializeField] public Slider heightSlider { get { return HeightSlider; } set { value = HeightSlider; } }
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject LevelCompletedPanel;
    private BalloonController balloon;
    public static CanvasManager Instance;
    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        balloon = GameObject.FindObjectOfType<BalloonController>();
    }

    public void Update()
    {
        HeightSlider.value = balloon.height;
        HeightText.text = ("Height: " + balloon.height);
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
    }

    public void GameCompleted()
    {
        Time.timeScale = 0;
        LevelCompletedPanel.SetActive(true);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        GameOverPanel.SetActive(false);
        LevelCompletedPanel.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
