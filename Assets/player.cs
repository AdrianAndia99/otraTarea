using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class player : MonoBehaviour
{
    public GameObject objectToDestroy;
    public UnityEvent onDestroyObject;

    Vector2 movimiento;

    [Header("Rotacion y velocidad")]
    [SerializeField] float velocidadMovimiento = 3.0f;
    [SerializeField] float velocidadRotacion;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 direction = new Vector3(movimiento.x, 0, movimiento.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref velocidadRotacion, 0.1f);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            rb.MovePosition(transform.position + moveDirection * velocidadMovimiento * Time.deltaTime);
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movimiento = context.ReadValue<Vector2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objectToDestroy)
        {
            Destroy(objectToDestroy);
            onDestroyObject.Invoke();
        }
    }
}
