using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.TryGetComponent(out Enemy enemy))
        {
            Debug.Log("Enemy destroyed");
            enemy.ExplodeOfWall();
            Destroy(other.gameObject);
        }
       
    }
}