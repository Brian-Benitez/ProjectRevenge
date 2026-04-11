using System.Collections;
using UnityEngine;

public class HitPauseController : MonoBehaviour
{
    public float HitPauseWaitTime;

    public void PlayHitPauseCoroutine() => StartCoroutine(PlayHitPause());

    public IEnumerator PlayHitPause()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(HitPauseWaitTime);
        Time.timeScale = 1f;
    }
}
