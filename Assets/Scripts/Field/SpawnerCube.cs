using UnityEngine;

public class SpawnerCube : PoolObject
{
    [SerializeField] private GameObject _defaultCube;
    [SerializeField] private GameObject _turnUpCube;
    [SerializeField] private GameObject _turnDownCube;
    [SerializeField] private GameObject _scoreX2Cube;

    [SerializeField] private int _numberDefaultCubes;
    [SerializeField] private int _numberTurnUpCube;
    [SerializeField] private int _numberTurnDownCube;
    [SerializeField] private int _numberScoreX2Cubes;

    private float _positionX;
    private float _cubeDistance = 1.5f;

    private void OnEnable()
    {
        Initialize(_defaultCube, _numberDefaultCubes);
        Initialize(_turnUpCube, _numberTurnUpCube);
        Initialize(_turnDownCube, _numberTurnDownCube);
        Initialize(_scoreX2Cube, _numberScoreX2Cubes);
    } 

    private void Awake() => _positionX = transform.position.x;

    private void Start() => SetCube();
   

    private void Update()
    {
        if (IsSpawnPoint())
        {
            _positionX = _positionX + _cubeDistance;
            SetCube();            
        }
    }
    
    private void SetCube()
    {
        if (TryGet(out GameObject cube))
        {
            cube.SetActive(true);
            cube.transform.position = new Vector3(transform.position.x, cube.transform.position.y, cube.transform.position.z);
        }
    }

    private bool IsSpawnPoint() => transform.position.x - _positionX >= _cubeDistance;
    
}