using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {
	public GameObject[] outWallArray;
	public GameObject[] floorArray;
	public GameObject[] wallArray;
	public GameObject[] foodArray;
	public GameObject[] enemyArray;
	public GameObject exitPrefab;

	public int rows;
	public int cols;

	public int minCountWall = 2;
	public int maxCountWall = 8;

	private Transform mapHolder;
	private List<Vector2> positionList = new List<Vector2>();

	public GameManager gameManager;
	// Use this for initialization
	void Awake () {
		gameManager = this.GetComponent<GameManager> ();
		InitMap ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void InitMap(){
		mapHolder = new GameObject ("Map").transform;
		for (int x = 0; x < cols; x++) {
			for (int y = 0; y < rows; y++) {
				if (x == 0 || y == 0 || x == rows - 1 || y == cols - 1) {
					int index = Random.Range (0, outWallArray.Length);
					GameObject go = GameObject.Instantiate (outWallArray [index], new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
					go.transform.SetParent (mapHolder);
				} else {
					int index = Random.Range (0, floorArray.Length);
					GameObject go = GameObject.Instantiate (floorArray [index], new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
					go.transform.SetParent (mapHolder);
				}
			}
		}

		positionList.Clear ();
		for (int x = 2; x < cols - 2; x++) {
			for (int y = 2; y < rows - 2; y++) {
				positionList.Add (new Vector2(x,y));
			}
		}

		//wall
		int wallCount = Random.Range (minCountWall,maxCountWall + 1);
		InstantiateItems (wallCount,wallArray);
		/*for (int i = 0; i < wallCount; i++) {
			Vector2 pos = RandomPosition ();
			GameObject wallPrefab = RandomPrefab (wallArray);
			GameObject go = GameObject.Instantiate (wallPrefab,pos,Quaternion.identity) as GameObject;
			//int WallIndex = Random.Range (0,wallArray.Length);
			//GameObject go = GameObject.Instantiate (wallArray[WallIndex],pos,Quaternion.identity);
			go.transform.SetParent (mapHolder);
		}*/

		//food
		int foodCount = Random.Range (2,gameManager.level*2 + 1);
		InstantiateItems (foodCount,foodArray);
		/*for(int i = 0;i < foodCount;i++){
			Vector2 pos = RandomPosition ();
			GameObject foodPrefab = RandomPrefab (foodArray);
			GameObject go = Instantiate (foodPrefab,pos,Quaternion.identity) as GameObject;
			go.transform.SetParent (mapHolder);
		}*/

		//enemy
		int enemyCount = gameManager.level/2;
		/*for(int i = 0;i < enemyCount+1;i++){
			Vector2 pos = RandomPosition ();
			GameObject enemyPrefab = RandomPrefab (enemyArray);
			GameObject go = Instantiate(enemyPrefab,pos,Quaternion.identity) as GameObject;
			go.transform.SetParent (mapHolder);
		}*/
		InstantiateItems (enemyCount+1,enemyArray);
		//chukou
		GameObject goOut = Instantiate(exitPrefab,new Vector2(cols - 2,rows - 2),Quaternion.identity) as GameObject; 
		goOut.transform.SetParent (mapHolder);
	}

	private void InstantiateItems(int count,GameObject[] prefabs){
		for(int i = 0;i < count;i++){
			Vector2 pos = RandomPosition ();
			GameObject enemyPrefab = RandomPrefab (prefabs);
			GameObject go = Instantiate(enemyPrefab,pos,Quaternion.identity) as GameObject;
			go.transform.SetParent (mapHolder);
		}
	}
	private Vector2 RandomPosition(){
		int positionindex = Random.Range (0,positionList.Count);
		Vector2 pos = positionList[positionindex];
		positionList.RemoveAt (positionindex);
		return pos;
	}
	private GameObject RandomPrefab(GameObject[] prefabs){
		int index = Random.Range (0,prefabs.Length);
		return prefabs[index];
	}
}
