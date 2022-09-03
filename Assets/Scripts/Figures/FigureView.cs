using UnityEngine;

public class FigureView : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;

    private Model _figure;

    private void OnEnable()
    {
        _inventory.ModelSelect += ShowModel;
    }

    private void OnDisable()
    {
        _inventory.ModelSelect -= ShowModel;
    }

    private void ShowModel(FigureModel figureModel)
    {
        if (_figure != null)
            Destroy(_figure.gameObject);

        _figure = Instantiate(figureModel.Model, transform);
    }
}