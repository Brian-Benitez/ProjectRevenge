using System.Collections;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [Header("Speeds")]
    public float DelayRestart;
    public float RetractSpeed;
    public float FallingSpeed;
    public float MaxWaitTime;

    [Header("GameObjects")]
    public GameObject StartPoint;
    public GameObject EndPoint;

    [Header("Bools")]
    public bool GoBack;
    public bool GoForward = true;
    float _waitTime;

    private void Update()
    {
        
        if(Vector2.Distance(transform.position, StartPoint.transform.position) <= 0f)
        {
            GoBack = false;
            GoForward = true;
        }

        if (Vector2.Distance(transform.position, EndPoint.transform.position) <= 0f)
        {
            _waitTime += Time.deltaTime;

            if (_waitTime >= MaxWaitTime)
            {
                GoBack = true;
                GoForward = false;
                _waitTime = 0f;
            }
        }
        

        if (GoBack)
        {
            GoForward = false;
            transform.position = Vector2.MoveTowards(transform.position, StartPoint.transform.position, RetractSpeed * Time.deltaTime);
        }
        else
        {
            if(GoForward)
            {
                GoBack = false;
                transform.position = Vector2.MoveTowards(transform.position, EndPoint.transform.position, FallingSpeed * Time.deltaTime);
            }
        }    

    }
}
