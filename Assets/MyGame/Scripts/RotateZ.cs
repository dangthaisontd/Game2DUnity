using UnityEngine;
[AddComponentMenu("DangSon/RotateZ")]
public class RotateZ : MonoBehaviour
{
    public float speed = 90f; 
    public bool useLocalSpace = true; 
    void Update()
    {
        float delta = speed * Time.deltaTime;
        if (useLocalSpace)
        {
            transform.Rotate(0f, 0f, delta, Space.Self);
        }
        else
        {
            transform.Rotate(0f, 0f, delta, Space.World);
        }
    }
}
