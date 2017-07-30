using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {

	public int m_playerNumber;
	public float m_maxHealth;
	public Fist[] m_fists;
	public float m_jukeDistance; // TODO: Affected by leg muscle?

	private Animator m_animator;
	private float m_health;
	private string m_inputPunchR;
	private string m_inputPunchL;
	private string m_inputJukeF;
	private string m_inputJukeB;
	private Entity m_entity;


	void Start ()
	{
		InputAxisMovement2D input = GetComponent<InputAxisMovement2D>();
		input.axisHorizontal = "Horizontal-"+m_playerNumber.ToString();
		input.axisVertical = "Vertical-"+m_playerNumber.ToString();
		m_animator = GetComponent<Animator>();
		m_health = m_maxHealth;
		m_entity = GetComponent<Entity>();

		Fist[] fists = GetComponentsInChildren<Fist>();
		for (int i = 0; i < fists.Length; ++i)
		{
			fists[i].playerNumber = m_playerNumber;
		}

		gameObject.SetLayerRecursive("Player-"+m_playerNumber.ToString());

		m_inputPunchR = "Punch-R-"+m_playerNumber.ToString();
		m_inputPunchL = "Punch-L-"+m_playerNumber.ToString();
		m_inputJukeF = "Juke-F-"+m_playerNumber.ToString();
		m_inputJukeB = "Juke-B-"+m_playerNumber.ToString();
	}

	void Update()
	{
		// TODO: Hold down to charge up punch?
		if (Input.GetButtonUp(m_inputPunchR))
		{
			m_animator.SetTrigger("Punch-R");
		}
		if (Input.GetButtonUp(m_inputPunchL))
		{
			m_animator.SetTrigger("Punch-L");
		}
		if (Input.GetButtonUp(m_inputJukeF))
		{
			Vector3 facingDirection = transform.Direction(Vector3.right);
			Vector3 targetPosition = transform.position + facingDirection * m_jukeDistance;
			transform.position = targetPosition;
		}
		if (Input.GetButtonUp(m_inputJukeB))
		{
			Vector3 facingDirection = transform.Direction(Vector3.right);
			Vector3 targetPosition = transform.position - facingDirection * m_jukeDistance;
			transform.position = targetPosition;
		}
	}

	public void DealDamage(float _damage)
	{
		m_health -= _damage;
		if (m_health < 0)
		{
			// TODO: DIE
			Destroy(gameObject);
		}
		// TODO: Play damage FX
		Debug.Log(_damage+"Damage dealt to player "+m_playerNumber+": health = "+m_health+"/"+m_maxHealth);
	}

	public void StartPunching(int _index)
	{
		m_fists[_index].m_punching = true;
	}

	public void StopPunching(int _index)
	{
		m_fists[_index].m_punching = false;
	}
}
