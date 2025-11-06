using System.Collections;
using UnityEngine;

public class KnockForwardFeedBack : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D Rb2d;  

    [SerializeField]
    private float Strength = 16, delay = 0.15f;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mouseScreenPos = Input.mousePosition;
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            mouseWorldPos.z = transform.position.z;

            Vector3 directionToMouse = (mouseWorldPos - transform.position).normalized;

            Rb2d.AddForce(directionToMouse * Strength, ForceMode2D.Impulse);
            Debug.Log("push forward");
        }
    }

    public void PlayFeedBack(GameObject sender)
    {
        StopAllCoroutines();
        Vector2 direction = (transform.position + sender.transform.position).normalized;
        
        Rb2d.AddForce(direction * Strength, ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        Rb2d.linearVelocity = Vector3.zero;
    }
}
