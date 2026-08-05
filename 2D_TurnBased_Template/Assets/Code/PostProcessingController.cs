using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class PostProcessingController : MonoBehaviour
{
   public static PostProcessingController Instance;
    public float WaitTimeToDismissEffect;
    public Volume VolumeProfileRef;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void PlayCorutineHitEffect() => StartCoroutine(PlayHitPostProcessing());
    IEnumerator PlayHitPostProcessing()
    {
        VolumeProfileRef.weight = 1.0f;
        yield return new WaitForSecondsRealtime(WaitTimeToDismissEffect);
        VolumeProfileRef.weight = 0f;
    }
}
