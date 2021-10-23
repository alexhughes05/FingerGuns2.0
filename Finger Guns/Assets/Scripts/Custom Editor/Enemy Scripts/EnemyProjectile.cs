using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    #region Variables
    //Inspector
    [SerializeField] 
    private float speed;

    //Private
    private Transform player;
    private Vector2 target;
    private FgmInputHandler fingerGunMan;
    #endregion

    #region Monobehaviour Callbacks

    private void Awake()
    {
        fingerGunMan = FindObjectOfType<FgmInputHandler>();
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y + 1);

        //Point towards target position
        Vector3 relativePos = player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        rotation.x = transform.rotation.x;
        rotation.y = transform.rotation.y;
        transform.rotation = rotation;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
