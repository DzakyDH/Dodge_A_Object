using UnityEngine;

public class FailingObject : MonoBehaviour
{
    public int scoreValue = 10;
    void Update()
    {
        if (transform.position.y < -6f)
        {
            ScoreManajer.Instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
