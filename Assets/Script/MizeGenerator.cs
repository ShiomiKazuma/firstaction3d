using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class MizeGenerator : MonoBehaviour
{
    const int _path = 0;
    const int _wall = 1;
    //const int _start = 2;
    //const int _end = 3;
    /// <summary>フィールドの縦幅</summary>
    [SerializeField] int _maxHight;
    /// <summary>フィールドの横幅</summary>
    [SerializeField] int _maxWight;
    int _z; //縦の要素番号
    int _x; //横の要素番号
    int _rnd;

    [SerializeField] GameObject _wallObject;
    float _wallSizeY;
    int[,] field;
    bool _statrtPosJuge = false;
    bool _endPosJuge = false;
    [SerializeField] GameObject _playerObject;
    float _playerSizeY;
    [SerializeField] GameObject _goalObject;
    float _goalSizeY;
    // Start is called before the first frame update
    void Start()
    {
        // 5未満のサイズでは生成できない
        if (_maxHight < 5 || _maxWight < 5) throw new ArgumentOutOfRangeException();
        if (_maxWight % 2 == 0) _maxWight++;
        if (_maxHight % 2 == 0) _maxHight++;
        field = new int[_maxHight, _maxWight];

        // 指定サイズで生成し外周を壁にする
        for (_x = 0; _x < _maxWight; _x++)
        {
            for (_z = 0; _z < _maxHight; _z++)
            {
                if (_x == 0 || _z == 0 || _x == _maxWight - 1 || _z == _maxHight - 1)
                {
                    field[_x, _z] = _wall; // 外周はすべて壁
                }
                else
                {
                    field[_x, _z] = _path;  // 外周以外は通路
                }

            }
        }

        // 棒を立て、倒す
        for (_x = 2; _x < _maxWight - 1; _x += 2)
        {
            for (_z = 2; _z < _maxHight - 1; _z += 2)
            {
                field[_x, _z] = _wall; // 棒を立てる

                // 倒せるまで繰り返す
                while (true)
                {
                    // 1行目のみ上に倒せる
                    float direction;
                    if (_z == 2)
                    {
                        _rnd = Random.Range(0, 4);
                        direction = _rnd;
                    }
                    else
                    {
                        _rnd = Random.Range(0, 3);
                        direction = _rnd;
                    }


                    // 棒を倒す方向を決める
                    int wallX = _x;
                    int wallY = _z;
                    switch (direction)
                    {
                        case 0: // 右
                            wallX++;
                            break;
                        case 1: // 下
                            wallY++;
                            break;
                        case 2: // 左
                            wallX--;
                            break;
                        case 3: // 上
                            wallY--;
                            break;
                    }
                    // 壁じゃない場合のみ倒して終了
                    if (field[wallX, wallY] != _wall)
                    {
                        field[wallX, wallY] = _wall;
                        break;
                    }
                }
            }
        }

        //壁の高さを取ってくる
        _wallSizeY = _wallObject.transform.localScale.y / 2;

        for (_x = 0; _x < _maxWight; _x++)
        {
            for (_z = 0; _z < _maxHight; _z++)
            {
                if (field[_x, _z] == _wall)
                {
                    Instantiate(_wallObject, new Vector3(1.0f * _x, _wallSizeY, 1.0f * _z), Quaternion.identity);
                }

                Debug.Log(field[_x, _z]);
            }
        }

        //スタートする位置を決める
        for(_x = 1; _x < _maxWight - 1; _x++)
        {
            for(_z = 1; _z < _maxHight - 1; _z++)
            {
                if(field[_x, _z] == _path)
                {
                    //field[_x, _z] = _start;
                    //プレイヤーをスタート位置に生成する
                    _playerSizeY = _playerObject.transform.localScale.y / 2;
                    Instantiate(_playerObject, new Vector3(1.0f * _x, _playerSizeY, 1.0f * _z), Quaternion.identity);
                    _statrtPosJuge = true;
                    break;
                }
            }

            if(_statrtPosJuge)
            {
                break;
            }
        }

        //ゴールの位置を決める
        for(_x = _maxWight - 1; _x > 0; _x--)
        {
            for (_z = _maxHight - 1; _z > 0; _z--)
            {
                if (field[_x, _z] == _path)
                {
                    //field[_x, _z] = _end;
                    //ゴールを生成する
                    _goalSizeY = _goalObject.transform.localScale.y / 2;
                    Instantiate(_goalObject, new Vector3(1.0f * _x, _goalSizeY, 1.0f * _z), Quaternion.identity);
                    _endPosJuge = true;
                    break;
                }
            }

            if (_endPosJuge)
            {
                break;
            }
        }
    }
}