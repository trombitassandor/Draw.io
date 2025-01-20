using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public float m_CollisionDurationInSec = 1f;
    public float m_CollisionMoveOffsetMultiplier = 1f;

    private Player m_Player;
    private Animation[] m_Animations;
    private ParticleSystem m_ParticleSystem;

    private bool m_HasCollided = false;
    private float m_CollisionTimer = 0f;
    private Vector3 m_MoveOffset;

    protected void Awake()
    {
        if (GameManager.Instance.m_IsCollisionDisabled) Destroy(this);
        m_Player = GetComponent<Player>();
        m_ParticleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        m_Animations = GetComponentsInChildren<Animation>();
    }

    private void OnTriggerEnter(Collider _Other)
    {
        if (_Other.TryGetComponent<Player>(out _))
        {
            OnStartCollisionMove(_Other);
        }
    }

    private void Update()
    {
        if (!m_HasCollided)
        {
            return;
        }

        transform.position = transform.position + m_MoveOffset * Time.deltaTime;

        m_CollisionTimer += Time.deltaTime;

        if (m_CollisionTimer > m_CollisionDurationInSec || m_Player.isEliminated)
        {
            OnEndCollisionMove();
        }
    }

    private void OnStartCollisionMove(Collider _Other)
    {
        foreach (var animation in m_Animations)
        {
            animation.Play();
        }
        m_ParticleSystem.Play();
        GetDirectionByCollision(_Other, ref m_MoveOffset);
        m_Player.enabled = false;
        m_HasCollided = true;
    }

    private void OnEndCollisionMove()
    {
        m_Player.enabled = true;
        m_HasCollided = false;
        m_CollisionTimer = 0f;
        m_HasCollided = false;
    }

    private void GetDirectionByCollision(Collider _Other, ref Vector3 _Offset)
    {
        var diff = transform.position - _Other.transform.position;
        var normalizedDiff = diff.normalized;
        var offset = normalizedDiff * m_CollisionMoveOffsetMultiplier;
        _Offset = new Vector3(offset.x, 0f, offset.z);
    }
}
