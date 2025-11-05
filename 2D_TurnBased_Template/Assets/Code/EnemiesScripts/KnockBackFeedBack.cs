using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class KnockBackFeedBack : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D Rb2d;

    [SerializeField]
    private float Strength = 16, delay = 0.15f;

    public UnityEvent OnBegin, OnDone;

    public void PlayFeedBack(GameObject sender)
    {
        StopAllCoroutines();
        OnBegin.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;

        Rb2d.AddForce(direction * Strength, ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        Rb2d.linearVelocity = Vector3.zero;
        OnDone.Invoke();
    }
}
