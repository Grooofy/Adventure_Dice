using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<ProductCard> _items;
    [SerializeField] private ItemView _teamplate;
    [SerializeField] private ShopConteiner _conteiner;
    [SerializeField] private Wallet _wallet;

    public UnityAction<ProductCard> SelectModelChanged;
    public UnityAction<List<ProductCard>> ListCompleted;
    public int WalletCons => _wallet.AllNumberCoins;
    private readonly List<ProductCard> _buyModels = new List<ProductCard>();


    private void OnEnable()
    {
        LoadModels();
        CreateItems();
        AddBuyModels();
        AddListenersBuyButtons();
    }


    private void OnDisable()
    {
        RemoveListenersSelectModels(_buyModels);
        RemoveListenersBuyButtons();
    }

    private void CreateItems()
    {
        _conteiner.ShowItems(_items, _teamplate);
    }

    private void AddBuyModels()
    {
        RemoveListenersSelectModels(_buyModels);
        _buyModels.Clear();

        foreach (var item in _items)
            if (item.IsBuy)
                _buyModels.Add(item);

        ListCompleted?.Invoke(_buyModels);
        
        AddListenersSelectModels(_buyModels);
        
        SaveModels();
    }

    private void AddListenersSelectModels(List<ProductCard> buyModels)
    {
        foreach (var model in buyModels)
            model.Selected += TurnOffSelectedModel;
    }

    private void RemoveListenersSelectModels(List<ProductCard> buyModels)
    {
        foreach (var model in buyModels)
            model.Selected -= TurnOffSelectedModel;
    }

    private void AddListenersBuyButtons()
    {
        foreach (var item in _items)
            item.SelectedBuy += BuyModel;
    }

    private void RemoveListenersBuyButtons()
    {
        foreach (var item in _items)
            item.SelectedBuy -= BuyModel;
    }

    private void TurnOffSelectedModel(ProductCard figureModel)
    {
        SelectModelChanged?.Invoke(figureModel);
        
        SaveModels();
    }

    private void BuyModel(ProductCard figureModel)
    {
        _wallet.RemoveCoins(figureModel.Price);
        
        AddBuyModels();
    }

    private void SaveModels()
    {
        foreach (var model in _items)
            SaveManager.SaveGame(model, model.Name);
    }

    private void LoadModels()
    {
        foreach (var model in _items)
        {
            ItemData data = SaveManager.LoadGame(model.Name);
            
            if (data == null)
                return;

            if (data.IsBuy)
                model.ChangeValueBuy();

            if (data.IsSelect)
                model.TrySelect();
            else
                model.RemoveSelect();
        }
    }
}