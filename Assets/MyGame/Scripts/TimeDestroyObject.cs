using UnityEngine;
[AddComponentMenu("DangSon/TimeDestroyObject")]
public class TimeDestroyObject : MonoBehaviour
{
    public float timeToDestroy = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
