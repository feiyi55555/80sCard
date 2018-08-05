using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkillTest : MonoBehaviour {
    public NavMeshAgent m_NavMeshAgent;
    public Animator m_Animator;
    public float m_Speed = 3.0f;
    public int SkillId = 0;

    protected SkillTest m_Target;
    private Skill m_Skill;

    private void Awake()
    {
        m_NavMeshAgent = gameObject.AddComponent<NavMeshAgent>();
        m_NavMeshAgent.speed = 0;
        m_NavMeshAgent.acceleration = 0;
        m_NavMeshAgent.angularSpeed = 0;
        //m_NavMeshAgent.avoidancePriority
        m_NavMeshAgent.height = 2.0f;
        m_NavMeshAgent.radius = 1.5f;
        m_NavMeshAgent.stoppingDistance = 2.0f;

        CapsuleCollider capsuleCollider = gameObject.AddComponent<CapsuleCollider>();
        capsuleCollider.height = m_NavMeshAgent.height;
        capsuleCollider.radius = m_NavMeshAgent.radius;
        capsuleCollider.center = Vector3.up * (Mathf.Max(capsuleCollider.height / 2.0f, capsuleCollider.radius) + 0.03f); // 中心要么是高度的一半，要么是半径

        m_Animator = gameObject.GetComponent<Animator>();
        // TODO:光照
    }

    void Start () {
		if (SkillId > 0)
        {
            m_Skill = new Skill(SkillId);
        }
        // TODO:
	}
	
	void Update () {
		
	}

    void FightStateUpdate()
    {
        if (m_Target == null)
        {
            m_Target = FindTargetInRadius();
        }
        else
        {
            bool moveToTarget = false;
        }
    }

    public SkillTest FindTargetInRadius()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 100, 1 << LayerMask.NameToLayer("Warrior"));
        for (int i = 0; i < colliders.Length; i++)
        {
            Collider collider = colliders[i];
            SkillTest unit = collider.gameObject.GetComponent<SkillTest>();
            if (unit == null)
            {
                continue;
            }
            if (unit == this)
            {
                continue;
            }
            return unit;
        }
        return null;
    }

    public void TryAttack() { }
}
