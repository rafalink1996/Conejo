using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GriffinBallsMovement : MonoBehaviour
{
    [SerializeField] Transform startPosition;
    [SerializeField] Transform[] positions;

    [SerializeField] GameObject griffinBall1;
    [SerializeField] GameObject griffinBall2;

    GriffinBall ball1Cs;
    GriffinBall ball2Cs;

    int ball1Position;
    int ball2Position;

    bool ball1Up;
    bool ball2Up;

   public bool ball1PositionSelected = false;
   public bool ball2PositionSelected = false;

    int goToPositionBall1;
    int goToPositionBall2;

    float ballSpeed = 5;

    public bool firstPositionReached;

    GameObject ChaObject;
    character ChaCs;


    // Start is called before the first frame update
    void Start()
    {
        griffinBall1.transform.position = startPosition.position;
        griffinBall2.transform.position = startPosition.position;
        ball1Cs = griffinBall1.GetComponent<GriffinBall>();
        ball2Cs = griffinBall2.GetComponent<GriffinBall>();
        ChaObject = GameObject.FindGameObjectWithTag("Player"); ;
        ChaCs = ChaObject.GetComponent<character>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!firstPositionReached)
        {
            GoToFirstPosition();
            if (griffinBall1.transform.position == positions[0].position && griffinBall2.transform.position == positions[3].position)
            {
                ball1Up = true;
                ball2Up = true;
                ball1Position = 0;
                ball2Position = 3;
                firstPositionReached = true;
            }
        }
        else
        {

            Ball1Behaviour();
            Ball2Behaviour();
        }

    }

    void GoToFirstPosition()
    {
        griffinBall1.transform.position = Vector2.MoveTowards(griffinBall1.transform.position, positions[0].position, (ballSpeed * Mathf.Clamp(Vector3.Distance(griffinBall2.transform.position, positions[0].position), 0.5f, 1)) * Time.deltaTime);
        griffinBall2.transform.position = Vector2.MoveTowards(griffinBall2.transform.position, positions[3].position, (ballSpeed * Mathf.Clamp(Vector3.Distance(griffinBall2.transform.position, positions[3].position), 0.5f, 1)) * Time.deltaTime);
    }



    void Ball1Behaviour()
    {
        ball1Cs.LookAtCharacter(ChaObject.transform.position);

        if (!ball1PositionSelected)
        {
            goToPositionBall1 = RandomPositions(!ChaCs.top);
            ball1PositionSelected = true;
            ball1Cs.canMove = true;
        }

        if (ball1Cs.canMove)
        {
            griffinBall1.transform.position = Vector2.MoveTowards(griffinBall1.transform.position, positions[goToPositionBall1].position, (ballSpeed * Mathf.Clamp(Vector3.Distance(griffinBall1.transform.position, positions[goToPositionBall1].position), 0.5f, 1)) * Time.deltaTime);
            if (griffinBall1.transform.position == positions[goToPositionBall1].position)
            {
                ball1Position = goToPositionBall1;
                ball1Cs.Attack(Random.Range(1, 3));
                ball1Cs.canMove = false;
            }
        }
    }

    void Ball2Behaviour()
    {
        ball2Cs.LookAtCharacter(ChaObject.transform.position);

        if (!ball2PositionSelected)
        {
            goToPositionBall2 = RandomPositions(!ChaCs.top);
            ball2PositionSelected = true;
            ball2Cs.canMove = true;
        }

        if (ball2Cs.canMove)
        {
            griffinBall2.transform.position = Vector2.MoveTowards(griffinBall2.transform.position, positions[goToPositionBall2].position, (ballSpeed * Mathf.Clamp(Vector3.Distance(griffinBall2.transform.position, positions[goToPositionBall2].position), 0.5f, 1)) * Time.deltaTime);
            if (griffinBall2.transform.position == positions[goToPositionBall2].position)
            {
                ball2Position = goToPositionBall2;
                ball2Cs.Attack(Random.Range(1, 3));
                ball2Cs.canMove = false;
            }
        } 
    }

    int RandomPositions(bool up)
    {
        int randomposition;
        List<int> availablepositions = new List<int>();

        if (up)
        {
            for (int i = 0; i < 4; i++)
            {
                if (ball1Position != i && ball2Position != i)
                {
                    availablepositions.Add(i);
                }
            }
        }
        else
        {
            for (int i = 4; i < 8; i++)
            {
                if (ball1Position != i && ball2Position != i)
                {
                    availablepositions.Add(i);
                }
            }
        }


        randomposition = availablepositions[Random.Range(0, availablepositions.Count)];
        return randomposition;
    }
}
