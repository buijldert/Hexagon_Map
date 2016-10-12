using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour
{
    //define width of grid
    [SerializeField]private int _width;
    //define height of grid
    [SerializeField]private int _height;
    //set a prefab for hexagon cells
    [SerializeField]private HexCell _cellPrefab;
    //set a prefab for cell label
    [SerializeField]private Text _cellLabelPrefab;
    //array of hexagon cells
    private HexCell[] _cells;
    //define a canvas instance
    private Canvas _gridCanvas;
    //define a hexagon mesh instance
    private HexMesh _hexMesh;

    //define canvas and mesh. call CreateCell() function
    void Awake()
    {
        _gridCanvas = GetComponentInChildren<Canvas>();
        _hexMesh = GetComponentInChildren<HexMesh>();

        _cells = new HexCell[_height * _width];

        for (int z = 0, i = 0; z < _height; z++)
        {
            for (int x = 0; x < _width; x++)
            {
                CreateCell(x, z, i++);
            }
        }
    }
    //triangulate the cells
    void Start()
    {
        _hexMesh.Triangulate(_cells);
    }
    //create the cells
    void CreateCell(int x, int z, int i)
    {
        Vector3 position;

        position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
        position.y = 0f;
        position.z = z * (HexMetrics.outerRadius * 1.5f);

        HexCell cell = _cells[i] = Instantiate<HexCell>(_cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);

        Text label = Instantiate<Text>(_cellLabelPrefab);
        label.rectTransform.SetParent(_gridCanvas.transform, false);
        label.rectTransform.anchoredPosition =
            new Vector2(position.x, position.z);
        label.text = cell.coordinates.ToStringOnSeparateLines();
    }
}
