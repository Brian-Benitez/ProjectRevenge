using UnityEngine;

public class EnemyFlipSprite : MonoBehaviour
{
    public SpriteRenderer SpriteRendererRef;
    private void Update()
    {
        Vector3 enemyDirectionLocal = PlayerController.Instance.Player.transform.InverseTransformPoint(this.transform.position);
        if (enemyDirectionLocal.x < 0)
        {
            SpriteRendererRef.flipX = true;
        }
        else if (enemyDirectionLocal.x > 0)
        {
            SpriteRendererRef.flipX = false;
        }
    }
}
