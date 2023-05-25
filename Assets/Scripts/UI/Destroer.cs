using UnityEngine;

public class Destroer : MonoBehaviour
{
    [SerializeField] private float _timeLife;
    private void Start()
    {
        Destroy(gameObject, _timeLife);
    }
}