using Leopotam.Ecs;
using UnityEngine;

public struct PlayerComponent
{
    public float rotationSpeed;
    public float speed;
    public float runSpeed;
    public float jumpForce;
    public LayerMask groundLayer;
    public bool isJumping;
    public float verticalVelocity;
}
public struct MovementInputComponent
{
    public float horizontalInput;
    public float verticalInput;
    public bool isRunning;
}
public struct GroundCheckComponent
{
    public Transform groundChecker;
    public CharacterController characterController; // Для хранения ссылки на CharacterController
}

public class PlayerSystem : IEcsRunSystem
{
    private EcsFilter<PlayerComponent, MovementInputComponent, GroundCheckComponent> _filter;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var player = ref _filter.Get1(i);
            ref var input = ref _filter.Get2(i);
            ref var groundCheck = ref _filter.Get3(i);

            // Считываем ввод
            UpdateInput(ref input);

            // Рассчитываем движение
            Vector3 movement = new Vector3(input.horizontalInput, 0, input.verticalInput);
            float currentSpeed = input.isRunning ? player.runSpeed : player.speed;
            Vector3 moveDir = movement.normalized * currentSpeed;

            // Обработка движения
            MovePlayer(moveDir, ref player, groundCheck);

            // Проверка на прыжок
            if (Input.GetKeyDown(KeyCode.Space) && Physics.CheckSphere(groundCheck.groundChecker.position, 0.3f, player.groundLayer))
            {
                StartJump(ref player);
            }

            // Обработка прыжка
            if (player.isJumping)
            {
                HandleJump(ref player, groundCheck);
            }
        }
    }

    private void UpdateInput(ref MovementInputComponent input)
    {
        input.horizontalInput = Input.GetAxis("Horizontal");
        input.verticalInput = Input.GetAxis("Vertical");
        input.isRunning = Input.GetKey(KeyCode.LeftShift);
    }

    private void MovePlayer(Vector3 moveDir, ref PlayerComponent player, GroundCheckComponent groundCheck)
    {
        Vector3 velocity = new Vector3(moveDir.x, player.verticalVelocity, moveDir.z);

        if (groundCheck.characterController.isGrounded)
        {
            player.verticalVelocity = 0; // Сбрасываем вертикальную скорость при приземлении
        }

        // Применяем движение
        groundCheck.characterController.Move(velocity * Time.deltaTime);
    }

    private void StartJump(ref PlayerComponent player)
    {
        player.isJumping = true;
        player.verticalVelocity = Mathf.Sqrt(player.jumpForce * -2f * Physics.gravity.y);
    }

    private void HandleJump(ref PlayerComponent player, GroundCheckComponent groundCheck)
    {
        player.verticalVelocity += Physics.gravity.y * Time.deltaTime;

        groundCheck.characterController.Move(new Vector3(0, player.verticalVelocity, 0) * Time.deltaTime);

        // Проверка на приземление
        if (Physics.CheckSphere(groundCheck.groundChecker.position, 0.3f, player.groundLayer))
        {
            player.isJumping = false;
            player.verticalVelocity = 0f;
        }
    }
}