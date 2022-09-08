using UnityEngine;

public class DefaultCube : PropertiesCubes
{
    private int _cointCount = 3;

    protected override void UseCube(Figure figure) => figure.TakeCoins(_cointCount);
}
