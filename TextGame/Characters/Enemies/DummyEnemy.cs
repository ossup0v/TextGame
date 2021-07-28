﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Attacks;
using TextGame.Attacks.Spells;
using TextGame.Map;
using TextGame.UI;

namespace TextGame.Characters.Enemies
{
    public class DummyEnemy : Character
    {
        private DummyEnemy(char symbolOnMap, Point startPosition)
        {
            Position = startPosition;
            SymbolOnMap = symbolOnMap;
        }

        public override void FillDamage(double damage)
        {
            if (damage < 0)
            {
                ConsoleManager.LogError($"{nameof(Player)} getting damage less then zero! {nameof(damage)}: {damage}");
            }

            var defence = GetStat(StatKind.Defence);
            var armor = GetStat(StatKind.Armor);
            var finalDamage = damage * ((100 - defence) / 100) - armor;

            ChangeBaseStat(StatKind.Health, finalDamage, ActionKind.Decreace);
        }

        public override double GetFinalHitDamage()
        {
            var attack = GetStat(StatKind.Attack);
            var attackPower = GetStat(StatKind.AttackPower);

            return attack * attackPower;
        }

        public override Point GetWontPointToMove()
        {
            return Position; // TODO
        }

        public static DummyEnemy CreateEnemy( 
            char symbol
            , Point position
            , double health = 20
            , double attack = 10
            , double attackPower = 2
            , double defence = 10)
        {
            return new DummyEnemy(symbol, position)
            {
                AvailableAttacks = new List<AttackBase> { new FireBallSpell() },
                BaseStats = new Dictionary<StatKind, double>
                {
                    [StatKind.Health] = health,
                    [StatKind.Attack] = attack,
                    [StatKind.AttackPower] = attackPower,
                    [StatKind.Defence] = defence
                }
            };
        }
    }
}