
using UnityEngine;

public class EnemySpawnerController
{
    private EnemySpawnerView enemySpawnerView;
    private GameObject[] obstacles;
    private Transform currentTransform;
    private int counter = 1;

    private void SpawnObstacles(GameObject obstacle, GameObject obstacle2)
    {
            int i = 0;
            Object.Instantiate(GameService.Instance.GetColorChanger(), new Vector3(GameService.Instance.GetStartPosition().position.x, GameService.Instance.GetStartPosition().transform.position.y + ((i = i + 1) * 4.5f), GameService.Instance.GetStartPosition().position.z), enemySpawnerView.gameObject.transform.rotation);
            Object.Instantiate(obstacle, new Vector3(GameService.Instance.GetStartPosition().transform.position.x, GameService.Instance.GetStartPosition().transform.position.y + ((i = i + 1) * 4.5f), GameService.Instance.GetStartPosition().position.z), enemySpawnerView.gameObject.transform.rotation);
            Object.Instantiate(GameService.Instance.GetColorChanger(), new Vector3(GameService.Instance.GetStartPosition().transform.position.x, GameService.Instance.GetStartPosition().transform.position.y + ((i = i + 1) * 4.5f), GameService.Instance.GetStartPosition().position.z), enemySpawnerView.gameObject.transform.rotation);
            GameObject newObject = Object.Instantiate(obstacle2, new Vector3(GameService.Instance.GetStartPosition().position.x, GameService.Instance.GetStartPosition().transform.position.y + ((i = i + 1) * 4.5f), GameService.Instance.GetStartPosition().position.z), enemySpawnerView.gameObject.transform.rotation);

            currentTransform = newObject.transform;
    }

    public EnemySpawnerController(EnemySpawnerView enemyView, GameObject[] obstacles)
    {
        this.enemySpawnerView = enemyView;
        enemyView.SetController(this);
        this.obstacles = obstacles;
        GameService.Instance.StartGame += OnGameStart;
        GameService.Instance.RestartGame += OnGameStart;
    }

    public void OnGameStart()
    {
        GameObject[] ObjectsToDestroy = GameObject.FindGameObjectsWithTag("ENEMY");
        for (int i=0;i<ObjectsToDestroy.Length;i++)
        {
            enemySpawnerView.DestroyEnemy(ObjectsToDestroy[i]);
        }

        GameObject obstacle=obstacles[Random.Range(0, obstacles.Length)];
        GameObject obstacle2 = obstacles[Random.Range(0, obstacles.Length)];
        SpawnObstacles(obstacle,obstacle2);
        counter = 1;
    }

    public void Update()
    {
        if(GameService.Instance.UIService.GetUIController().GetCurrentScore()>counter)
        {
            int place = 1;
            Object.Instantiate(GameService.Instance.GetColorChanger(), new Vector3(GameService.Instance.GetStartPosition().transform.position.x, currentTransform.position.y + (place * 4.5f), GameService.Instance.GetStartPosition().position.z), enemySpawnerView.gameObject.transform.rotation);
            place++;
            int random = Random.Range(0, obstacles.Length);
            Object.Instantiate(obstacles[random], new Vector3(GameService.Instance.GetStartPosition().position.x, currentTransform.position.y + (place * 4.5f), GameService.Instance.GetStartPosition().position.z), enemySpawnerView.gameObject.transform.rotation);
            place++;
            Object.Instantiate(GameService.Instance.GetColorChanger(), new Vector3(GameService.Instance.GetStartPosition().position.x, currentTransform.position.y + (place * 4.5f), GameService.Instance.GetStartPosition().transform.position.z), enemySpawnerView.gameObject.transform.rotation);
            place++;
            random = Random.Range(0, obstacles.Length);
            GameObject newObject = Object.Instantiate(obstacles[random], new Vector3(GameService.Instance.GetStartPosition().position.x, currentTransform.position.y + (place * 4.5f), GameService.Instance.GetStartPosition().position.z), enemySpawnerView.gameObject.transform.rotation);
            currentTransform = newObject.transform;
            counter+=2;
        }
    }

}