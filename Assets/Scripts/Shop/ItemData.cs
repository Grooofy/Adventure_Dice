
[System.Serializable]
public class ItemData
{
    public bool IsSelect { get; private set; }
    public bool IsBuy { get; private set; }

    public ItemData (ProductCard model)
    {
        IsSelect = model.IsSelect;
        IsBuy = model.IsBuy;
    }
}