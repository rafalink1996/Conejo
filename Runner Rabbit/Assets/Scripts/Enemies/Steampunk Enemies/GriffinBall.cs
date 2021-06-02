using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GriffinBall : MonoBehaviour
{
    [SerializeField] int ballId;
    public bool canMove = false;
    public bool isAttacking = false;
    [SerializeField] GriffinBallsMovement myMovement;
    [SerializeField] GameObject proyectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        canMove = false;
    }

    public void LookAtCharacter(Vector2 target)
    {
        var offset = 180f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    public void Attack(int numOfattacks)
    {
        canMove = false;
        isAttacking = true;
        
        Debug.Log("cannot move");
        StartCoroutine(attackTime(numOfattacks));

        
    }

    IEnumerator attackTime(int numOfattacks)
    {
        for(int i = 0; i < numOfattacks; i++)
        {
            Debug.Log("ball " + ballId + " attacked " + (i + 1) + " times");
            // instantiate attack
            GameObject ballProyectile = Instantiate(proyectilePrefab, transform.position, Quaternion.identity);
            ballProyectile.transform.parent = gameObject.transform;
            ballProyectile.transform.localPosition += new Vector3(-4, 0);
            ballProyectile.transform.parent = null;
            
            
            yield return new WaitForSeconds(0.5f);
        }
        canMove = true;
        Debug.Log("can move");

        if(ballId == 1)
        {
            myMovement.ball1PositionSelected = false;
        }
        if (ballId == 2)
        {
            myMovement.ball2PositionSelected = false;
        }
    }
}
