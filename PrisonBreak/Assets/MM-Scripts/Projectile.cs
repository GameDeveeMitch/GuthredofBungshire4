using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool set = false;
    private Vector3 firePos;
    private Vector3 direction;
    private float speed;
    private float timeElapsed;
    // Start is called before the first frame update
    void Start()
    {
        Set(this.transform.position, 50);
    }

    // Update is called once per frame
    void Update()
    {
        if (!set)
            return;
        timeElapsed += Time.deltaTime;
        transform.position = firePos + direction * speed * timeElapsed;
        transform.position += Physics.gravity * (timeElapsed * timeElapsed) / 2;
        
    }
    public void Set(Vector3 fp, float s)
    {
        firePos = fp;
        direction = GetFireDirection(firePos, GameObject.FindGameObjectWithTag("Player").transform.position, s);
        speed = s;
        transform.position = firePos;
        set = true;
    }
    public  static Vector3 GetFireDirection(Vector3 startPos, Vector3 endPos, float s)
    {
        Vector3 dir = Vector3.zero;
        Vector3 delta = endPos - startPos;
        float a = Vector3.Dot(Physics.gravity, Physics.gravity);
        float b = -4 * (Vector3.Dot(Physics.gravity, delta) + s * s);
        float c = 4 * Vector3.Dot(delta, delta);
        if (4 * a * c > b * b)
            return dir;
        float time0 = Mathf.Sqrt((-b + Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a));
        float time1 = Mathf.Sqrt((-b - Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a));
        float time; 
        if(time0 < 0.0f)
        {
            if (time1 < 0)
                return dir;
            time = time1;
        }
        else
        {
            if (time1 < 0)
                time = time0;
            else
                time = Mathf.Min(time0, time1);
        }
        dir = 2 * delta - Physics.gravity * (time * time);
        dir = dir / (2 * s * time);
        return dir;
    }
}
