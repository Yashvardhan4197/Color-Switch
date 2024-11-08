
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawnerController
{
    private ObstacleSpawnerView obstacleSpawnerView;
    private GameObject[] obstaclesGameObject;
    private List<GameObject> InstantiatedObstacles;
    private Transform currentTransform;
    private int counter = 1;
    private float OffsetY = 4.5f;
    private List<ObstaclePoolItem> obstaclePool = new List<ObstaclePoolItem>();

    public ObstacleSpawnerController(ObstacleSpawnerView obstacleView, GameObject[] obstaclesGameObject)
    {
        this.obstacleSpawnerView = obstacleView;
        obstacleView.SetController(this);
        this.obstaclesGameObject = obstaclesGameObject;
        InstantiatedObstacles=new List<GameObject>();
        GameService.Instance.StartGame += OnGameStart;
        GameService.Instance.RestartGame += OnGameStart;
    }

    private GameObject SpawnAtPosition(int pos,GameObject objectPrefab)
    {

        GameObject newGameObject;
        newGameObject = GetObstaclePooledItem(obstaclePool, objectPrefab);
        newGameObject.gameObject.GetComponent<ObstacleHolder>().EnableObjects();
        newGameObject.transform.position= new Vector3(currentTransform.position.x, currentTransform.position.y+(pos*OffsetY),currentTransform.position.z);
        newGameObject.transform.SetParent(obstacleSpawnerView.transform);
        InstantiatedObstacles.Add(newGameObject);
        return newGameObject;
    }

    private void SpawnObstacles()
    {
        int posY = 0;
        for (posY = 0; posY < obstaclesGameObject.Length-1; posY++)
        {
            SpawnAtPosition(posY+1, obstaclesGameObject[posY]);
        }
        currentTransform = SpawnAtPosition(posY+1, obstaclesGameObject[obstaclesGameObject.Length-1]).transform;
    }

    public void OnGameStart()
    {
        /*
        GameObject[] ObstaclesToDestroy = GameObject.FindGameObjectsWithTag("ENEMY");
        for (int i=0;i<ObstaclesToDestroy.Length;i++)
        {
            ReturnObstacleToPool(ObstaclesToDestroy[i]);
        }*/

        for(int i=0;i<InstantiatedObstacles.Count;i++)
        {
            ReturnObstacleToPool(InstantiatedObstacles[i]);
        }
        
        currentTransform = GameService.Instance.GetStartPosition();
        SpawnObstacles();
        counter = 1;
    }

    public void Update()
    {
        if(GameService.Instance.UIService.GetUIController().GetCurrentScore()>counter)
        {
            int posY = 1;
            SpawnAtPosition(posY, obstaclesGameObject[Random.Range(0, obstaclesGameObject.Length)]);
            posY++;
            currentTransform = SpawnAtPosition(posY, obstaclesGameObject[Random.Range(0, obstaclesGameObject.Length)]).transform;
            counter += 2;
        }
    }

    public void SetOffset(float OffsetY) => this.OffsetY = OffsetY; 


    //Obstacle POOL
    private class ObstaclePoolItem
    {
        public bool isUsed = false;
        public GameObject obstacle;

        public ObstaclePoolItem(GameObject item)
        {
            obstacle = item;
        }
    }

    private GameObject GetObstaclePooledItem(List<ObstaclePoolItem> pool, GameObject prefab)
    {
        foreach (var item in pool)
        {
            if (item.isUsed == false)
            {
                item.isUsed = true;
                item.obstacle.SetActive(true);
                return item.obstacle;
            }
        }
        GameObject newObject = Object.Instantiate(prefab);
        ObstaclePoolItem newItem = new ObstaclePoolItem(newObject);
        newItem.isUsed = true;
        pool.Add(newItem);
        return newItem.obstacle;
    }

    private void ReturnObstacleToPool(GameObject prefab)
    {
        prefab.SetActive(false);
        foreach (var item in obstaclePool)
        {
            if (item.obstacle == prefab)
            {
                item.obstacle.SetActive(false);
                item.isUsed = false;
                return;
            }
        }
        return;
    } 

    public void DisableObstacle(GameObject Obstacle)
    {
        ReturnObstacleToPool(Obstacle);
    }

}