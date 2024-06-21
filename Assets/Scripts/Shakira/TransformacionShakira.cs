using UnityEngine;

public class TransformacionShakira : MonoBehaviour
{
    public GameObject shakira;
    public GameObject shakiraLoba;
    public GameObject dustPrefab; // Referencia al prefab Dust
    public float dustOffsetZ = -2.0f; // Desplazamiento en el eje Z para el prefab Dust

    public float cooldownDuration = 5.0f; // Duración del cooldown en segundos
    private float cooldownTimer = 0.0f;

    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.X) && cooldownTimer <= 0)
        {
            // Guardar la posición actual de Shakira
            Vector3 transformPosition = shakira.transform.position;

            // Desactivar Shakira y activar Shakira Loba
            shakira.SetActive(false);
            shakiraLoba.SetActive(true);
            shakiraLoba.transform.position = transformPosition; // Posicionar en la posición de Shakira

            // Ajustar la posición para el prefab Dust por encima de Shakira en el eje Z
            Vector3 dustPosition = transformPosition + new Vector3(0, 0, dustOffsetZ);

            // Instanciar el prefab Dust en la posición ajustada
            Instantiate(dustPrefab, dustPosition, Quaternion.identity);

            // Iniciar el cooldown
            cooldownTimer = cooldownDuration;
        }
    }

    // Método para obtener el progreso del cooldown normalizado
    public float GetCooldownNormalized()
    {
        return Mathf.Clamp01(cooldownTimer / cooldownDuration);
    }
}
