using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "new figure", menuName = "FigureModel", order = 53)]
public class FigureModel : ScriptableObject
{
    [SerializeField] private Model _model;
    [SerializeField] private Sprite _label;
    [SerializeField] private string _name;
    [SerializeField] private int _price;
    [SerializeField] private bool _isSelect;
    [SerializeField] private bool _isBuy;

    public event UnityAction<FigureModel> Selected;
    public event UnityAction<FigureModel> NotSelected;
    public event UnityAction<FigureModel> SelectedBuy;

    public Model Model => _model;
    public Sprite Label => _label;
    public string Name => _name;
    public int Price => _price;
    public bool IsSelect => _isSelect;
    public bool IsBuy => _isBuy;


    public void TrySelect()
    {
        if (_isBuy == false) return;
        _isSelect = true;
        Selected?.Invoke(this);
    }

    public void RemoveSelect()
    {
        _isSelect = false;
        NotSelected?.Invoke(this);
    }

    public void ChangeValueBuy()
    {
        _isBuy = true;
        SelectedBuy?.Invoke(this);
    }
}
