using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public Transform Target;

    public float Distance;
    public float lookatDistance = 15.0f;
    public float MoveSpeed = 5.0f;
    public float ContinueMoveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(Target.transform.position, transform.position);

        if(Distance> lookatDistance)
        {
            MoveSpeed = 0;
        }

        if(Distance<lookatDistance)
        {
            MoveSpeed = ContinueMoveSpeed;

            transform.LookAt(Target);
            Vector3 Movement = Target.transform.position - transform.position;
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
    }
}
