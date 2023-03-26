using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick floatingJoystick;
    private int index;
    private Vector3 moveVector;
    private CharacterController characterController;

    [HideInInspector] public Animator ch_animator;
    public float moveSpeed;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        ch_animator = GetComponent<Animator>();
    }

    void Update()
    {
        CharacterMove();

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
    }

    public void CharacterMove()
    {
        moveVector = Vector3.zero;
        moveVector.x = floatingJoystick.Horizontal * moveSpeed;
        moveVector.z = floatingJoystick.Vertical * moveSpeed;

        if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, moveSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);

            characterController.Move(moveVector * Time.deltaTime);
        }

        if (moveVector.x != 0 || moveVector.z != 0)
        {
            ch_animator.SetBool("Move", true);
        }
        else
        {
            ch_animator.SetBool("Move", false);
        }
    }
}

