using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("Size")]
    [SerializeField] private int _width;
    [SerializeField] private int _height;

    [Header("Prefabs")]
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private GameObject[] _dots;

    private BackgroundTile[,] _allTiles;

    public GameObject[,] AllDots { get; private set; }

    public int Width { get { return _width; } set { _width = value; } }
    public int Height { get { return _height; } set { _height = value; } }

    // Start is called before the first frame update
    void Start()
    {
        _allTiles = new BackgroundTile[_width, _height];
        AllDots = new GameObject[_width, _height];
        SetUp();
    }

    private void SetUp(){
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                float tempX = this.transform.position.x + i;
                float tempY = this.transform.position.y + j;
                Vector2 tempPosition = new Vector2(tempX, tempY);

                GameObject backgroundTile = Instantiate(_tilePrefab, tempPosition, Quaternion.identity) as GameObject;

                backgroundTile.transform.parent = this.transform;
                backgroundTile.name = $"({i}, {j})";

                int dotToUse = Random.Range(0, _dots.Length);

                GameObject dot = Instantiate(_dots[dotToUse], tempPosition, Quaternion.identity);
                dot.transform.parent = this.transform;
                dot.name = $"({i}, {j})";

                AllDots[i, j] = dot;
            }
        }
    }
}
