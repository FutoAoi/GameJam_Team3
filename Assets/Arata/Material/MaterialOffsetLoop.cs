using UnityEngine;

public class MaterialOffsetLoop : MonoBehaviour
{
    private Material mat;

    public float speedX = 0.1f;
    public float speedY = 0f;

    public float minX = 0f;
    public float maxX = 1f;

    public float minY = 0f;
    public float maxY = 1f;

    private float offsetX;
    private float offsetY;

    void Start()
    {
        Renderer rend = GetComponent<Renderer>();

        mat = rend.material;

        offsetX = minX;
        offsetY = minY;
    }

    void Update()
    {
        offsetX += speedX * Time.deltaTime;
        offsetY += speedY * Time.deltaTime;

        offsetX = Mathf.Repeat(offsetX - minX, maxX - minX) + minX;
        offsetY = Mathf.Repeat(offsetY - minY, maxY - minY) + minY;

        mat.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}