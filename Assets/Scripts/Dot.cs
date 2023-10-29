using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Dot : MonoBehaviour
{

    private Board _board;
    private GameObject _otherDot;   

    private Vector2 _firstTouchPosition;
    private Vector2 _finalTouchPosition;

    private Vector2 _tempPosition;

    [SerializeField] private float _swipeAngle;
    [SerializeField] private int _targetX;
    [SerializeField] private int _targetY;

    public int Column { get; set; }
    public int Row { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _board = FindObjectOfType<Board>();
        _targetX = (int) transform.localPosition.x;
        _targetY = (int) transform.localPosition.y;
        Row = _targetY;
        Column = _targetX;
    }

    // Update is called once per frame
    void Update()
    {
        _targetX = Column;
        _targetY = Row;
        if(Mathf.Abs(_targetX - transform.position.x) > .1f)
        {
            //Move towards the target
            _tempPosition = new Vector2(_targetX, transform.localPosition.y);
            transform.localPosition = Vector2.Lerp(transform.localPosition, _tempPosition, .4f);
        } else
        {
            //Directly set the position
            _tempPosition = new Vector2(_targetX, transform.localPosition.y);
            transform.localPosition = _tempPosition;
            _board.AllDots[Column, Row] = this.gameObject;
        }

        if (Mathf.Abs(_targetY - transform.localPosition.y) > .1f)
        {
            //Move towards the target
            _tempPosition = new Vector2(transform.localPosition.x, _targetY);
            transform.localPosition = Vector2.Lerp(transform.localPosition, _tempPosition, .4f);
        }
        else
        {
            //Directly set the position
            _tempPosition = new Vector2(transform.localPosition.x, _targetY);
            transform.localPosition = _tempPosition;
            _board.AllDots[Column, Row] = this.gameObject;
        }
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
        _swipeAngle = Mathf.Atan2(_finalTouchPosition.y - _firstTouchPosition.y,
            _finalTouchPosition.x - _firstTouchPosition.x) * 180 / Mathf.PI;
        MovePieces();
    }

    private void MovePieces()
    {
        if (_swipeAngle > -45 && _swipeAngle <= 45 && Column < _board.Width)
        {
            //Right swipe
            _otherDot = _board.AllDots[Column + 1, Row];
            _otherDot.GetComponent<Dot>().Column -= 1;
            Column += 1;
        } else if (_swipeAngle > 45 && _swipeAngle <= 135 && Row < _board.Height)
        {
            //Up swipe
            _otherDot = _board.AllDots[Column, Row + 1];
            _otherDot.GetComponent<Dot>().Row -= 1;
            Row += 1;
        } else if ((_swipeAngle > 135 || _swipeAngle <= -135) && Column > 0)
        {
            //Left swipe
            _otherDot = _board.AllDots[Column - 1, Row];
            _otherDot.GetComponent<Dot>().Column += 1;
            Column -= 1;
        } else if ((_swipeAngle < -45 && _swipeAngle >= -135) && Row > 0)
        {
            //Down swipe
            _otherDot = _board.AllDots[Column, Row - 1];
            _otherDot.GetComponent<Dot>().Row += 1;
            Row -= 1;
        }
    }
}
