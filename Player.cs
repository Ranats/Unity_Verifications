using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class X{ public static float max, min; }
static class Z{ public static float max, min; }

public class Player : MonoBehaviour {
    public Transform plane;
    [Range(0f, 1f)]
    public float speed;
    
　　void Start () {
        X.min = -(10 * plane.localScale.x / 2) + this.transform.localScale.x / 2;
        X.max = (10 * plane.localScale.x / 2) - this.transform.localScale.x / 2;
        Z.min = -(10 * plane.localScale.z / 2) + this.transform.localScale.z / 2;
        Z.max = (10 * plane.localScale.z / 2) - this.transform.localScale.z / 2;
    }
    
    void Update () {
        Vector3 unit = transform.position;
        unit.x += Input.GetAxis("Horizontal") * speed;
        unit.z += Input.GetAxis("Vertical") * speed;
        transform.position = Clamp(unit);
　　}

    Vector3 Clamp(Vector3 vec){
        return new Vector3(Mathf.Clamp(vec.x,X.min,X.max),vec.y, Mathf.Clamp(vec.z, Z.min, Z.max));
    }
}
