using UnityEngine;

public class TextFlow : MonoBehaviour
{
    public float scrollSpeed = 1f;

    private void Update()
    {
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
    }
}
