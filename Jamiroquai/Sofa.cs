using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Direction
{
    static public Vector3 forward = new Vector3(1, 0, 0);
    static public Vector3 back = new Vector3(-1, 0, 0);
    static public Vector3 left = new Vector3(0, 0, 1);
    static public Vector3 right = new Vector3(0, 0, -1);
}

public class Sofa : MonoBehaviour
{
    public GameObject marker;
    Material mat;

    void Start()
    {
        mat = marker.GetComponent<Renderer>().material;
        Color color = mat.color;
        color.a = 0;
        mat.color = color;

        StartCoroutine(Move(Direction.back,30f));
    }

    void Update()
    {
    }

    IEnumerator Move(Vector3 direction,float frame)
    {
        this.transform.forward = direction;
        
        //  marker blink
        int flg = 1;
        while (flg < 5)
        {
            flg = Blink(mat,flg);
            yield return new WaitForSeconds(.1f);
        }
        marker.SetActive(false);

        //  actualy moving
        float time = 0;
        while (time < frame)
        {
            time += 0.1f;
            this.transform.Translate(this.transform.forward * 0.01f);
            yield return null;
        }
    }

    int Blink(Material mat, int flg)
    {
        Color color = mat.color;
        color.a += (flg % 2 == 0) ?  -0.1f : 0.1f;
        mat.color = color;
        if (color.a <= 0 || color.a >= 1) { return flg+1; }
        return flg;
    }
}