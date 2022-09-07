using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Shop : MonoBehaviour
{
    [SerializeField] private List<FigureModel> _items;
    [SerializeField] private ItemView _teamplate;
    [SerializeField] private ShopConteiner _conteiner;
    [SerializeField] private Wallet _wallet;

    public UnityAction<FigureModel> SelectModelChanged;
    public UnityAction<List<FigureModel>> ListCompleted;
    public int WalletCons => _wallet.AllNumberCoins;
    private readonly List<FigureModel> _buyModels = new List<FigureModel>();


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

    private void AddListenersSelectModels(List<FigureModel> buyModels)
    {
        foreach (var model in buyModels)
            model.Selected += TurnOffSelectedModel;
    }

    private void RemoveListenersSelectModels(List<FigureModel> buyModels)
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

    private void TurnOffSelectedModel(FigureModel figureModel)
    {
        SelectModelChanged?.Invoke(figureModel);
        
        SaveModels();
    }

    private void BuyModel(FigureModel figureModel)
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