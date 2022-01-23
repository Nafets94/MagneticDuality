using DG.Tweening;
using System.Collections;
using UnityEngine;

public class MagnetManager : MonoBehaviour
{
    [SerializeField] private MovingChargedBall movingBall;
	[SerializeField] private GameObject LevelManager;

    [SerializeField] private ChargedType[] magnets;

    [SerializeField] private float _force = 1000f;

	private Rigidbody rb;

	private void Start()
	{
		rb = movingBall.GetComponent<Rigidbody>();
	}

	private void ApplyMagneticForce()
	{
        Vector3 newForce = Vector3.zero;
		if (movingBall.gameObject != null)
		{
			foreach (ChargedType magnet in magnets)
			{
				float distance = Vector3.Distance(movingBall.transform.position, magnet.transform.position);
				float force = _force * movingBall.GetCharge() * magnet.GetCharge() / Mathf.Pow(distance, 2);

				Vector3 newDirection = movingBall.transform.position - magnet.transform.position;
				newDirection.Normalize();

				newForce += force * newDirection * 0.04f;

				rb.AddForce(newForce);
			}
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown("left"))
		{
			LevelManager.GetComponent<LevelManager>().ToggleEffectsLeft(false);
			LevelManager.GetComponent<LevelManager>().StopLeft();

			Sequence sequence = DOTween.Sequence();
			sequence.Append(magnets[0].transform.DOMoveX(-10f, 0.25f)).SetEase(Ease.Linear).AppendCallback(() =>
			{
				magnets[0].SetCharge(magnets[0].GetCharge() * -1);
				magnets[0].UpdateMaterial();
			});
			sequence.Append(magnets[0].transform.DOMoveX(-5.476f, 0.25f)).SetEase(Ease.Linear).OnComplete(() =>
			{
				LevelManager.GetComponent<LevelManager>().PlayHitLeft();
				LevelManager.GetComponent<LevelManager>().ToggleEffectsLeft(true);
				LevelManager.GetComponent<LevelManager>().PlayLeft();
			});
		}

		if (Input.GetKeyDown("right"))
		{
			LevelManager.GetComponent<LevelManager>().ToggleEffectsRight(false);
			LevelManager.GetComponent<LevelManager>().StopRight();

			Sequence sequence = DOTween.Sequence();
			sequence.Append(magnets[1].transform.DOMoveX(10f, 0.25f)).SetEase(Ease.Linear).AppendCallback(() =>
			{
				magnets[1].SetCharge(magnets[1].GetCharge() * -1);
				magnets[1].UpdateMaterial();
			});
			sequence.Append(magnets[1].transform.DOMoveX(5.533f, 0.25f)).SetEase(Ease.Linear).OnComplete(() =>
			{
				LevelManager.GetComponent<LevelManager>().PlayHitRight();
				LevelManager.GetComponent<LevelManager>().ToggleEffectsRight(true);
				LevelManager.GetComponent<LevelManager>().PlayRight();
			});
		}
	}

	private void FixedUpdate()
	{
		ApplyMagneticForce();
	}
}
