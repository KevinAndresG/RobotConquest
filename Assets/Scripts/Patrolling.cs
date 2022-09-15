using UnityEngine;

public class Patrolling : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform[] pointsToMove;
    [SerializeField] float minDistance;
    int randomNum;
    SpriteRenderer character;
    void Start()
    {
        character = GetComponent<SpriteRenderer>();
        randomNum = Random.Range(0, pointsToMove.Length);
        Turn();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointsToMove[randomNum].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, pointsToMove[randomNum].position) < minDistance)
        {
            randomNum = Random.Range(0, pointsToMove.Length);
            Turn();
        }
    }
    void Turn()
    {
        if (transform.position.x < pointsToMove[randomNum].position.x)
        {
            character.flipX = true;
        }
        else
        {
            character.flipX = false;
        }
    }
}
