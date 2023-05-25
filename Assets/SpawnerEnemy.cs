using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Text _textCountEnemy;
    [SerializeField] private Text _textTimeLive;
    [Space(4)]
    [SerializeField] private Text _recordCountEnemy;
    [SerializeField] private Text _recordTimeLive;

    [SerializeField] private Enemy _enemy;
    [SerializeField] private GameObject _dropItem;

    [SerializeField] private Transform _startPointSpanw;
    [SerializeField] private Transform _endPointSpanw;

    [SerializeField] private float _timeSpawn;
    [SerializeField] private float _MaxTimeSpawn;
    [SerializeField] private float _VelocityTimeSpawn;
    [Space(4)]
    [SerializeField] private int _MaxBulletDrop;
    [SerializeField] private int _MinBulletDrop;
    [Space(4)]
    [SerializeField] private float _MaxDistancyOfPlayer;
    [SerializeField] private float _MinDistancyOfPlayer;
    [Space(4)]
    [SerializeField] private float _MaxTimerBullet;
    [SerializeField] private float _MinTimerBullet;
    [Space(4)]
    [SerializeField] private float _MaxSpeedBullet;
    [SerializeField] private float _MinSpeedBullet;

    private float _timeLive = 0;
    private int _countDeatEnemy = 0;

    public void TheEnd()
    {
        _recordCountEnemy.text = "" + _countDeatEnemy;
        _recordTimeLive.text = "" + _timeLive;
    }

    public int CountDeatEnemy
    {
        get => _countDeatEnemy; set
        {
            _countDeatEnemy = value;
            _textCountEnemy.text = _countDeatEnemy.ToString();
        }
    }

    private void Start()
    {
        _textCountEnemy.text = _countDeatEnemy.ToString();
        StartCoroutine(SpawnEnemys());
    }

    private void Update()
    {
        _timeLive += Time.deltaTime;
        _textTimeLive.text = ((int)_timeLive).ToString();
    }

    private IEnumerator SpawnEnemys()
    {
        while (true)
        {

            yield return new WaitForSeconds(_timeSpawn);

            if (_timeSpawn > _MaxTimeSpawn)
                _timeSpawn -= _VelocityTimeSpawn;

            Instantiate(_enemy, SpawnPoint(), Quaternion.identity)._Init_( new EnemyShootData( Random.Range(_MinSpeedBullet, _MaxSpeedBullet),
                                                                            Random.Range(_MinTimerBullet, _MaxTimerBullet) ),
                                                                            Random.Range(_MinDistancyOfPlayer, _MaxDistancyOfPlayer),
                                                                            Random.Range(_MinBulletDrop, _MaxBulletDrop), _dropItem);
        }
    }

    private Vector3 SpawnPoint() => new Vector3(Random.Range(_startPointSpanw.position.x, _endPointSpanw.position.x), Random.Range(_startPointSpanw.position.y, _endPointSpanw.position.y), 0);
}