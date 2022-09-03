using UnityEngine;

public class TurnDownCube : PropertiesCubes
{
    [SerializeField] private int _turnCount;

    protected override void UseCube(Figure figure)
    {
        figure.ChangeTurns(_turnCount);
    }
}
