using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class WalletText : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    
    private TMP_Text _tmp;

    private void OnEnable()
    {
        _wallet.AllCoinsCountChanged += ShowNumber;
        ShowNumber(_wallet.AllNumberCoins);
    }

    private void OnDisable()
    {
        _wallet.AllCoinsCountChanged -= ShowNumber;
    }

    private void Awake() => _tmp = GetComponent<TMP_Text>();

    private void ShowNumber(int number) => _tmp.text = number.ToString();
}
