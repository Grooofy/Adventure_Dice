using UnityEngine;

public class TurnUpCube : PropertiesCubes
{
    private int _turnCount = 3;

    protected override void UseCube(Figure figure) => figure.ChangeTurns(_turnCount);
}
