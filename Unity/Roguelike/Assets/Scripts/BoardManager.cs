﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	[Serializable]
	public class Count
	{
		public int minimum;
		public int maximum;

		public Count(int min, int max) {
			minimum = min;
			maximum = max;
		}
	}

	public int columns = 8;
	public int rows = 8;
	public Count wallCount = new Count(5, 9);
	public Count foodCount = new Count(1, 5);
	public GameObject exit;
	public GameObject[] floorTiles;
	public GameObject[] wallTiles;
	public GameObject[] foodTiles;
	public GameObject[] enemyTiles;
	public GameObject[] outerWallTiles;

	private Transform boardHolder; // for organization
	private List<Vector3> gridPositions = new List<Vector3>(); // possible positions in gameboard

	void InitialiseList() {
		Debug.Log ("Initializing Grid Postions");
		gridPositions.Clear ();

		// gap at start and end to gaurantee path to exit
		for (int x = 1; x < columns - 1; x++) {
			for (int y = 1; y < rows - 1; y++) {
				
				gridPositions.Add (new Vector3 (x, y, 0f));
			}
		}
	}

	void BoardSetup ()
	{
		boardHolder = new GameObject ("Board").transform; // transform is the x,y,z values in Inspector

		for (int x = -1; x < columns + 1; x++) {
			for (int y = -1; y < rows+1; y++) {
				GameObject toInstatiate = floorTiles [Random.Range (0, floorTiles.Length)];
				if(x == -1 || x == columns || y == -1 || y == rows) {
					toInstatiate = outerWallTiles [Random.Range (0, outerWallTiles.Length)];
				}
				GameObject instance = Instantiate (toInstatiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);
			}
		}

	}

	Vector3 RandomPosition() {
		int randomIndex = Random.Range (0, gridPositions.Count);
		Vector3 randomPosition = gridPositions [randomIndex];
		gridPositions.RemoveAt (randomIndex);
		return randomPosition;
	}

	void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
	{
		Debug.Log ("Laying out: " + tileArray [0].tag);
		int objectCount = Random.Range (minimum, maximum + 1);
		for (int i = 0; i < objectCount; i++) {
			Vector3 randomPostion = RandomPosition ();
			GameObject tileChoice = tileArray [Random.Range (0, tileArray.Length)];
			Instantiate (tileChoice, randomPostion, Quaternion.identity);
		}
	}

	public void SetupScene(int level) { // called by game manager
		BoardSetup();
		InitialiseList ();
		LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);
		LayoutObjectAtRandom (foodTiles, foodCount.minimum, foodCount.maximum);
		int enemyCount = (int)Mathf.Log (level, 2f);
		LayoutObjectAtRandom (enemyTiles, enemyCount, enemyCount);
		Instantiate (exit, new Vector3 (columns - 1, rows - 1, 0f), Quaternion.identity);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
