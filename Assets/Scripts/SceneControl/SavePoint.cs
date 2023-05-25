using UnityEngine;

[CreateAssetMenu()]
public class SavePoint : ScriptableObject
{
    [SerializeField] private Vector3 _startSpawnPoint;
    [SerializeField] private Vector3 _spawnPoint;

    public void SetStart() => SpawnPoint = Vector3.zero;

    public Vector3 SpawnPoint { get => _spawnPoint.x == 0 ? _startSpawnPoint : _spawnPoint; set => _spawnPoint = value; }
}