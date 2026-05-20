using UnityEngine;
using System.Collections;

public class RandomInvisibleFloor3D : MonoBehaviour
{
    [Header("消えるまでのランダム時間")]
    public float minDisappearTime = 1f;
    public float maxDisappearTime = 3f;

    [Header("消えているランダム時間")]
    public float minInvisibleTime = 1f;
    public float maxInvisibleTime = 3f;

    private MeshRenderer meshRenderer;

    public bool IsInvisible;
    
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(RandomDisappear());
        IsInvisible = true;
    }

    IEnumerator RandomDisappear()
    {
        while (true)
        {
            float waitTime = Random.Range(minDisappearTime, maxDisappearTime);
            yield return new WaitForSeconds(waitTime);

            // 見た目だけ消す（当たり判定は残る）
            meshRenderer.enabled = false;
            IsInvisible = false;

            float invisibleTime = Random.Range(minInvisibleTime, maxInvisibleTime);
            yield return new WaitForSeconds(invisibleTime);

            // 見た目を戻す
            meshRenderer.enabled = true;
            IsInvisible = true;
        }
    }
}