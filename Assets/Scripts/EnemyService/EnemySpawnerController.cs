using UnityEngine;

public class EnemySpawnerController
{
    private EnemySpawnerView enemyView;
    private GameObject[] obstacles;
    private Transform currentTransform;
    int counter = 1;
    public EnemySpawnerController(EnemySpawnerView enemyView, GameObject[] obstacles)
    {
        this.enemyView = enemyView;
        enemyView.SetController(this);
        this.obstacles = obstacles;
        GameService.Instance.StartGame += OnGameStart;
        GameService.Instance.RestartGame += OnGameStart;
    }

    public void OnGameStart()
    {
        GameObject[] ObjectsToDestroy = GameObject.FindGameObjectsWithTag("ENEMY");

        for(int i=0;i<ObjectsToDestroy.Length;i++)
        {
            enemyView.DestroyEnemy(ObjectsToDestroy[i]);
        }


        GameObject obstacle=obstacles[Random.Range(0, obstacles.Length)];
        GameObject obstacle2 = obstacles[Random.Range(0, obstacles.Length)];
        SpawnObstacles(obstacle,obstacle2);
        counter = 1;
    }

    private void SpawnObstacles(GameObject obstacle, GameObject obstacle2)
    {
        int place = 1;
        Object.Instantiate(GameService.Instance.ColorChanger, new Vector3(GameService.Instance.StartPostion.transform.position.x, GameService.Instance.StartPostion.transform.position.y + ((place) * 4.5f), GameService.Instance.StartPostion.transform.position.z),enemyView.gameObject.transform.rotation);
        place++;
        Object.Instantiate(obstacle, new Vector3(GameService.Instance.StartPostion.transform.position.x, GameService.Instance.StartPostion.transform.position.y + ((place) * 4.5f), GameService.Instance.StartPostion.transform.position.z), enemyView.gameObject.transform.rotation);
        place++;
        Object.Instantiate(GameService.Instance.ColorChanger, new Vector3(GameService.Instance.StartPostion.transform.position.x, GameService.Instance.StartPostion.transform.position.y + ((place) * 4.5f), GameService.Instance.StartPostion.transform.position.z), enemyView.gameObject.transform.rotation);
        place++;
        GameObject newObject = Object.Instantiate(obstacle2, new Vector3(GameService.Instance.StartPostion.transform.position.x, GameService.Instance.StartPostion.transform.position.y + ((place) * 4.5f), GameService.Instance.StartPostion.transform.position.z), enemyView.gameObject.transform.rotation);
        currentTransform = newObject.transform;
        place++;
    }

    public void Update()
    {
        if(GameService.Instance.UIService.GetUIController().GetCurrentScore()>counter)
        {
            Debug.Log("EnemySpawning");
            int place = 1;
            Object.Instantiate(GameService.Instance.ColorChanger, new Vector3(GameService.Instance.StartPostion.transform.position.x, currentTransform.position.y + (place * 4.5f), GameService.Instance.StartPostion.transform.position.z), enemyView.gameObject.transform.rotation);
            place++;
            int random = Random.Range(0, obstacles.Length);
            Object.Instantiate(obstacles[random], new Vector3(GameService.Instance.StartPostion.transform.position.x, currentTransform.position.y + (place * 4.5f), GameService.Instance.StartPostion.transform.position.z), enemyView.gameObject.transform.rotation);
            place++;
            Object.Instantiate(GameService.Instance.ColorChanger, new Vector3(GameService.Instance.StartPostion.transform.position.x, currentTransform.position.y + (place * 4.5f), GameService.Instance.StartPostion.transform.position.z), enemyView.gameObject.transform.rotation);
            place++;
            random = Random.Range(0, obstacles.Length);
            GameObject newObject = Object.Instantiate(obstacles[random], new Vector3(GameService.Instance.StartPostion.transform.position.x, currentTransform.position.y + (place * 4.5f), GameService.Instance.StartPostion.transform.position.z), enemyView.gameObject.transform.rotation);
            currentTransform = newObject.transform;
            counter+=2;
        }
    }

}