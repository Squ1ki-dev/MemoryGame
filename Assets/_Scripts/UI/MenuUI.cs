using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Zenject;

public class MenuUI : MonoBehaviour
{
    private int _score = 0;
    private int _attempts = 0;
    [SerializeField] private int winScore;
    [SerializeField] private int failedAttempts;

    [SerializeField] private Button restartBtn;
    [SerializeField] private Button playBtn;

    [SerializeField] private GameObject endPanel;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text attemptsText;
    [SerializeField] private TMP_Text endText;

    [SerializeField] private AudioClip _winSound, _loseSound;

    private AudioPlayer _audioPlayer;
    private CardSpawner _cardSpawner;

    [Inject]
    private void Construct(AudioPlayer audioPlayer, CardSpawner cardSpawner)
    {
        _audioPlayer = audioPlayer;
        _cardSpawner = cardSpawner;
    }

    private void Awake()
    {
        MenuScreen();
        InitText();
        playBtn.onClick.AddListener(Play);
        restartBtn.onClick.AddListener(Restart);
    }

    private void InitText()
    {
        scoreText.text = "Score: " + _score;
        attemptsText.text = "Attempts: " + _attempts;
    }

    private void MenuScreen()
    {
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    private void Play()
    {
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
        _cardSpawner.ShuffleField();
    }

    public void IncreaseScore()
    {
        _score++;
        UpdateScoreText();
        EndGame();
    }

    public void IncreaseAttempts()
    {
        _attempts++;
        UpdateAttemptsText();
        EndGame();
    }

    private void UpdateScoreText() => scoreText.text = "Score: " + _score;

    private void UpdateAttemptsText() => attemptsText.text = "Attempts: " + _attempts;

    private void EndGame()
    {
        if(_score >= winScore)
        {
            endPanel.SetActive(true);
            endText.text = "YOU WIN!";
            _audioPlayer.PlaySfx(_winSound);
        }
        else if(_attempts >= failedAttempts)
        {
            endPanel.SetActive(true);
            _audioPlayer.PlaySfx(_loseSound);
            endText.text = "YOU LOSE :(";
        }
    }

    private void Restart() 
    {
        _score = 0;
        _attempts = 0;
        UpdateScoreText();
        UpdateAttemptsText();
        endPanel.SetActive(false);
        _cardSpawner.ShuffleField();
    }
}
