using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGen : MonoBehaviour {

	// Use this for initialization
	public GameObject RoadGrassUnit;
	public Rigidbody human;
	public GameObject treeA;
	public GameObject treeB;
	public GameObject roadblock;
	int firstRand;
	int secondRand;
	int x;

	Vector3 intPos= new Vector3(0,0,0);
	Vector3 treeAPos=new Vector3(0,0,0);
	Vector3 treeBPos=new Vector3(0,0,0);
	Vector3 roadblockPos=new Vector3(0,0,0);


		
		void OnTriggerEnter(Collider Col)
	{
		
		if (Col.tag == "Player") {
			
			//terrain generation
			intPos = new Vector3 (52, -4, transform.position.z + 90);

			GameObject RoadGrassUnitIns = Instantiate (RoadGrassUnit) as GameObject;
			RoadGrassUnitIns.transform.position = intPos;
			if (transform.position.z < 1660) {
				//tree generation
				treeAPos = new Vector3 (40, -4, (transform.position.z + 80));
				GameObject treeAIns = Instantiate (treeA);
				treeAIns.transform.position = treeAPos;

				treeAPos = new Vector3 (40, -4, (transform.position.z + 85));
				GameObject treeCIns = Instantiate (treeA);
				treeCIns.transform.position = treeAPos;

				treeBPos = new Vector3 (-42, -4, (transform.position.z + 95));
				GameObject treeBIns = Instantiate (treeB);
				treeBIns.transform.position = treeBPos;

				treeBPos = new Vector3 (-42, -4, (transform.position.z + 100));
				GameObject treeDIns = Instantiate (treeB);
				treeDIns.transform.position = treeBPos;
		
				treeAPos = new Vector3 (-42, -4, (transform.position.z + 80));
				GameObject treeEIns = Instantiate (treeA);
				treeEIns.transform.position = treeAPos;

				treeAPos = new Vector3 (-42, -4, (transform.position.z + 85));
				GameObject treeFIns = Instantiate (treeA);
				treeFIns.transform.position = treeAPos;

				treeBPos = new Vector3 (40, -4, (transform.position.z + 95));
				GameObject treeGIns = Instantiate (treeB);
				treeGIns.transform.position = treeBPos;


				treeBPos = new Vector3 (40, -4, (transform.position.z + 100));
				GameObject treeHIns = Instantiate (treeB);
				treeHIns.transform.position = treeBPos;

				//Roadblock generation
		
				for (x = 10; x <= 29; x += 10) {
					firstRand = Random.Range (1, 7);
					if (firstRand == 1) {
						roadblockPos = new Vector3 (30, -3, (transform.position.z + 60 + x));
						GameObject roadblockIns = Instantiate (roadblock);
						roadblock.transform.position = roadblockPos;
						roadblock.transform.eulerAngles = new Vector3 (-90, 0, -90);
					}

					if (firstRand == 2) {
						roadblockPos = new Vector3 (20, -3, (transform.position.z + 60 + x));
						GameObject roadblockIns = Instantiate (roadblock);
						roadblock.transform.position = roadblockPos;
						roadblock.transform.eulerAngles = new Vector3 (-90, 0, -90);
					}

					if (firstRand == 3) {
						roadblockPos = new Vector3 (4, -3, (transform.position.z + 60 + x));
						GameObject roadblockIns = Instantiate (roadblock);
						roadblock.transform.position = roadblockPos;
						roadblock.transform.eulerAngles = new Vector3 (-90, 0, -90);
					}

					if (firstRand == 4) {
						roadblockPos = new Vector3 (-6, -3, (transform.position.z + 60 + x));
						GameObject roadblockIns = Instantiate (roadblock);
						roadblock.transform.position = roadblockPos;
						roadblock.transform.eulerAngles = new Vector3 (-90, 0, -90);
					}

					if (firstRand == 5) {
						roadblockPos = new Vector3 (-22, -3, (transform.position.z + 60 + x));
						GameObject roadblockIns = Instantiate (roadblock);
						roadblock.transform.position = roadblockPos;
						roadblock.transform.eulerAngles = new Vector3 (-90, 0, -90);
					}

					if (firstRand == 6) {
						roadblockPos = new Vector3 (-33, -3, (transform.position.z + 60 + x));
						GameObject roadblockIns = Instantiate (roadblock);
						roadblock.transform.position = roadblockPos;
						roadblock.transform.eulerAngles = new Vector3 (-90, 0, -90);
					}
				}

				//Human Generation
				secondRand = Random.Range (1, 3);
				if (secondRand == 1)
					intPos = new Vector3 (-100, -3, transform.position.z + 83);
				if (secondRand == 2)
					intPos = new Vector3 (100, -3, transform.position.z + 83);

				Rigidbody humanaIns = Instantiate (human) as Rigidbody;
				humanaIns.transform.position = intPos;

				secondRand = Random.Range (1, 3);
				if (secondRand == 1)
					intPos = new Vector3 (-100, -3, transform.position.z + 103);
				if (secondRand == 2)
					intPos = new Vector3 (100, -3, transform.position.z + 103);

				Rigidbody humanbIns = Instantiate (human) as Rigidbody;
				humanbIns.transform.position = intPos;
			}
		}
	}

				
}
