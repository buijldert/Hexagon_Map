using UnityEngine;

public static class HexMetrics
{
    //define outer radius
    public const float outerRadius = 10f;

    //define inner radius
    public const float innerRadius = outerRadius * 0.866025404f;

    //define corners
    public static Vector3[] corners = 
    {
        new Vector3(0f, 0f, outerRadius),
        new Vector3(innerRadius, 0f, 0.5f * outerRadius),
        new Vector3(innerRadius, 0f, -0.5f * outerRadius),
        new Vector3(0f, 0f, -outerRadius),
        new Vector3(-innerRadius, 0f, -0.5f * outerRadius),
        new Vector3(-innerRadius, 0f, 0.5f * outerRadius),
        new Vector3(0f, 0f, outerRadius)
    };
}
