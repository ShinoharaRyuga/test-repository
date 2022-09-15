using System;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [SerializeField] MapTip _mapTip = default;

    int[,] _mapData = new int[,]
    {
        {0, 1, 3, 0, 2 },
        {0, 0, 3, 0, 0 },
        {0, 0, 3, 0, 0 },
        {0, 0, 3, 0, 0 },
        {0, 0, 0, 0, 0 },
    };

    int _row = 0;
    int _col = 0;
    int _goalRow = 0;
    int _goalCol = 0;
    int _moveCost = 0;
    bool _isGoal = false;
    MapTip[,] _mapTips;
    MapTip _startTip = default;

    List<MapTip> _goalWay = new List<MapTip>();
    List<MapTip> _openTips = new List<MapTip>();

    int _debugCount = 0;

    void Start()
    {
        _row = _mapData.GetLength(0);
        _col = _mapData.GetLength(1);
        _mapTips = new MapTip[_row, _col];

        for (var i = 0; i < _row; i++)
        {
            for (var k = 0; k < _col; k++)
            {
                var status = (MapTipStatus)_mapData[i, k];
                var tip = Instantiate(_mapTip, new Vector2(i, k), Quaternion.identity);
                tip.CurrentStatus = status;
                _mapTips[i, k] = tip;
                tip.Row = i;
                tip.Col = k;

                switch (status)
                {
                    case MapTipStatus.Start:
                        _startTip = tip;
                        tip.gameObject.name = "Start";
                        break;
                    case MapTipStatus.Goal:
                        tip.gameObject.name = "Goal";
                        break;
                    case MapTipStatus.Wall:
                        tip.gameObject.name = $"Wall {i} {k}";
                        break;
                    case MapTipStatus.Empty:
                        tip.gameObject.name = $"Empty {i} {k}";
                        break;
                }
            }
        }

        OpenAroundTip(_startTip);
        _goalWay.Add(_startTip);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log(_goalWay.Count);
            _goalWay.ForEach(t => Debug.Log(t.name));
        }

        if (Input.GetButtonDown("Jump") && _debugCount < _goalWay.Count)
        {
            if (_goalWay[_debugCount].CurrentStatus == MapTipStatus.Close)
            {
                _goalWay[_debugCount].DebugColor();
            }

            _debugCount++;
        }
    }

    void OpenAroundTip(MapTip tip)
    {
        if (_isGoal) { return; }

        _moveCost++;

        if (tip.Col + 1 < _col)   //ã
        {
            var upTip = _mapTips[tip.Row, tip.Col + 1];
            OpenTip(upTip);
        }

        if (0 <= tip.Col - 1)   //‰º
        {
            var downTip = _mapTips[tip.Row, tip.Col - 1];
            OpenTip(downTip);
        }

        if (0 <= tip.Row - 1)   //¶
        {
            var leftTip = _mapTips[tip.Row - 1, tip.Col];
            OpenTip(leftTip);
        }

        if (tip.Row + 1 < _row)   //‰E
        {
            var rightTip = _mapTips[tip.Row + 1, tip.Col];
            OpenTip(rightTip);
        }

        OpneNextTip();
    }

    void OpenTip(MapTip tip)
    {
        if (tip.CurrentStatus == MapTipStatus.Empty)
        {
            tip.CurrentStatus = MapTipStatus.Open;
            _openTips.Add(tip);
            tip.SetCosts(_moveCost, GoalDistance(tip.Row, tip.Col));
        }
        else if (tip.CurrentStatus == MapTipStatus.Goal)
        {
            _goalWay.Add(tip);
            _isGoal = true;
            Debug.Log("Goal");
            return;
        }
    }

    void OpneNextTip()
    {
        if (_openTips.Count <= 0) return;

        var nextTip = _openTips[0];
        var minScore = nextTip.Score;

        foreach (var tip in _openTips)
        {
            if (tip.Score < minScore)
            {
                nextTip = tip;
                minScore = tip.Score;
            }

            if (tip.Score == minScore && tip.RealCost < nextTip.RealCost)
            {
                nextTip = tip;
                minScore = tip.Score;
            }

            tip.CurrentStatus = MapTipStatus.Close;
        }

        _openTips.Clear();

        if (nextTip.CurrentStatus == MapTipStatus.Goal)
        {
            Debug.Log("Goal");
            return;
        }

        _goalWay.Add(nextTip);
        OpenAroundTip(nextTip);
    }

    int GoalDistance(int r, int c)
    {
        var disR = _goalRow - r;
        var disC = _goalCol - c;

        return disR + disC;
    }
}

public enum MapTipStatus
{
    Empty = 0,
    Start = 1,
    Goal = 2,
    Wall = 3,
    Open = 4,
    Close = 5,
}
