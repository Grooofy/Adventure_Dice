using UnityEngine;

public class TurnUpCube : PropertiesCubes
{
    [SerializeField] private int _turnCount;

    protected override void UseCube(Figure figure)
    {
        figure.ChangeTurns(_turnCount);
    }
}
