using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    private GameObject _dropItem;
    private int _countSpawn;

    public void SetData(GameObject dropItem, int countItem)
    {
        _dropItem = dropItem;
        _countSpawn = countItem;
    }

    private void OnDestroy()
    {
        SpawnDrop();
        FindObjectOfType<SpawnerEnemy>().CountDeatEnemy++;
    }

    private void SpawnDrop()
    {
        for (int i = 0; i < _countSpawn; i++)
            Instantiate(_dropItem, transform.position, Quaternion.identity);
    }
}