using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
	public GameObject targetPrefab;
	public float[] spawnHeights;
	public float spawnIntervall;
	public Vector2 spawnBoundsTopRight;
	public Vector2 spawnBoundsBottomLeft;
	public Vector2 speedRange;


	private float timeSinceLastSpawn;
	
	// Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastSpawn > spawnIntervall)
		{
			timeSinceLastSpawn = 0;
			SpawnTarget();
		}

		timeSinceLastSpawn += Time.deltaTime;
    }

	private void SpawnTarget ()
	{
		int heightIndex = Random.Range(0, spawnHeights.Length);
		Vector3 spawnPos = new Vector3(0, spawnHeights[heightIndex], 0);

		if (Random.value > 0.5f)
		{
			//x Max
			if (Random.value > 0.5f)
			{
				spawnPos.x = spawnBoundsBottomLeft.x;
			}
			else
			{
				spawnPos.x = spawnBoundsTopRight.x;
			}
			spawnPos.z = Random.Range(spawnBoundsBottomLeft.y, spawnBoundsTopRight.y);
		} else
		{
			//y Max
			if (Random.value > 0.5f)
			{
				spawnPos.z = spawnBoundsBottomLeft.y;
			}
			else
			{
				spawnPos.z = spawnBoundsTopRight.y;
			}
			spawnPos.z = Random.Range(spawnBoundsBottomLeft.x, spawnBoundsTopRight.x);
		}

		var target = Instantiate(targetPrefab);
		target.transform.position = spawnPos;
		target.transform.LookAt(new Vector3(Random.Range(spawnBoundsBottomLeft.x, spawnBoundsTopRight.x), spawnPos.y, Random.Range(spawnBoundsBottomLeft.y, spawnBoundsTopRight.y)));
		target.GetComponent<Rigidbody>().velocity = target.transform.forward * Random.Range(speedRange.x, speedRange.y);
	}
}
