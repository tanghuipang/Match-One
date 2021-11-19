using Entitas;
using System.Collections.Generic;

public sealed class GameSystems : Feature
{
    public GameSystems(Contexts contexts)
    {
        // Input
        Add(new InputSystem(contexts));
        Add(new ProcessInputSystem(contexts));

        // Update
        Add(new BoardSystem(contexts));
        Add(new FallSystem(contexts));
        Add(new FillSystem(contexts));
        Add(new ScoreSystem(contexts));

        // View
        Add(new AddViewSystem(contexts));

        // Events (Generated)
        Add(new InputEventSystems(contexts));
        Add(new GameEventSystems(contexts));
        Add(new GameStateEventSystems(contexts));

        // Cleanup (Generated, only with Entitas Asset Store version)
        Add(new InputCleanupSystems(contexts));
        Add(new GameCleanupSystems(contexts));
    }
}

public sealed class InputCleanupSystems : Feature {

    public InputCleanupSystems(Contexts contexts) {
        Add(new DestroyInputInputSystem(contexts));
    }
}

public sealed class DestroyInputInputSystem : ICleanupSystem {

    readonly IGroup<InputEntity> _group;
    readonly List<InputEntity> _buffer = new List<InputEntity>();

    public DestroyInputInputSystem(Contexts contexts) {
        _group = contexts.input.GetGroup(InputMatcher.Input);
    }

    public void Cleanup() {
        foreach (var e in _group.GetEntities(_buffer)) {
            e.Destroy();
        }
    }
}

public sealed class DestroyDestroyedGameSystem : ICleanupSystem {

    readonly IGroup<GameEntity> _group;
    readonly List<GameEntity> _buffer = new List<GameEntity>();

    public DestroyDestroyedGameSystem(Contexts contexts) {
        _group = contexts.game.GetGroup(GameMatcher.Destroyed);
    }

    public void Cleanup() {
        foreach (var e in _group.GetEntities(_buffer)) {
            e.Destroy();
        }
    }
}

public sealed class GameCleanupSystems : Feature
{
    public GameCleanupSystems(Contexts contexts)
    {
        Add(new DestroyDestroyedGameSystem(contexts));
    }
}
