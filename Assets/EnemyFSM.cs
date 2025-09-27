using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    
    public enum EnemyState{GoToBase, AttackBase, ChasePlayer, AttackPlayer}

    public Sight sightSensor;
    public Transform baseTransform;
    public float baseAttackDistance = 1;
    public float playerAttackDistance = 1;

    [SerializeField] private GameObject bulletPrefab;


    public float lastShootTime;
    public float fireRate;

    public EnemyState currentState = EnemyState.GoToBase;
    private NavMeshAgent agent;

    void Awake()
    {
        baseTransform = GameObject.Find("Base").transform;
        agent = GetComponentInParent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (currentState == EnemyState.GoToBase)
        {
            GoToBase();
        }
        else if(currentState == EnemyState.AttackBase){AttackBase();}
        else if(currentState == EnemyState.ChasePlayer){ ChasePlayer();}
        else{AttackPlayer();}
    }

    void GoToBase()
    {
        Debug.Log("going to base state");
        if (sightSensor.detectedObject != null)
        {
            currentState = EnemyState.ChasePlayer;
        }
        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);

        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);

        if (distanceToBase < baseAttackDistance)
        {
            currentState = EnemyState.AttackBase;
        }
    }

    void AttackBase()
    {
        Debug.Log("attacking base");
        agent.isStopped = true;
        LookTo(baseTransform.position);
        Shoot();
    }

    void ChasePlayer()
    {
        agent.isStopped = false;
        Debug.Log("chasing player");
        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        agent.SetDestination(sightSensor.detectedObject.transform.position);
        
        
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);

        if (distanceToPlayer <= playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
        }
    }

    void AttackPlayer()
    {
        Debug.Log("attacking player");
        agent.isStopped = true;
        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        LookTo(sightSensor.detectedObject.transform.position);
        Shoot();
        
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);

        if (distanceToPlayer > playerAttackDistance * 1.1f)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }


    void Shoot()
    {
        var timeSinceLastShoot = Time.time - lastShootTime;
        if (timeSinceLastShoot > fireRate)
        {
            lastShootTime = Time.time;
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }

    void LookTo(Vector3 target)
    {
        Vector3 directionToPosition = Vector3.Normalize(target-transform.parent.position);
        directionToPosition.y = 0;
        transform.parent.forward = directionToPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
    }
}
