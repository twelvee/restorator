using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour {
	private int sizeLeft;
	private int sizeRight;
	private int sizeBlock;
	public static Dictionary<string, GameObject> floor = new Dictionary<string, GameObject> ();
	public static Dictionary<string, GameObject> walls = new Dictionary<string, GameObject>();

	public void createGrid(int sl, int sz, int sb){
		sizeLeft = sl;
		sizeRight = sz;
		sizeBlock = sb;
	}

	public static GridController Instance;
	void Awake(){
		Instance = this;
	}
		
	public void spawnFloor(GameObject Texture){
		int tempAr = 0;
		for (int i = 0; i < sizeLeft; i++) {
			for (int j = 0; j < sizeRight; j++) {
				Vector3 position = new Vector3 (j*10, 0, i*10);
				GameObject clone = (GameObject)Instantiate(Texture,
					position,
					Quaternion.identity);
				floor.Add(tempAr.ToString(), null);
				clone.name = "floor_" + tempAr;
				tempAr++;
			}
		}
	}

	public void spawnWalls(GameObject Texture){
		int wallTempAr = 0;
		for(int i=0;i<sizeLeft;i++){
			Vector3 position = new Vector3 (sizeRight*10-5, 10, i*10);
			GameObject clone = (GameObject)Instantiate(Texture,
				position,
				Quaternion.identity);
			clone.name = "wall_" + wallTempAr;
			walls.Add (wallTempAr.ToString(), null);
			wallTempAr++;
		}
		for(int i=0;i<sizeRight;i++){
			Vector3 position = new Vector3 (i*10, 10, sizeLeft*10-5);
			GameObject clone = (GameObject)Instantiate(Texture,
				position,
				Quaternion.identity);
			clone.transform.Rotate (0,90,0);
			clone.name = "wall_" + wallTempAr;
			walls.Add (wallTempAr.ToString(), null);
			wallTempAr++;
		}
	}

	public static Vector3 getFloorGridPosition(string grid){
		GameObject temp = GameObject.Find ("floor_"+grid);
		if (temp != null) {
			return temp.transform.position;
		}else{
			return new Vector3 (1212,1212,1212);
		}
	}

	public static Vector3 getWallGridPosition(string grid){
		GameObject temp = GameObject.Find ("wall_"+grid);
		if (temp != null) {
			Vector3 position = temp.transform.position;
			return position;
		}else{
			return new Vector3 (1212,1212,1212);
		}
	}
}
