using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
	public Transform[] spawnPointsArr;

	//bool loopBool = true;
	public List<GameObject> ObjInit = new List<GameObject>();

	
    // Start is called before the first frame update
    void Start()
    {

    }
	public void ClickToSpawn()
	{
		Debug.Log("Started SpawnOnImageTracked Function.");
		List<int> numItems = new List<int>();
		int cnt = numItems.Count;
		while(cnt < 10)
		{
			int randomIndex = UnityEngine.Random.Range(0,10);
			if(numItems.Count<=0){
				numItems.Add(randomIndex);
			}
			else if(numItems.Contains(randomIndex)){
				continue;
			}
			else{
				Debug.Log("added to randomIndex else");
				numItems.Add(randomIndex);
			}
			if (numItems.Count > 0)
			{
				for (int i = 0; i < numItems.Count; i++)
				{
					ObjInit[i].transform.position = spawnPointsArr[numItems[i]].position;
					ObjInit[i].transform.localRotation = Quaternion.identity;
					ObjInit[i].SetActive(true);
				}
			}
			cnt = numItems.Count;
		}
		Debug.Log("=============== Spawned Objects ===============");
	}
	public void RemoveObjsOnImageLostTracked(){
		RemoveObjs();
	}
	void RemoveObjs(){
		foreach(GameObject obj in ObjInit){
			obj.SetActive(false);
		}
	}

	IEnumerator delayBeforeSpawn()
	{
		yield return new WaitForSeconds(2);
	}
}