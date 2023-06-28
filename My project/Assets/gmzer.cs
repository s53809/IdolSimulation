using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gmzer : MonoBehaviour
{
    [SerializeField] GameObject char1;
    [SerializeField] GameObject char2;
    [SerializeField] GameObject char3;
    [SerializeField] GameObject char4;
    [SerializeField] GameObject enemy;
    private Vector3[] spots = new Vector3[5];

    public int enemyCount = 0;
    void Start()
    {
        spots[0] = new Vector3(3.77f, -0.12f, 0);
        spots[1] = new Vector3(4.92f, -2.79f, 0);
        spots[2] = new Vector3(5.37f, -0.82f, 0);
        spots[3] = new Vector3(7.21f, -2.3f, 0);
        spots[4] = new Vector3(6.43f, -3.65f, 0);

        char1.GetComponent<CharacterEntity>().health = DataManager.Instance.GetData().characterStrengths[0] * 10;
        char2.GetComponent<CharacterEntity>().health = DataManager.Instance.GetData().characterStrengths[1] * 10;
        char3.GetComponent<CharacterEntity>().health = DataManager.Instance.GetData().characterStrengths[2] * 10;
        char4.GetComponent<CharacterEntity>().health = DataManager.Instance.GetData().characterStrengths[3] * 10;

        char1.GetComponent<CharacterEntity>().damage = DataManager.Instance.GetData().characterStrengths[0] * 2;
        char2.GetComponent<CharacterEntity>().damage = DataManager.Instance.GetData().characterStrengths[1] * 2;
        char3.GetComponent<CharacterEntity>().damage = DataManager.Instance.GetData().characterStrengths[2] * 2;
        char4.GetComponent<CharacterEntity>().damage = DataManager.Instance.GetData().characterStrengths[3] * 2;

        for(int i = 0; i < DataManager.Instance.GetData().level; i++)
        {
            enemyCount++;
            GameObject obj = Instantiate(enemy);
            obj.transform.position = spots[Random.Range(0, 5)];
            obj.GetComponent<CharacterEntity>().parent = this.gameObject;
            obj.GetComponent<CharacterEntity>().health = DataManager.Instance.GetData().level * 5;
            obj.GetComponent<CharacterEntity>().damage = DataManager.Instance.GetData().level;
        }
    }

    private void Update()
    {
        if(enemyCount == 0)
        {
            DataManager.Instance.GetData().level++;
            DataManager.Instance.JsonSave();

            SceneManager.LoadScene(0);
        }
    }
}
