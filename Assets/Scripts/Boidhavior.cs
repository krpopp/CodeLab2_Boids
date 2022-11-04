using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boidhavior : MonoBehaviour
{
    public BoidManager boidmanager;

    Vector3 velocity;
    public float speed;

    //Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(Random.value, Random.value, Random.value);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;

        Vector3 cohesion = boidmanager.transform.position;
        Vector3 alignment = Vector3.zero;
        Vector3 seperation = Vector3.zero;
        Vector3 targetSeek = boidmanager.transform.position - transform.position;

        foreach (Boidhavior boidie in boidmanager.boidlist)
        {
            if (boidie == this) continue;
            cohesion += boidie.transform.position;
            alignment += boidie.velocity;

            Vector3 directionDiff = transform.position - boidie.transform.position;
            if(directionDiff.magnitude > 0 && directionDiff.magnitude < boidmanager.boidSeparationDistance)
            {
                seperation += boidmanager.boidSeparationDistance * (directionDiff.normalized / directionDiff.magnitude);
            } else if(directionDiff.magnitude > 0 && directionDiff.magnitude > boidmanager.boidSeparationDistance)
            {
                seperation -= boidmanager.boidSeparationDistance * (directionDiff.normalized / directionDiff.magnitude);
            }
        }

        alignment /= (boidmanager.numOfBoids - 1);
        cohesion /= (boidmanager.numOfBoids - 1);
        cohesion = (cohesion - transform.position).normalized;
        seperation /= (boidmanager.numOfBoids - 1);

        Vector3 newVel = Vector3.zero;

        newVel += alignment * boidmanager.weightAlignment;
        newVel += cohesion * boidmanager.weightCohseion;
        newVel += seperation * boidmanager.weightSeperation;
        newVel += targetSeek * boidmanager.weightTarget;
        newVel.Normalize();

        velocity = Util.Limit((velocity + newVel), 1.5f);

        transform.up = velocity.normalized;
        transform.position = currentPosition + velocity * (speed * Time.deltaTime);

    }



}
