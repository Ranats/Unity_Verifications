using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_ray : MonoBehaviour {

    public float theta = 0;
    public float radius = 10;
    public GameObject hit_effect;

    LineRenderer renderer;
    Vector3 position;

    void Start()
    {
        position = this.transform.position;

        renderer = gameObject.GetComponent<LineRenderer>();
        renderer.SetWidth(0.2f, 0.2f);
        renderer.SetPosition(0, position);
    }

    void FixedUpdate()
    {
        renderer.SetPosition(1, position + GetPosition(theta, radius, 0));
        Ray();
        theta += 1;
    }

    void Ray()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, GetPosition(theta, radius));
        if (hit.collider != null)
        {
            Vector3 point = new Vector3(hit.point.x, hit.point.y, 0);
            Instantiate(hit_effect, point, transform.rotation);
        }
    }

    Vector2 GetPosition(float angle, float radius)
    {
        float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        float y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
        return new Vector2(x, y);
    }

    Vector3 GetPosition(float angle, float radius, int z)
    {
        Vector2 xy = GetPosition(angle, radius);
        return new Vector3(xy.x, xy.y, z);
    }
}
