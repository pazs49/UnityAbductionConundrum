using UnityEngine;

public interface IEnemy
{
  GameObject DeathEffect { get; set; }
  bool IsActive { get; set; }
  float Health { get; set; }
  float AttackPower { get; set; }
  float AttackInterval { get; set; }
  State currentState { get; set; }
  void State(State currentState);
  void Attack();
  void Idle();
}
public enum State { Idle, Attacking, Dead }