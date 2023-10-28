using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("Size")]
    [SerializeField] private int _width;
    [SerializeField] private int _height;

    [Header("Prefabs")]
    [SerializeField] private GameObject _tilePrefab;

    private BackgroundTile[,] _allTiles;

    // Start is called before the first frame update
    void Start()
    {
        _allTiles = new BackgroundTile[_width, _height];
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
            }
        }
    }
}
