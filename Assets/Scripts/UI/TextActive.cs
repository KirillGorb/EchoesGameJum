using UnityEngine;

public class TextActive : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
            Destroy(gameObject);
    }
}