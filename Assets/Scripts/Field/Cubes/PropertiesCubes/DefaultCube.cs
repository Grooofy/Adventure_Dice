using UnityEngine;

public class DefaultCube : PropertiesCubes
{
    [SerializeField] private int _cointCount;

    protected override void UseCube(Figure figure)
    {
        figure.TakeCoins(_cointCount);
    }
}
