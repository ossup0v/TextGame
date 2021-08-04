using System.Collections.Generic;
using TextGame.Attacks;
using TextGame.Map;

namespace TextGame.Controllers
{
    public interface IPlayerController
    {
        AttackBase GetWontAttack(List<AttackBase> availableAttacks);
        Point GetWontPosition(Point currentPosition);

    }
}