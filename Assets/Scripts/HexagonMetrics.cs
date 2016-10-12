using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HexagonMetrics : MonoBehaviour {

    //the number of degrees in a corner of a hexagon
	private float _cornerDegrees = 60;
    //the number of degrees in a full circle
	private float _maxDegrees = 360; //Degrees of a full circle
    //gets the size of the hexagongrid
    private float _hexSize = HexagonGrid.Size;
    //store the corners in a list
	public List<Vector3> Corners;

    //calculate the hexagoncell height
	public float CellHeight 
    {
		get { return _hexSize * 2;}
	}

    //calculate the hexagoncell width
	public float CellWidth 
    {
		get { return ( Mathf.Sqrt (3) / 2) * CellHeight;}
	}

    //create the corners of the hexagon and add them to the list
	public void CreateHexagon (Vector3 center) {
		Corners.Add (center);
		for (int i = 0; i < _maxDegrees / _cornerDegrees; i++) {
			float x = center.x + _hexSize * Mathf.Sin ((_cornerDegrees * i) * Mathf.Deg2Rad);
			float z = center.z + _hexSize * Mathf.Cos ((_cornerDegrees * i) * Mathf.Deg2Rad);
			Vector3 newCorner = new Vector3 (x, 0, z);
			Corners.Add (newCorner);
		}
	}
}