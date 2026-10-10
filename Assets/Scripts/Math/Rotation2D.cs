using UnityEngine;

public static class Rotation2D
{
    public static Quaternion Right = Quaternion.Euler(0, 0, 0);
    public static Quaternion Up = Quaternion.Euler(0, 0, 90f);
    public static Quaternion Left = Quaternion.Euler(0, 0, 180f);
    public static Quaternion Down = Quaternion.Euler(0, 0, 270f);

    public static Quaternion GetQuaternion(float rotation)
    {
        return Quaternion.Euler(Vector3.forward * rotation);
    }
}