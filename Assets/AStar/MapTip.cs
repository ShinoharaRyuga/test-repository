using UnityEngine;

public class MapTip : MonoBehaviour
{
    [SerializeField] MapTipStatus _currentStatus = default;
    int _row = 0;
    int _col = 0;
    int _realCost = 0;
    int _guessCost = 0;
    int score = 0;
    SpriteRenderer _spriteRenderer => GetComponent<SpriteRenderer>();

    public int RealCost { get => _realCost; set => _realCost = value; }
    public int GuessCost { get => _guessCost; set => _guessCost = value; }
    public int Score { get => score; set => score = value; }
    public int Row { get => _row; set => _row = value; }
    public int Col { get => _col; set => _col = value; }

    public MapTipStatus CurrentStatus
    {
        get { return _currentStatus; }

        set
        {
            _currentStatus = value;
            ChangeColor();
        }
    }

    public void SetCosts(int realCost, int guessCost)
    {
        _realCost = realCost;
        _guessCost = guessCost;
        score = _realCost + _guessCost;
    }

    void ChangeColor()
    {
        switch (CurrentStatus)
        {
            case MapTipStatus.Empty:
                _spriteRenderer.color = Color.white;
                break;
            case MapTipStatus.Start:
                _spriteRenderer.color = Color.red;
                break;
            case MapTipStatus.Goal:
                _spriteRenderer.color = Color.blue;
                break;
            case MapTipStatus.Wall:
                _spriteRenderer.color = Color.gray;
                break;
            //case MapTipStatus.Open:
            //    _spriteRenderer.color = Color.cyan;
            //    break;
        }
    }

    public void DebugColor()
    {
        _spriteRenderer.color = Color.yellow;
    }
}
