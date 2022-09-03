using TMPro;
using UnityEngine;

public class WalletText : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    private TMP_Text _tmp;

    private void OnEnable()
    {
        _wallet.AllCoinsCountChanged += ShowNumber;
        ShowNumber(_wallet.AllNumberCoins);
    }

    private void Awake()
    {
        _tmp = GetComponent<TMP_Text>();
    }

    private void ShowNumber(int number)
    {
        _tmp.text = number.ToString();
    }
}
