using UnityEngine;

public class TextActive : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            gameObject.SetActive(false);
            this.enabled = false;
        }
    }
}