using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image _label;
    [SerializeField] private TextMeshProUGUI _labelText;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private Button _sellect;
    [SerializeField] private Button _buy;

    private ProductCard _figureModel;
    private Shop _shop;
    
    private void OnEnable()
    {
        _shop = GetComponentInParent<Shop>();
        _sellect.onClick.AddListener(SelectModel);
        _figureModel.Selected += Render;
        _figureModel.NotSelected += Render;
        _buy.onClick.AddListener(() => TryBuyModel(_shop.WalletCons));
        _figureModel.SelectedBuy += Render;
    }

    private void OnDisable()
    {
        _sellect.onClick.RemoveListener(SelectModel);
        _figureModel.Selected -= Render;
        _figureModel.NotSelected -= Render;
        _buy.onClick.RemoveListener(() => TryBuyModel(_shop.WalletCons));
        _figureModel.SelectedBuy -= Render;
    }

    public void Render(ProductCard figureModel)
    {
        _figureModel = figureModel;
        _label.sprite = figureModel.Label;
        _labelText.text = figureModel.Name;
        _price.text = figureModel.Price.ToString();

        if (figureModel.IsSelect)
            TurnOffButton(_sellect);
        else
            TurnOnButton();

        if (figureModel.IsBuy)
        {
            TurnOffButton(_buy);
            _price.gameObject.SetActive(false);
        }
    }

    private void TurnOffButton(Button button) => button.interactable = false;

    private void TurnOnButton() => _sellect.interactable = true;

    private void SelectModel() => _figureModel.TrySelect();

    private void TryBuyModel(int coins)
    {
        if (coins >= _figureModel.Price)
            _figureModel.ChangeValueBuy();
    }
}
