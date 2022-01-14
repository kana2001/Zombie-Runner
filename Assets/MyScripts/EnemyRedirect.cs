using UnityEngine;
public class EnemyRedirect : MonoBehaviour
{
    public GameObject Player;
    public float movementSpeed = 4;

    void Update()
    {
        transform.LookAt(Player.transform);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;

       

    }
}