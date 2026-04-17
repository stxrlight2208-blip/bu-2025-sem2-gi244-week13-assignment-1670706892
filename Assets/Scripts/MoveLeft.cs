using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        GameObject player = GameObject.Find("Player");
        bool isGameOver = player.GetComponent<PlayerController>().gameOver;

        if (isGameOver)
        {
            return;
        }

        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
