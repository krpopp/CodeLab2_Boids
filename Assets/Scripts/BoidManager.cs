using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{

	public GameObject boidprefab;
	public List<Boidhavior> boidlist = new List<Boidhavior>();
	public int numOfBoids;

	public float boidSeparationDistance = 1f;

	[Range(0, 2f)] public float weightAlignment;
	[Range(0, 2f)] public float weightCohseion;
	[Range(0, 2f)] public float weightSeperation;
	[Range(0, 2f)] public float weightTarget;

    // Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < numOfBoids; i++) {
			CreateBoid();
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void CreateBoid() {
		GameObject newboid = Instantiate(boidprefab, this.transform.position, Quaternion.identity);
		newboid.transform.parent = this.transform;

		Boidhavior newboidbehav = newboid.GetComponent<Boidhavior>();
		newboidbehav.boidmanager = this;

		boidlist.Add(newboidbehav);
	}


}
