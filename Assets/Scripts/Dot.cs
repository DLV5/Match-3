using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Dot : MonoBehaviour
{
    private Vector2 _firstTouchPosition;
    private Vector2 _finalTouchPosition;

    [SerializeField] private float _swipeAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        _firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        _finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CalculateAngle();
    }

    private void CalculateAngle()
    {
        _swipeAngle = Mathf.Atan2(_finalTouchPosition.y - _firstTouchPosition.y, _finalTouchPosition.x - _firstTouchPosition.x) / 180 * Mathf.PI;    
    }
}
