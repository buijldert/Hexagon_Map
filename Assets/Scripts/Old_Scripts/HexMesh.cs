using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexMesh : MonoBehaviour
{
    //define instance of HexMesh
    private Mesh _hexMesh;
    //define list for hexagon vertices
    private List<Vector3> _vertices;
    //define list for triangles in hexagon
    private List<int> _triangles;

    //set HexMesh/vertices/tringles and HexMesh name
    void Awake()
    {
        GetComponent<MeshFilter>().mesh = _hexMesh = new Mesh();
        _hexMesh.name = "Hex Mesh";
        _vertices = new List<Vector3>();
        _triangles = new List<int>();
    }

    //triangulate hexcell array
    public void Triangulate(HexCell[] cells)
    {
        _hexMesh.Clear();
        _vertices.Clear();
        _triangles.Clear();
        for (int i = 0; i < cells.Length; i++)
        {
            Triangulate(cells[i]);
        }
        _hexMesh.vertices = _vertices.ToArray();
        _hexMesh.triangles = _triangles.ToArray();
        _hexMesh.RecalculateNormals();
    }

    //triangulate hexcells
    void Triangulate(HexCell cell)
    {
        Vector3 center = cell.transform.localPosition;
        for (int i = 0; i < 6; i++)
        {
            AddTriangle(
                center,
                center + HexMetrics.corners[i],
                center + HexMetrics.corners[i + 1]
            );
        }
    }

    //add triangles to hexagon
    void AddTriangle(Vector3 v1, Vector3 v2, Vector3 v3)
    {
        int vertexIndex = _vertices.Count;
        _vertices.Add(v1);
        _vertices.Add(v2);
        _vertices.Add(v3);
        _triangles.Add(vertexIndex);
        _triangles.Add(vertexIndex + 1);
        _triangles.Add(vertexIndex + 2);
    }
}