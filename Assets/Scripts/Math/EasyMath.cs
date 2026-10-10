using UnityEngine;

public class EasyMath
{
    public static float ConvertValue(float a, float b, float value)
    {
        return a + (b - a) * value;
    }

    public static float PointDirectionRad(Vector3 a, Vector3 b)
    {
        Vector3 direction = b - a;
        return Mathf.Atan2(direction.y, direction.x);
    }

    public static float PointDirectionDeg(Vector3 a, Vector3 b)
    {
        return PointDirectionRad(a, b) * Mathf.Rad2Deg;
    }

    public static Quaternion PointDirection(Vector3 a, Vector3 b)
    {
        float angle = PointDirectionDeg(a, b);
        return Quaternion.Euler(0, 0, angle);
    }

    public static Vector2 LinearVelocity(float velocity, float angle)
    {
        return new Vector2(velocity * Mathf.Cos(angle * Mathf.Deg2Rad), velocity * Mathf.Sin(angle * Mathf.Deg2Rad));
    }

    public static Vector2 PolarToCartesian(float radius, float angle)
    {
        return new Vector2(radius * Mathf.Cos(angle * Mathf.Deg2Rad), radius * Mathf.Sin(angle * Mathf.Deg2Rad));
    }

    public static Vector3 PolarToCartesian(float radius, float angle, float z)
    {
        return new Vector3(radius * Mathf.Cos(angle * Mathf.Deg2Rad), radius * Mathf.Sin(angle * Mathf.Deg2Rad), z);
    }

    public static void ChangeCollisionSpriteSize(ref SpriteRenderer spriteRenderer, ref BoxCollider2D boxCollider2D, Vector2 step)
    {
        spriteRenderer.size = new Vector2(spriteRenderer.size.x + step.x, spriteRenderer.size.y + step.y * Time.deltaTime);
        boxCollider2D.size = new Vector2(boxCollider2D.size.x + step.x, boxCollider2D.size.y + step.y * Time.deltaTime);
        boxCollider2D.offset = new Vector2(boxCollider2D.offset.x - step.x / 2, boxCollider2D.offset.y - step.y / 2 * Time.deltaTime);
    }

    public static bool PointIsInsideRectangle(Vector2 point, Vector2 rectanglePoint1, Vector2 rectanglePoint2)
    {
        Vector2 minRectanglePoint = new Vector2(
            rectanglePoint1.x < rectanglePoint2.x ? rectanglePoint1.x : rectanglePoint2.x,
            rectanglePoint1.y < rectanglePoint2.y ? rectanglePoint1.y : rectanglePoint2.y
        );
        Vector2 maxRectanglePoint = new Vector2(
            rectanglePoint1.x > rectanglePoint2.x ? rectanglePoint1.x : rectanglePoint2.x,
            rectanglePoint1.y > rectanglePoint2.y ? rectanglePoint1.y : rectanglePoint2.y
        );
        return point.x >= minRectanglePoint.x && point.y >= minRectanglePoint.y && point.x <= maxRectanglePoint.x && point.y <= maxRectanglePoint.y;
    }
}
