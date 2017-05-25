using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamController : MonoBehaviour
{
    [SerializeField]
    float explosionSize;
    [SerializeField]
    float laserSpeed;
    [SerializeField]
    string enemyTag;
    [SerializeField]
    Rigidbody2D laserBody;
    [SerializeField]
    ObjectPool parentObjectPool;
    Camera mainCam;
    Transform laserTransform;


    public void SetFireDirection(Quaternion fireRotation)
    {
        laserTransform.rotation = fireRotation;
    }

    private void Awake()
    {
        mainCam = Camera.main;
        laserTransform = gameObject.transform;
    }

    private void Start()
	{
        parentObjectPool = GetComponentsInParent<ObjectPool>()[0];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == enemyTag)
        {
            collision.gameObject.GetComponent<MeteorController>().DealDamage(1);

            //MakeExplosion();
            parentObjectPool.ReturnObjectToPool(gameObject);
        }
    }

    void MakeExplosion()
    {
        var colliders = Physics2D.OverlapCircleAll(laserTransform.position, explosionSize);
        foreach (var tCollider in colliders)
        {
            if (tCollider.gameObject.tag == enemyTag)
            {
                var targetRBody = tCollider.GetComponent<Rigidbody2D>();
                targetRBody.AddRelativeForce(laserTransform.position * 5f, ForceMode2D.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        laserBody.velocity = laserTransform.up * laserSpeed;
    }

    private void Update()
    {
        Vector2 viewportPos = mainCam.WorldToViewportPoint(laserTransform.position);
        if (viewportPos.x > 1 || viewportPos.x < 0 || viewportPos.y < 0 || viewportPos.y > 1)
            parentObjectPool.ReturnObjectToPool(gameObject);
    }
}
