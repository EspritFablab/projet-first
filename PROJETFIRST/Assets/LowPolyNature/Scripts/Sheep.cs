using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sheep : MonoBehaviour
{
    public int MoutonkillPoints = 1;

    public GameObject sheep_mesh;

    private NavMeshAgent mAgent;

    private Animator mAnimator;

    public GameObject Player;

    public float EnemyDistanceRun = 4.0f;

    private bool mIsDead = false;

    public GameObject[] ItemsDeadState = null;

    // Use this for initialization
    void Start()
    {
        mAgent = GetComponent<NavMeshAgent>();

        mAnimator = GetComponent<Animator>();
    }

    private bool IsNavMeshMoving
    {
        get
        {
            return mAgent.velocity.magnitude > 0.1f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        InteractableItemBase item = collision.collider.gameObject.GetComponent<InteractableItemBase>();
        if(item != null)
        {
            // Attaque avec une arme
            if(item.ItemType == EItemType.Weapon)
            {
                if(Player.GetComponent<PlayerController>().IsAttacking)
                {
                    mIsDead = true;
                    mAgent.enabled = false;
                    mAnimator.SetTrigger("die");
                    Destroy(GetComponent<Rigidbody>());

                    Invoke("ShowItemsDeadState", 1.2f);
                }
            }
        }
    }

    void ShowItemsDeadState()
    {
        // Activation des items
        foreach(var item in ItemsDeadState)
        {
            item.SetActive(true);
        }

        Destroy(GetComponent<CapsuleCollider>());

        // Désactiver le corps de l'IA
        GameManager.Instance.Player.mouton(MoutonkillPoints);
        Destroy(sheep_mesh);
    }


    // Update is called once per frame
    void Update()
    {
        if (mIsDead)
            return;

        // Fuite si le joueur est est équipé d'une arme
        bool isPlayerArmed = Player.GetComponent<PlayerController>().IsArmed;

        // Optimisation des performances
        float squaredDist = (transform.position - Player.transform.position).sqrMagnitude;
        float EnemyDistanceRunSqrt = EnemyDistanceRun * EnemyDistanceRun;

        // Fuite de l'autre côté du joueur
        if (squaredDist < EnemyDistanceRunSqrt && isPlayerArmed)
        {
            // Vector player to me
            Vector3 dirToPlayer = transform.position - Player.transform.position;

            Vector3 newPos = transform.position + dirToPlayer;

            mAgent.SetDestination(newPos);

        }

        mAnimator.SetBool("walk", IsNavMeshMoving);

    }
}
