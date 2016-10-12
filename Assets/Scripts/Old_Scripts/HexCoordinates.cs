using UnityEngine;

[System.Serializable]
public struct HexCoordinates
{
    //hexagon x position
    public int X { get; private set; }
    //hexagon z position
    public int Z { get; private set; }

    //get coordinates of hexagon
    public HexCoordinates(int x, int z)
    {
        X = x;
        Z = z;
    }

    //return offset coordinates
    public static HexCoordinates FromOffsetCoordinates(int x, int z)
    {
        return new HexCoordinates(x - z / 2, z);
    }

    //hexagon Y position
    public int Y
    {
        get
        {
            return -X - Z;
        }
    }

    //convert x and z coordinates to string
    public override string ToString()
    {
        return "(" + X.ToString() + ", " + Z.ToString() + ")";
    }

    //convert x and z coordinates to string on seperate lines
    public string ToStringOnSeparateLines()
    {
        return X.ToString() + "\n" + Z.ToString();
    }
}