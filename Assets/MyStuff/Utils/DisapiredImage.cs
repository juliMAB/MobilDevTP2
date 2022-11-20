using UnityEngine;
using UnityEngine.UI;

public class DisapiredImage : MonoBehaviour
{
    Image image;
    public float speed;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {

        image.color = new Color(1, 1, 1, image.color.a - (1f/255f * speed));

        if (image.color.a <= 0)
            Destroy(image.gameObject);
    }
}
