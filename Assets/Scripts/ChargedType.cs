using UnityEngine;

public class ChargedType : MonoBehaviour
{
	[SerializeField] private int charge;

	[SerializeField] private Material plusMaterial;
	[SerializeField] private Material minusMaterial;
	
	public void SetCharge(int charge)
	{
		this.charge = charge;
	}

	public int GetCharge()
	{
		return charge;
	}

	private void Start()
	{
		UpdateMaterial();
	}

	public void UpdateMaterial()
	{
		if (this.transform.childCount > 0)
		{
			if (charge > 0)
			{
				this.transform.Find("Back").gameObject.GetComponent<MeshRenderer>().material = plusMaterial;
			}
			else
			{
				this.transform.Find("Back").gameObject.GetComponent<MeshRenderer>().material = minusMaterial;
			}
		}
	}
}
