using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {

	public int m_playerNumber;
	public float m_maxHealth;
	public Fist[] m_fists;
	public float m_jukeDistance; // TODO: Affected by leg muscle?

	private float m_health;
	private string m_inputJukeF;
	private string m_inputJukeB;
	private Entity m_entity;

	public float health { get { return m_health; } } 

	void Start ()
	{
		InputAxisMovement2D input = GetComponent<InputAxisMovement2D>();
		input.axisHorizontal = "Horizontal-"+m_playerNumber.ToString();
		input.axisVertical = "Vertical-"+m_playerNumber.ToString();
		m_health = m_maxHealth;
		m_entity = GetComponent<Entity>();

		Fist[] fists = GetComponentsInChildren<Fist>();
		for (int i = 0; i < fists.Length; ++i)
		{
			fists[i].playerNumber = m_playerNumber;
		}

		gameObject.SetLayerRecursive("Player-"+m_playerNumber.ToString());

		m_inputJukeF = "Juke-F-"+m_playerNumber.ToString();
		m_inputJukeB = "Juke-B-"+m_playerNumber.ToString();
	}

	void Update()
	{
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
	}
}
