﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {

	public GameObject floorTexture;
	public GameObject wallTexture;
	public LayerMask floorLayer;

	public int sizeLeft;
	public int sizeRight;
	public int sizeBlock;
	public static bool allowFloorClick = false;
	private GridController grid;
	public static GameObject curObject = null;
	public static GameObject prevObject = null;
	public static string prevGrid = "";
	// Use this for initialization
	void Start () {
		grid = new GridController ();
		grid.createGrid (sizeLeft,sizeRight,sizeBlock);
		grid.spawnFloor (floorTexture);
		grid.spawnWalls (wallTexture);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if(prevObject!=null)
					prevObject.GetComponent<Renderer> ().material.color = Color.white;
				if (hit.collider.gameObject.name.StartsWith ("floor_")) {
					string key = hit.collider.gameObject.name.Replace ("floor_", "");
					curObject = GridController.floor[key];
					prevGrid = key;
					Debug.Log (key);
					if(curObject==null)
						hit.collider.gameObject.GetComponent<Renderer> ().material.color = Color.green;
					else
						hit.collider.gameObject.GetComponent<Renderer> ().material.color = Color.red;
				}
				if (hit.collider.gameObject.name.StartsWith ("wall_")) {
					string key = hit.collider.gameObject.name.Replace ("wall_", "");
					curObject = GridController.walls[key];
					prevGrid = key;
				}
				prevObject = hit.collider.gameObject;

			}
		}
	}
}
