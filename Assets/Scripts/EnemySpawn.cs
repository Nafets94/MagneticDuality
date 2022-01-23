using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
	private float spawnRate = 5.0f;
	private float speed = 0.0f;

    [SerializeField] private GameObject enemyOne;
    [SerializeField] private GameObject enemyTwo;

    [SerializeField] private Transform[] spawnPositions;

	private void Start()
	{
		StartCoroutine(SpawnWaves());
	}

	private IEnumerator SpawnWaves()
	{
		while (true)
		{
			int start = Random.Range(0, 6); //position the wall should start
			int units = 3; //how many cubes will the wall consist of

			for (int i = start; i <= start + units - 1; i++)
			{
				GameObject enemy = Instantiate(i!=6 ? enemyOne : enemyTwo, spawnPositions[i%7].position, Quaternion.identity);
				enemy.GetComponent<MoveEnemy>().SetSpeed(enemy.GetComponent<MoveEnemy>().GetSpeed() + speed);
			}

			yield return new WaitForSeconds(spawnRate);

			if (spawnRate >= 2f)
				spawnRate -= 0.15f;
			speed += 0.125f;
		}
	}
}
