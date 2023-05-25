using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControler : MonoBehaviour
{
    [SerializeField] private SavePoint _saver;

    private void Awake()
    {
        var player = FindObjectOfType<PlayerMove>().transform;
        var camera = Camera.main.transform;

        player.position = _saver.SpawnPoint;
        camera.position = _saver.SpawnPoint + Vector3.forward * -10;
    }

    public void EXIT() => Application.Quit();

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    public void SetScene(int id) => SceneManager.LoadScene(id);
}