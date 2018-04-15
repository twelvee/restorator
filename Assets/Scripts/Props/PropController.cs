using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropController : MonoBehaviour {

	public static void create(GameObject item, string grid, Vector3 rotate, float y){
		
		Vector3 position = GridController.getFloorGridPosition (grid.ToString());
		position.y = y;
		GameObject putObject = (GameObject)Instantiate(item,
			position,
			Quaternion.identity);
		putObject.transform.Rotate (rotate);
		GridController.floor.Remove (grid.ToString());
		GridController.floor.Add (grid.ToString(), putObject);
	}

	public static void createOnWall(GameObject item, string grid, Vector3 rotate, float y=0,float z=0,float x=0){
		//GridController gridController = new GridController ();
		Vector3 position = GridController.getWallGridPosition (grid.ToString());
		if (z != 0)
			position.z = position.z + z;
		if (y != 0)
			position.y = position.y + y;
		if (x != 0)
			position.x = position.x + x;

		GameObject putObject = (GameObject)Instantiate(item,
			position,
			Quaternion.identity);
		putObject.transform.Rotate (rotate);
		GridController.walls.Remove (grid.ToString());
		GridController.walls.Add (grid.ToString(), putObject);
		Debug.Log (grid);
	}
}
