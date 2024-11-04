
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerController
{
    private ObstacleSpawnerView obstacleSpawnerView;
    private GameObject[] obstaclesGameObject;
    private Transform currentTransform;
    private int counter = 1;
    private float OffsetY = 4.5f;
    private List<ColorChangerPoolItem> ColorChangerPool = new List<ColorChangerPoolItem>();
    private List<ObstaclePoolItem> obstaclePool = new List<ObstaclePoolItem>();

    public ObstacleSpawnerController(ObstacleSpawnerView obstacleView, GameObject[] obstaclesGameObject)
    {
        this.obstacleSpawnerView = obstacleView;
        obstacleView.SetController(this);
        this.obstaclesGameObject = obstaclesGameObject;
        //InitializeObstacles();
        GameService.Instance.StartGame += OnGameStart;
        GameService.Instance.RestartGame += OnGameStart;
    }

    private GameObject SpawnAtPosition(int pos,GameObject objectPrefab)
    {

        GameObject newGameObject;
        if (objectPrefab.tag=="CHANGER")
        {
          newGameObject  =  GetColorChangerPooledItem(ColorChangerPool, objectPrefab);
        }
        else
        {
            newGameObject = GetObstaclePooledItem(obstaclePool, objectPrefab);
            newGameObject.gameObject.GetComponent<ObstacleHolder>().EnableObjects();
        }
        newGameObject.transform.position= new Vector3(currentTransform.position.x, currentTransform.position.y+(pos*OffsetY),currentTransform.position.z);

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
        /*
        int posY = 1;
        SpawnAtPosition(posY, GameService.Instance.GetColorChanger());
        posY++;
        SpawnAtPosition(posY, obstaclesGameObject[Random.Range(0, obstaclesGameObject.Length)]);
        posY++;
        SpawnAtPosition(posY, GameService.Instance.GetColorChanger());
        posY++;
        currentTransform=SpawnAtPosition(posY, obstaclesGameObject[Random.Range(0, obstaclesGameObject.Length)]).transform;
        */
    }

    private void InitializeObstacles()
    {
        for(int i=0;i<obstaclesGameObject.Length;i++)
        {
            GameObject newObject = Object.Instantiate(obstaclesGameObject[i]);
            ObstaclePoolItem newItem = new ObstaclePoolItem(newObject);
            newItem.isUsed = false;
            newObject.SetActive(false);
            obstaclePool.Add(newItem);
        }
    }

    public void OnGameStart()
    {
        GameObject[] ObstaclesToDestroy = GameObject.FindGameObjectsWithTag("ENEMY");
        for (int i=0;i<ObstaclesToDestroy.Length;i++)
        {
            ReturnObstacleToPool(ObstaclesToDestroy[i]);
        }
        /*
        GameObject[] ColorChangersToDestroy = GameObject.FindGameObjectsWithTag("CHANGER");
        for (int i = 0; i <ColorChangersToDestroy.Length; i++)
        {
            ReturnColorChangerToPool(ColorChangersToDestroy[i]);
        }*/
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
            /*
            int posY = 1;
            //SpawnAtPosition(posY, GameService.Instance.GetColorChanger());
            posY++;
            SpawnAtPosition(posY, obstaclesGameObject[Random.Range(0, obstaclesGameObject.Length)]);
            posY++;
            SpawnAtPosition(posY, GameService.Instance.GetColorChanger());
            posY++;
            currentTransform = SpawnAtPosition(posY, obstaclesGameObject[Random.Range(0, obstaclesGameObject.Length)]).transform;
            counter += 2;
            Debug.Log("Spawning Element");*/
        }
    }

    public void SetOffset(float OffsetY) => this.OffsetY = OffsetY; 


    //Obstacle POOL
    public class ObstaclePoolItem
    {
        public bool isUsed = false;
        public GameObject obstacle;

        public ObstaclePoolItem(GameObject item)
        {
            obstacle = item;
        }
    }

    public GameObject GetObstaclePooledItem(List<ObstaclePoolItem> pool, GameObject prefab)
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

    //COLOR CHANGER POOL logic

    public class ColorChangerPoolItem
    {
        public bool isUsed = false;
        public GameObject ColorChangeObject;

        public ColorChangerPoolItem(GameObject item)
        {
            ColorChangeObject = item;
        }
    }

    public GameObject GetColorChangerPooledItem(List<ColorChangerPoolItem> pool, GameObject prefab)
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

    private void ReturnColorChangerToPool(GameObject prefab)
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

    public void DisableObstacle(GameObject Obstacle)
    {
        ReturnObstacleToPool(Obstacle);
    }

    public void DisableColorChanger(GameObject ColorChanger)
    {
        ReturnColorChangerToPool(ColorChanger);
    }

}