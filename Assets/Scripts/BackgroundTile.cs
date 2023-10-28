using UnityEngine;

public class BackgroundTile : MonoBehaviour
{
    [SerializeField] private GameObject[] _dots;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Initialize()
    {
        int dotToUse = Random.Range(0, _dots.Length);

        GameObject dot = Instantiate(_dots[dotToUse], transform.position, Quaternion.identity);
        dot.transform.parent = this.transform;
        dot.name = this.gameObject.name;
    }
}
