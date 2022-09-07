using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Shop _shop;

    public UnityAction<FigureModel> ModelSelect;

    private FigureModel _selectModel;

    private void OnEnable()
    {
        _shop.ListCompleted += InitializeSelectModel;
        _shop.SelectModelChanged += SetNewModel;
    }

    private void OnDisable()
    {
        _shop.ListCompleted -= InitializeSelectModel;
        _shop.SelectModelChanged -= SetNewModel;
    }
    
    private void InitializeSelectModel(List<FigureModel> figureModels)
    {
        foreach (var model in figureModels.Where(model => model.IsSelect))
        {
            if (_selectModel == model) continue;
           _selectModel = model;
            ModelSelect?.Invoke(_selectModel);
        }
    }

    private void SetNewModel(FigureModel newModel)
    {
        _selectModel.RemoveSelect();
        _selectModel = newModel;
        ModelSelect?.Invoke(newModel);
    }
}
