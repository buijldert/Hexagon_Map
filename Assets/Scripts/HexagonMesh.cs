using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(HexagonMetrics))]
public class HexagonMesh : MonoBehaviour {
	
    //a list to store the vertices of the hexagon in
    private List<Vector3> _vertices = new List<Vector3>();
    //a list to store the triangles of the hexagon in
	private List<int> _triangles = new List<int>();
    //a variable to store an instance of the hexagonmetrics class in
    private HexagonMetrics _hexagonMetrics;
    //a variable to store the hexagon mesh in
    private Mesh _hexagonMesh;

    //fill variables and start Triangulate(), also set position and clear the hexagonmesh
	private void Start() 
    {
		_hexagonMesh = GetComponent<MeshFilter> ().mesh;
        _hexagonMetrics = GetComponent<HexagonMetrics> ();
		_vertices   = _hexagonMetrics.Corners;
        _hexagonMesh.name = "Hex Mesh";

		Triangulate ();

        _hexagonMesh.Clear();  
        _hexagonMesh.vertices = _vertices.ToArray();
        _hexagonMesh.triangles = _triangles.ToArray();
        _hexagonMesh.RecalculateNormals();
        	
		transform.position  = new Vector3(0, 0, 0);
	}
		
    //fill the hexagon with triangles
	private void Triangulate() 
    {
		for (int i = 0; i < 6; i++) {
			_triangles.Add (0);
			_triangles.Add (i + 1);
			if (i + 2 > 6) 
            {
				_triangles.Add (1);
			} else 
            {
				_triangles.Add (i + 2);
			}
		}
	}
}