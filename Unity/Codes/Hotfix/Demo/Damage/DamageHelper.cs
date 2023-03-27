using System.Collections.Generic;

namespace ET
{
    [FriendClass(typeof(Bullet))]
    [FriendClass(typeof(Monster))]
    [FriendClass(typeof(GameComponent))]
    public static class DamageHelper
    {
        public static async ETTask BulletSingleAttackMonster(Scene currentscene,Bullet bullet,Monster monster,int PhysicsDamage,int MagicDamage,bool IsAP,float Multiplier)
        {
            if (bullet.BulletZone != monster.GetComponent<NumericComponent>().GetAsInt(NumericType.MonsterZone)) return;
            NumericComponent monsternumeric = monster.GetComponent<NumericComponent>();
            int hp = monsternumeric.GetAsInt(NumericType.MonsterHp);
            if (hp == 0) return;
            BuffHelper.MonsterAddBuff(new List<Monster>() { monster }, bullet.BuffId).Coroutine();
            int AllAttack = DamageHelper.ReturnValue(PhysicsDamage,MagicDamage, monster,IsAP,Multiplier);
            hp = hp - AllAttack;
            if (hp <= 0)
            {
                hp = 0;
                //抛出死亡事件    延时死亡
            }
            monsternumeric.SetNoEvent(NumericType.MonsterHp, hp);//监听生命数值 刷新怪物UI
            Game.EventSystem.PublishAsync(new EventType.ShowDamageValueMonster() { currentscene = currentscene, damagevalue = AllAttack, monster = monster}).Coroutine();
            Game.EventSystem.PublishAsync(new EventType.MonsterDeath() { Monster = monster, currentscene = currentscene, IsAdd = true }).Coroutine();
            await ETTask.CompletedTask;
        }
        public static async ETTask TowerSingleAttackMonster(Scene currentscene, Tower tower, Monster monster,int PhysicsDamage, int MagicDamage, bool IsAP, float Multiplier)
        {
            if (tower.GetComponent<NumericComponent>().GetAsInt(NumericType.TowerZone) != monster.GetComponent<NumericComponent>().GetAsInt(NumericType.MonsterZone)) return;
            NumericComponent monsternumeric = monster.GetComponent<NumericComponent>();
            int hp = monsternumeric.GetAsInt(NumericType.MonsterHp);
            if (hp == 0) return;
            BuffHelper.MonsterAddBuff(new List<Monster>() { monster }, tower.GetComponent<NumericComponent>().GetAsInt(NumericType.TowerBuffId)).Coroutine();
            int AllAttack = DamageHelper.ReturnValue(PhysicsDamage, MagicDamage, monster, IsAP, Multiplier);
            hp = hp - AllAttack;
            if (hp <= 0)
            {
                hp = 0;
                //抛出死亡事件    延时死亡
            }
            monsternumeric.SetNoEvent(NumericType.MonsterHp, hp);//监听生命数值 刷新怪物UI
            Game.EventSystem.PublishAsync(new EventType.ShowDamageValueMonster() { currentscene = currentscene, damagevalue = AllAttack, monster = monster }).Coroutine();
            Game.EventSystem.PublishAsync(new EventType.MonsterDeath() { Monster = monster, currentscene = currentscene, IsAdd = true }).Coroutine();
            await ETTask.CompletedTask;
        }
        public static async ETTask MonsterSingleAttackBase(Scene currentscene,Monster monster,Base baseitem)
        {
            NumericComponent monsternum = monster.GetComponent<NumericComponent>();
            NumericComponent basenum = baseitem.GetComponent<NumericComponent>();
            int basehp = basenum.GetAsInt(NumericType.BaseHp);
            int monsterattack = monsternum.GetAsInt(NumericType.MonsterAttack);
            basehp = basehp - monsterattack;
            monsternum.SetNoEvent(NumericType.MonsterHp, 0);
            if (basehp <= 0) basehp = 0;
            basenum.SetNoEvent(NumericType.BaseHp, basehp);
            await Game.EventSystem.PublishAsync(new EventType.ShowDamageValueBase() { currentscene = currentscene, damagevalue = monsterattack, baseitem = baseitem });
            await Game.EventSystem.PublishAsync(new EventType.MonsterDeath() { Monster = monster, currentscene = currentscene,IsAdd = false });
            if (basehp == 0)//基地爆炸游戏结束
            {
                GameComponent gameComponent = currentscene.GetComponent<GameComponent>();
                if (gameComponent == null || gameComponent.GameEnding == false) return;
                gameComponent.GameEnding = false;
                int basezone = baseitem.GetComponent<NumericComponent>().GetAsInt(NumericType.BaseZone);
                if (basezone == 1) await currentscene.GetComponent<GameComponent>().WinGame(2);
                if (basezone == 2) await currentscene.GetComponent<GameComponent>().WinGame(1);
            }
            await ETTask.CompletedTask;
        }
        public static async ETTask BulletRangeAttackMonster(Scene currentscene, Bullet bullet, List<Monster> monster,int PhysicsDamage,int MagicDamage, bool IsAP, float Multiplier)
        {
            foreach (Monster m in monster)
            {
                if (bullet.BulletZone != m.GetComponent<NumericComponent>().GetAsInt(NumericType.MonsterZone)) continue;
                NumericComponent monsternumeric = m.GetComponent<NumericComponent>();
                int hp = monsternumeric.GetAsInt(NumericType.MonsterHp);
                if (hp == 0) continue;
                BuffHelper.MonsterAddBuff(new List<Monster>() { m }, bullet.BuffId).Coroutine();
                int AllAttack = DamageHelper.ReturnValue(PhysicsDamage, MagicDamage, m, IsAP, Multiplier);
                hp = hp - AllAttack;
                if (hp <= 0)
                {
                    hp = 0;
                    //抛出死亡事件    延时死亡
                }
                monsternumeric.SetNoEvent(NumericType.MonsterHp, hp);//监听生命数值 刷新怪物UI
                Game.EventSystem.PublishAsync(new EventType.ShowDamageValueMonster() { currentscene = currentscene, damagevalue = AllAttack, monster = m }).Coroutine();
                Game.EventSystem.PublishAsync(new EventType.MonsterDeath() { Monster = m, currentscene = currentscene, IsAdd = true }).Coroutine();
            }
            await ETTask.CompletedTask;
        }
        public static async ETTask BuffAttackMonster(Scene currentscene,int PhysicsDamage,int MagicDamage,Monster monster)
        {
            NumericComponent monsternumeric = monster.GetComponent<NumericComponent>();
            int hp = monsternumeric.GetAsInt(NumericType.MonsterHp);
            if (hp == 0) return;
            int MonsterPhysicsDefence = monsternumeric.GetAsInt(NumericType.MonsterPhysicsDefense);//怪物物理防御
            int MonsterMagicDefence = monsternumeric.GetAsInt(NumericType.MonsterMagicDefense);//怪物法术防御
            int AllPhysicsAttack = PhysicsDamage - MonsterPhysicsDefence;
            if (AllPhysicsAttack <= 0) AllPhysicsAttack = 0;
            int AllMagicAttack = MagicDamage - MonsterMagicDefence;
            if (AllMagicAttack <= 0) AllMagicAttack = 0;
            int AllAttack = AllPhysicsAttack + AllMagicAttack;
            hp = hp - AllAttack;
            if (hp <= 0)
            {
                hp = 0;
                //抛出死亡事件    延时死亡
            }
            monsternumeric.SetNoEvent(NumericType.MonsterHp, hp);//监听生命数值 刷新怪物UI
            Game.EventSystem.PublishAsync(new EventType.ShowDamageValueMonster() { currentscene = currentscene, damagevalue = AllAttack, monster = monster }).Coroutine();
            Game.EventSystem.PublishAsync(new EventType.MonsterDeath() { Monster = monster, currentscene = currentscene, IsAdd = true }).Coroutine();

            await ETTask.CompletedTask;
        }
        public static int ReturnValue(int PhycsicDamage,int MagicDamage,Monster monster,bool IsAP = false,float Multiplier = 1)
        {

            NumericComponent monsternumeric = monster.GetComponent<NumericComponent>();
            int MonsterPhysicsDefence = monsternumeric.GetAsInt(NumericType.MonsterPhysicsDefense);//怪物物理防御
            int MonsterMagicDefence = monsternumeric.GetAsInt(NumericType.MonsterMagicDefense);//怪物法术防御
            int AllPhysicsAttack = 0;
            if (IsAP)
            {
                AllPhysicsAttack = PhycsicDamage;
            }
            else
            {
                AllPhysicsAttack = PhycsicDamage - MonsterPhysicsDefence;
            }
            if (AllPhysicsAttack <= 0) AllPhysicsAttack = 0;
            int AllMagicAttack = MagicDamage - MonsterMagicDefence;
            if (AllMagicAttack <= 0) AllMagicAttack = 0;
            int AllAttack = AllPhysicsAttack + AllMagicAttack;
            Log.Debug(((int)(AllAttack * Multiplier)).ToString());
            return (int)(AllAttack * Multiplier);

        }
    }
}
