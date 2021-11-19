using Entitas;
using UnityEngine;

public static class BoardLogic
{
    public static int GetNextEmptyRow(Contexts contexts, Vector2Int position)
    {
        position.y -= 1;
        while (position.y >= 0)
        {
            var es = contexts.game.GetEntitiesWithPosition(position);
            if (es.Count == 0 || es.SingleEntity().isDestroyed)
                position.y -= 1;
        }

        return position.y + 1;
    }
}
