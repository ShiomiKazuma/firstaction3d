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
    /// <summary>�t�B�[���h�̏c��</summary>
    [SerializeField] int _maxHight;
    /// <summary>�t�B�[���h�̉���</summary>
    [SerializeField] int _maxWight;
    int _z; //�c�̗v�f�ԍ�
    int _x; //���̗v�f�ԍ�
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
        // 5�����̃T�C�Y�ł͐����ł��Ȃ�
        if (_maxHight < 5 || _maxWight < 5) throw new ArgumentOutOfRangeException();
        if (_maxWight % 2 == 0) _maxWight++;
        if (_maxHight % 2 == 0) _maxHight++;
        field = new int[_maxHight, _maxWight];

        // �w��T�C�Y�Ő������O����ǂɂ���
        for (_x = 0; _x < _maxWight; _x++)
        {
            for (_z = 0; _z < _maxHight; _z++)
            {
                if (_x == 0 || _z == 0 || _x == _maxWight - 1 || _z == _maxHight - 1)
                {
                    field[_x, _z] = _wall; // �O���͂��ׂĕ�
                }
                else
                {
                    field[_x, _z] = _path;  // �O���ȊO�͒ʘH
                }

            }
        }

        // �_�𗧂āA�|��
        for (_x = 2; _x < _maxWight - 1; _x += 2)
        {
            for (_z = 2; _z < _maxHight - 1; _z += 2)
            {
                field[_x, _z] = _wall; // �_�𗧂Ă�

                // �|����܂ŌJ��Ԃ�
                while (true)
                {
                    // 1�s�ڂ̂ݏ�ɓ|����
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


                    // �_��|�����������߂�
                    int wallX = _x;
                    int wallY = _z;
                    switch (direction)
                    {
                        case 0: // �E
                            wallX++;
                            break;
                        case 1: // ��
                            wallY++;
                            break;
                        case 2: // ��
                            wallX--;
                            break;
                        case 3: // ��
                            wallY--;
                            break;
                    }
                    // �ǂ���Ȃ��ꍇ�̂ݓ|���ďI��
                    if (field[wallX, wallY] != _wall)
                    {
                        field[wallX, wallY] = _wall;
                        break;
                    }
                }
            }
        }

        //�ǂ̍���������Ă���
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

        //�X�^�[�g����ʒu�����߂�
        for(_x = 1; _x < _maxWight - 1; _x++)
        {
            for(_z = 1; _z < _maxHight - 1; _z++)
            {
                if(field[_x, _z] == _path)
                {
                    //field[_x, _z] = _start;
                    //�v���C���[���X�^�[�g�ʒu�ɐ�������
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

        //�S�[���̈ʒu�����߂�
        for(_x = _maxWight - 1; _x > 0; _x--)
        {
            for (_z = _maxHight - 1; _z > 0; _z--)
            {
                if (field[_x, _z] == _path)
                {
                    //field[_x, _z] = _end;
                    //�S�[���𐶐�����
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