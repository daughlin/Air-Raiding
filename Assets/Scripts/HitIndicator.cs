using System.Collections;
using UnityEngine;

public class HitIndicator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer hitSprite;
    [SerializeField] private float duration = 0.2f;

    private Coroutine hitRoutine;

    void Awake()
    {
        hitSprite.enabled = false;
    }

    public void ShowHit()
    {
        // Restart the timer if another hit occurs.
        if (hitRoutine != null)
        {
            StopCoroutine(hitRoutine);
        }

        hitRoutine = StartCoroutine(DisplayHit());
    }

    private IEnumerator DisplayHit()
    {
        hitSprite.enabled = true;

        yield return new WaitForSeconds(duration);

        hitSprite.enabled = false;
        hitRoutine = null;
    }
}