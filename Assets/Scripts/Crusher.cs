using UnityEngine;

public class Crusher : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform[] pointsToMove;
    [SerializeField] float minDistance;
    int NextStep;
    SpriteRenderer character;
    void Start()
    {
        NextStep = 0;
        character = GetComponent<SpriteRenderer>();
        Turn();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointsToMove[NextStep].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, pointsToMove[NextStep].position) < minDistance)
        {
            NextStep ++;
            if(NextStep >= pointsToMove.Length)
            {
                NextStep = 0;
            }
            Turn();
        }
    }
    void Turn()
    {
        if (transform.position.x < pointsToMove[NextStep].position.x)
        {
            character.flipX = true;
        }
        else
        {
            character.flipX = false;
        }
    }
}
