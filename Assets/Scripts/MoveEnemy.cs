using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
	[SerializeField] private GameObject explodevfx;
    private Vector3 endPosition;
    private float speed = 10f;

    public void SetSpeed(float _speed)
	{
        this.speed = _speed;
	}

    public float GetSpeed()
	{
        return this.speed;
	}

    private void Start()
    {
        endPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 150f);
    }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Ball"))
		{
			GameObject explosion = Instantiate(explodevfx, collision.transform.position, Quaternion.identity);
			this.GetComponent<AudioSource>().mute = false;
			this.GetComponent<AudioSource>().Play();
			Destroy(collision.gameObject);
			GameObject.Find("LevelManager").GetComponent<LevelManager>().EndGame();
		}	
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("CubeDestroyer"))
		{
			Destroy(this.gameObject);
		}
	}

	private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPosition, step);
    }
}
