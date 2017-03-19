using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {


    public float moveSpeed = 3f;
    public GameObject player;
    public GameObject enemy;
    public float randomPower = 2.5f;
    public float changeDirectInterval = 0.75f;
    public float randomRate = 0.8f;


    private Rigidbody rigidBody;
    private Vector3 direct;
    private EnemyController enemyController;
    private float changeDirectCounter;





    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidBody = GetComponent<Rigidbody>();
        enemyController = GetComponent<EnemyController>();


        Vector3 targetVector3 = player.transform.position - enemy.transform.position;
        targetVector3 = moveSpeed * Vector3.Normalize(targetVector3);
        Debug.Log(targetVector3);

    }


    void Update () {
        changeDirectCounter += Time.deltaTime;

        ChangeMoveDirection();

        ChangeFaceDirection();
    }

    void ChangeMoveDirection()
    {
        Random ran = new Random();
        Vector3 randomVector3 = new Vector3(0, 0, 0);

        if (changeDirectCounter > changeDirectInterval)
        {

            if (Random.Range(0,1.0f) < randomRate)
            {
                changeDirectCounter = 0;
                randomVector3 = new Vector3(Random.Range(-6, 6), 0, Random.Range(-6, 6));
                randomVector3 = randomPower * Vector3.Normalize(randomVector3);
            }
            else
            {
                randomVector3 = new Vector3(0, 0, 0);
            }
            

            Vector3 targetVector3 = player.transform.position - enemy.transform.position;
            targetVector3 = moveSpeed * Vector3.Normalize(targetVector3);


            direct = Vector3.Normalize(randomVector3 + targetVector3);

            rigidBody.velocity = direct * moveSpeed;
            Debug.Log(rigidBody.velocity);

        }
    }

    void ChangeFaceDirection()
    {
        if ((player.transform.position - enemy.transform.position).x > 0)
        {
            enemy.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            enemy.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

}
