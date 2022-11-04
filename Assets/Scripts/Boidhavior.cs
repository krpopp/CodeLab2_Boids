using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boidhavior : MonoBehaviour
{
        public BoidManager boidmanager;
        
        Vector3 velocity;
        public float speed;
        
    // Start is called before the first frame update
        void Start()
        {
            velocity = new Vector3(Random.value, Random.value, Random.value);
        }

        // Update is called once per frame
        void Update()
        {
            
        }



	}
