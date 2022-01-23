using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingChargedBall : ChargedType
{
    [SerializeField] private float mass;

    private Rigidbody rb;

	private void Start()
	{
		rb = this.GetComponent<Rigidbody>();

		rb.mass = mass;

		UpdateMaterial();
	}
}
