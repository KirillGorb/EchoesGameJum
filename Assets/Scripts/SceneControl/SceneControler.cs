using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControler : MonoBehaviour
{
    [SerializeField] private SavePoint _saver;

    private float _cameraPosZ = -10;

    private void Awake()
    {
        FindObjectOfType<PlayerMove>().transform.position = _saver.SpawnPoint;
        Camera.main.transform.position = _saver.SpawnPoint + Vector3.forward * _cameraPosZ;
    }

    public void EXIT() => Application.Quit();

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    public void SetScene(int id) => SceneManager.LoadScene(id);
}