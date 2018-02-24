//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameStateContext {

    public GameStateEntity scoreListenerEntity { get { return GetGroup(GameStateMatcher.ScoreListener).GetSingleEntity(); } }
    public ScoreListenerComponent scoreListener { get { return scoreListenerEntity.scoreListener; } }
    public bool hasScoreListener { get { return scoreListenerEntity != null; } }

    public GameStateEntity SetScoreListener(System.Collections.Generic.List<IScoreListener> newValue) {
        if (hasScoreListener) {
            throw new Entitas.EntitasException("Could not set ScoreListener!\n" + this + " already has an entity with ScoreListenerComponent!",
                "You should check if the context already has a scoreListenerEntity before setting it or use context.ReplaceScoreListener().");
        }
        var entity = CreateEntity();
        entity.AddScoreListener(newValue);
        return entity;
    }

    public void ReplaceScoreListener(System.Collections.Generic.List<IScoreListener> newValue) {
        var entity = scoreListenerEntity;
        if (entity == null) {
            entity = SetScoreListener(newValue);
        } else {
            entity.ReplaceScoreListener(newValue);
        }
    }

    public void RemoveScoreListener() {
        scoreListenerEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameStateEntity {

    public ScoreListenerComponent scoreListener { get { return (ScoreListenerComponent)GetComponent(GameStateComponentLookup.ScoreListener); } }
    public bool hasScoreListener { get { return HasComponent(GameStateComponentLookup.ScoreListener); } }

    public void AddScoreListener(System.Collections.Generic.List<IScoreListener> newValue) {
        var index = GameStateComponentLookup.ScoreListener;
        var component = CreateComponent<ScoreListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceScoreListener(System.Collections.Generic.List<IScoreListener> newValue) {
        var index = GameStateComponentLookup.ScoreListener;
        var component = CreateComponent<ScoreListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveScoreListener() {
        RemoveComponent(GameStateComponentLookup.ScoreListener);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameStateMatcher {

    static Entitas.IMatcher<GameStateEntity> _matcherScoreListener;

    public static Entitas.IMatcher<GameStateEntity> ScoreListener {
        get {
            if (_matcherScoreListener == null) {
                var matcher = (Entitas.Matcher<GameStateEntity>)Entitas.Matcher<GameStateEntity>.AllOf(GameStateComponentLookup.ScoreListener);
                matcher.componentNames = GameStateComponentLookup.componentNames;
                _matcherScoreListener = matcher;
            }

            return _matcherScoreListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameStateEntity {

    public void AddScoreListener(IScoreListener value) {
        var listeners = hasScoreListener
            ? scoreListener.value
            : new System.Collections.Generic.List<IScoreListener>();
        listeners.Add(value);
        ReplaceScoreListener(listeners);
    }

    public void RemoveScoreListener(IScoreListener value) {
        var listeners = scoreListener.value;
        listeners.Remove(value);
        if (listeners.Count == 0) {
            RemoveScoreListener();
        } else {
            ReplaceScoreListener(listeners);
        }
    }
}
