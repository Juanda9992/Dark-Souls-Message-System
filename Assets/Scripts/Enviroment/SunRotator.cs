using UnityEngine;

public class SunRotator : MonoBehaviour
{
    [SerializeField] private float rotSpeed;
    void Update()
    {
        transform.Rotate(Vector3.right*rotSpeed * Time.deltaTime);
    }
}
