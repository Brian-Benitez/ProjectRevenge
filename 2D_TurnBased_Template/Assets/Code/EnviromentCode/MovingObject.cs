using System.Collections;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float DelayRestart;
    public float MovementSpeed;

    public float MaxFallDistance;
    public float MinFallDistance;   

    public GameObject StartPoint;
    public GameObject EndPoint;

    public bool GoBack;
    public bool GoForward = true;

    private void Update()
    {
        if(Vector2.Distance(transform.position, StartPoint.transform.position) >= MaxFallDistance)
        {
            GoBack = true;
            GoForward = false;
        }

        if (Vector2.Distance(transform.position, EndPoint.transform.position) >= MinFallDistance)
        {
            GoBack = false;
            GoForward = true;
        }


        if (GoBack)
        {
            GoForward = false;
            transform.position = Vector2.MoveTowards(transform.position, StartPoint.transform.position, MovementSpeed * Time.deltaTime);
            Debug.Log(Vector2.Distance(transform.position, StartPoint.transform.position));
            Debug.Log(Vector2.Distance(transform.position, EndPoint.transform.position));
            Debug.Log("move here");
        }
        else
        {
            if(GoForward)
            {
                GoBack = false;
                transform.position = Vector2.MoveTowards(transform.position, EndPoint.transform.position, MovementSpeed * Time.deltaTime);
                
                Debug.Log("move forward");
            }
        }    

    }
}
