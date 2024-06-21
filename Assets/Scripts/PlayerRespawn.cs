using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    //[SerializeField] private AudioClip checkpoint;
    private Transform currentCheckpoint;
    private Health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }

    public void Respawn()
    {
        playerHealth.Respawn(); //Restore player health and reset animation
        if (currentCheckpoint != null)
        {
            transform.position = currentCheckpoint.position; //Move player to checkpoint location
        }
        else
        {
            // Si no hay un checkpoint definido, mover al jugador a la posición inicial
            transform.position = Vector3.zero; // O a cualquier posición inicial deseada
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            //SoundManager.instance.PlaySound(checkpoint);
            collision.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FallDetector")
        {
            Respawn(); // Si el jugador sale de un trigger marcado como "FallDetector", hacer respawn
        }
    }
}
