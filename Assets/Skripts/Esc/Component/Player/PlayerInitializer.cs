using Leopotam.Ecs;
using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;

    void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        // Регистрация систем
        _systems.Add(new PlayerSystem());
        _systems.Init();

        // Создание сущности игрока
        CreatePlayerEntity();
    }

    void Update()
    {
        _systems.Run();
    }

    private void CreatePlayerEntity()
    {
        var playerEntity = _world.NewEntity();

        ref var player = ref playerEntity.Get<PlayerComponent>();
        player.rotationSpeed = 10f;
        player.speed = 5f;
        player.runSpeed = 10f;
        player.jumpForce = 7f;
        player.groundLayer = LayerMask.GetMask("Ground");
        player.isJumping = false;
        player.verticalVelocity = 0f;

        ref var movementInput = ref playerEntity.Get<MovementInputComponent>();

        ref var groundCheck = ref playerEntity.Get<GroundCheckComponent>();
        groundCheck.groundChecker = transform; // Предполагаем, что GroundChecker — это текущий объект
        groundCheck.characterController = groundCheck.groundChecker.GetComponent<CharacterController>(); // Инициализация
    }

    private void OnDestroy()
    {
        _systems.Destroy();
        _world.Destroy();
    }
}