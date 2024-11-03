
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController
{
    private EnemySpawnerView enemySpawnerView;
    private GameObject[] obstacles;
    private Transform currentTransform;
    private int counter = 1;
    private float OffsetY = 4.5f;
    private List<ColorChangerPoolItem> ColorChangerPool = new List<ColorChangerPoolItem>();
    private List<ObstaclePoolItem> obstaclePool = new List<ObstaclePoolItem>();


    public class ObstaclePoolItem
    {
        public bool isUsed = false;
        public GameObject obstacle;

        public ObstaclePoolItem(GameObject item)
        {
            obstacle = item;
        }
    }

    public class ColorChangerPoolItem
    {
        public bool isUsed = false;
        public GameObject ColorChangeObject;

        public ColorChangerPoolItem(GameObject item)
        {
            ColorChangeObject = item;
        }
    }

    private GameObject GetObstaclePooledItem(List<ObstaclePoolItem> pool, GameObject prefab)
    {
        foreach(var item in pool)
        {
            if(item.isUsed==false)
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

    private GameObject GetColorChangerPooledItem(List<ColorChangerPoolItem> pool, GameObject prefab)
    {
        foreach (var item in pool)
        {
            if (item.isUsed == false)
            {
                item.isUsed = true;
                item.ColorChangeObject.SetActive(true);
                return item.ColorChangeObject;
            }
        }
        GameObject newObject = Object.Instantiate(prefab);
        ColorChangerPoolItem newItem = new ColorChangerPoolItem(newObject);
        newItem.isUsed = true;
        pool.Add(newItem);
        return newItem.ColorChangeObject;
    }


    public void ReturnObstacleToPool(GameObject prefab)
    {
        prefab.SetActive(false);
        foreach (var item in obstaclePool)
        {
            if(item.obstacle==prefab)
            {
                item.obstacle.SetActive(false);
                item.isUsed=false;
                return;
            }
        }
        return;
    }

    public void ReturnColorChangerToPool(GameObject prefab)
    {
        prefab.SetActive(false);
        foreach (var item in ColorChangerPool)
        {
            if (item.ColorChangeObject == prefab)
            {
                item.ColorChangeObject.SetActive(false);
                item.isUsed = false;
                return;
            }
        }
        return;
    }

    private GameObject SpawnAtPosition(int pos,GameObject prefab)
    {

        GameObject newTransform;
        if (prefab.tag=="CHANGER")
        {
          newTransform  =  GetColorChangerPooledItem(ColorChangerPool, prefab);
        }
        else
        {
            newTransform = GetObstaclePooledItem(obstaclePool, prefab);
            newTransform.gameObject.GetComponent<ObstacleHolder>().EnableScore();
        }
        newTransform.transform.position= new Vector3(currentTransform.position.x, currentTransform.position.y+(pos*OffsetY),currentTransform.position.z);

        return newTransform;
    }

    public void DisableObstacle(GameObject Obstacle)
    {
        ReturnObstacleToPool(Obstacle);
    }

    private void SpawnObstacles()
    {
        

        int posY = 1;
        SpawnAtPosition(posY, GameService.Instance.GetColorChanger());
        posY++;
        SpawnAtPosition(posY, obstacles[Random.Range(0, obstacles.Length)]);
        posY++;
        SpawnAtPosition(posY, GameService.Instance.GetColorChanger());
        posY++;
        currentTransform=SpawnAtPosition(posY, obstacles[Random.Range(0, obstacles.Length)]).transform;
    }

    private void InitializeObstacles()
    {
        for(int i=0;i<obstacles.Length;i++)
        {
            GameObject newObject = Object.Instantiate(obstacles[i]);
            ObstaclePoolItem newItem = new ObstaclePoolItem(newObject);
            newItem.isUsed = false;
            newObject.SetActive(false);
            obstaclePool.Add(newItem);
        }
    }


    public EnemySpawnerController(EnemySpawnerView enemyView, GameObject[] obstacles)
    {
        this.enemySpawnerView = enemyView;
        enemyView.SetController(this);
        this.obstacles = obstacles;
        InitializeObstacles();
        GameService.Instance.StartGame += OnGameStart;
        GameService.Instance.RestartGame += OnGameStart;
    }

    public void OnGameStart()
    {
        GameObject[] ObjectsToDestroy = GameObject.FindGameObjectsWithTag("ENEMY");
        for (int i=0;i<ObjectsToDestroy.Length;i++)
        {
            ReturnObstacleToPool(ObjectsToDestroy[i]);
        }
        GameObject[] obToDestroy = GameObject.FindGameObjectsWithTag("CHANGER");
        for (int i = 0; i <obToDestroy.Length; i++)
        {
            ReturnColorChangerToPool(obToDestroy[i]);
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
            SpawnAtPosition(posY, GameService.Instance.GetColorChanger());
            posY++;
            SpawnAtPosition(posY, obstacles[Random.Range(0, obstacles.Length)]);
            posY++;
            SpawnAtPosition(posY, GameService.Instance.GetColorChanger());
            posY++;
            currentTransform=SpawnAtPosition(posY, obstacles[Random.Range(0, obstacles.Length)]).transform;
            counter += 2;
            Debug.Log("Spawning Element");
        }
    }

}