using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class HexagonGrid : MonoBehaviour
{
    //list to store the hexagon coordinates labels
    private List<Text> _hexagonCoordinatesLabelList = new List<Text>();
    //list to store hexagon cells in
    private List<GameObject> _hexagonCellList = new List<GameObject>();

    //prefab of hexagon coordinates text
    [SerializeField]private Text _hexagonCoordinatesLabel;
    //prefab of a hexagon cell
    [SerializeField]private GameObject _hexagonCell;
    //canvas for hexagon coordianates labels
    private Canvas _hexagonCoordinatesCanvas;

    //set the size of the cells in the editor
    [SerializeField]private float _hexagonCellSize;
    //set the width of the grid in the editor
	[SerializeField]private int _gridWidth;
    //set the height of the grid in the editor
	[SerializeField]private int _gridHeight;
	
    //variable to store an instance of the HexagonMetrics class
    private HexagonMetrics _hexagonMetrics;
    //variable to store the position of the grid
	private Vector3 _gridPosition;
    //variable to store the size of the grid
    public static float Size;

    void Awake()
    {
        _hexagonCoordinatesCanvas = GetComponentInChildren<Canvas>();
        SpawnGrid();
    }

    //create the grid
    private void SpawnGrid()
    {
        ClearGrid();
        for (int x = 0, i = 0; x < _gridWidth; x++)
        {
            for (int z = 0; z < _gridHeight; z++)
            {
                GameObject newHexagonCell = Instantiate(_hexagonCell, Vector3.zero, Quaternion.identity) as GameObject;
                _hexagonCellList.Add(newHexagonCell);
                _hexagonMetrics = newHexagonCell.GetComponent<HexagonMetrics>();
                _gridPosition = new Vector3((x + z * 0.5f - z / 2) * _hexagonMetrics.CellWidth - _gridWidth / 2, 0, z * _hexagonMetrics.CellHeight * 0.75f - _gridHeight / 2);
                newHexagonCell.transform.position = _gridPosition;
                _hexagonMetrics.CreateHexagon(_gridPosition);
                ShowCoordinates(x, z, i++, newHexagonCell);
            }
        }
    }

    //show the coordinates of the hexagons on themselves
    private void ShowCoordinates(int x, int z, int i, GameObject parentCell)
    {
        Text label = Instantiate<Text>(_hexagonCoordinatesLabel);
        _hexagonCoordinatesLabelList.Add(label);
        label.rectTransform.SetParent(_hexagonCoordinatesCanvas.transform, false);
        label.transform.position = new Vector3(parentCell.transform.localPosition.x,0.1f,parentCell.transform.localPosition.z);
        label.text = x.ToString() + "\n" + z.ToString();
    }

    //clear the grid
    private void ClearGrid()
    {
        for (int i = 0; i < _hexagonCellList.Count; i++)
        {
            Destroy(_hexagonCellList[i].gameObject);
        }

        for (int i = 0; i < _hexagonCoordinatesLabelList.Count; i++)
        {
            Destroy(_hexagonCoordinatesLabelList[i].gameObject);
        }
        _hexagonCellList.Clear();
        _hexagonCoordinatesLabelList.Clear();
    }
    
    //store the size of the hexagon cells
    public void ChangeHexSize()
    {
        Size = _hexagonCellSize;
    }
}