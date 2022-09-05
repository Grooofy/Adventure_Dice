using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Player))]
public class GameController : MonoBehaviour
{
    [SerializeField] private DiceCheckZone _zone;
    [SerializeField] private LoadingScreen _loadingScreen;
   

    public event UnityAction GameStarted;
    public event UnityAction GameOvered;

    private Player _player;
    private Wallet _wallet;
    private float _delayLoadingScreen = 0.20f;


    private void OnEnable()
    {
        _player.TurnsEnded += GameOver;
    }

    private void OnDisable()
    {
        _player.TurnsEnded -= GameOver;
    }

    private void Awake()
    {
        _player = GetComponent<Player>();
        _wallet = GetComponentInChildren<Wallet>();
    }

    private void Start()
    {
        StartCoroutine(_loadingScreen.Loading(_delayLoadingScreen));
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void TurnOffPause()
    {
        Time.timeScale = 1;
    }

    public void ReloadGame()
    {
        _wallet.SaveWallet();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnMouseDown()
    {
        StartGame();
        GameStarted?.Invoke();
    }

    private void StartGame()
    {
        _zone.gameObject.SetActive(true);
    }

    private void GameOver()
    {
        _zone.gameObject.SetActive(false);
        GameOvered?.Invoke();
    }
}