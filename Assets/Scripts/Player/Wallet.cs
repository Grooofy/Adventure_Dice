using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _countCoins;
    [SerializeField] private int _allNumberCoins;

    public event UnityAction<int> CoinsCountChanged;
    public event UnityAction<int> AllCoinsCountChanged;

    private const int MultiplyCoins = 2;
    private const string Coins = "Coins";
    private const string WordAllCoins = "AllCoins";

    public int AllNumberCoins => _allNumberCoins;
    
    private void OnEnable()
    {
        LoadWallet();
    }

    public void AddCoins(int count)
    {
        _countCoins += count;
        CoinsCountChanged?.Invoke(_countCoins);
    }

    public void DoubleCoins()
    {
        _countCoins *= MultiplyCoins;
        CoinsCountChanged?.Invoke(_countCoins);
    }

    public void RemoveCoins(int count)
    {
        _allNumberCoins -= count;
        AllCoinsCountChanged?.Invoke(_allNumberCoins);
        
        SaveWallet();
    }

    public void SaveWallet()
    {
        PlayerPrefs.SetInt(Coins, _countCoins);
        PlayerPrefs.SetInt(WordAllCoins, _allNumberCoins);
    }

    private void LoadWallet()
    {
        _allNumberCoins = PlayerPrefs.GetInt(WordAllCoins);
        _allNumberCoins += PlayerPrefs.GetInt(Coins);
        AllCoinsCountChanged?.Invoke(_allNumberCoins);
    }
}
