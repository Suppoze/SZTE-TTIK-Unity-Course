using UnityEngine;

public class BulletDestroyScript : MonoBehaviour
{
    public float LifeSpanInSeconds;

    private void OnEnable()
    {
        Invoke("Destroy", LifeSpanInSeconds);
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}