using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject enemy, coin;
    private GameObject instanceCoint = null;
    // Start is called before the first frame update
    void Start()
    {
        System.Action lvlRef;

        lvlRef = this.Level1;
        InvokeRepeating(lvlRef.Method.Name, 0, 3f);
        lvlRef = this.Level2;
        InvokeRepeating(lvlRef.Method.Name, 0, 2f);
        lvlRef = this.Level3;
        InvokeRepeating(lvlRef.Method.Name, 0, 1.25f);
        lvlRef = this.Coins;
        InvokeRepeating(lvlRef.Method.Name, 0, 9f);
        StateController.Get().OnEndGame += StopSpawns;
    }

    void EnemySpawn()
    {
        Instantiate(enemy, new Vector3(Random.Range(-6f, 6f), 11, 27), Quaternion.identity);
        Instantiate(enemy, new Vector3(27, 11, Random.Range(-6f, 6f)), Quaternion.identity);
        Instantiate(enemy, new Vector3(Random.Range(-6f, 6f), 11, -27), Quaternion.identity);
        Instantiate(enemy, new Vector3(-27, 11, Random.Range(-6f, 6f)), Quaternion.identity);
    }
    void StopSpawns()
    {
        CancelInvoke();
    }


    void Level1() // INCLUDES SCORE CONTROLLER
    {
        if (!StateController.Get().InGame())
            return;
        if (DataController.Get().CurrentLevel == 1) EnemySpawn();
        DataController.Get().CurrentScore++;
    }
    void Level2()
    {
        if (StateController.Get().InGame() && DataController.Get().CurrentLevel == 2) EnemySpawn();
    }
    void Level3()
    {
        if (StateController.Get().InGame() && DataController.Get().CurrentLevel == 3) EnemySpawn();
    }

    void Coins()
    {
        if (StateController.Get().InGame())
        {
            if (instanceCoint == null)
            {
                instanceCoint = Instantiate(coin, new Vector3(Random.Range(-3.8f, 3.8f), 11.15f, Random.Range(-5f, 5f)), Quaternion.identity);
            }
        }
    }
}
