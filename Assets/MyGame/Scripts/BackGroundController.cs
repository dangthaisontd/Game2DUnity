using UnityEngine;
using UnityEngine.AI;

public class BackGroundController : MonoBehaviour
{
    [Header("Background Settings")]
    private Renderer[] backGrounds;
    public float speedOne;
    public float speedTwo;
    public float speedThree;
    private Transform target;
    float startPos;
    void Start()
    {
        backGrounds = GetComponentsInChildren<Renderer>();
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("VitualCamera").transform;
        }
        startPos = target.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        var x = target.position.x - startPos;
        if(backGrounds!=null)
        {
            var offset= (x * speedOne) % 1;
            backGrounds[0].material.mainTextureOffset = new Vector2(offset, backGrounds[0].material.mainTextureOffset.y);
            var offset2 = (x * speedTwo) % 1;
            backGrounds[1].material.mainTextureOffset = new Vector2(offset2, backGrounds[1].material.mainTextureOffset.y);
            var offset3 = (x * speedThree) % 1;
            backGrounds[2].material.mainTextureOffset = new Vector2(offset3, backGrounds[2].material.mainTextureOffset.y);
        }
    }
}
