using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[CreateAssetMenu(fileName = "PlayerData", menuName = "GameData/PlayerData")]
public class PlayerData : ScriptableObject
{
    public int hp;

    public float standSpeed;
    public float standHeight;

    public float crouchSpeed;
    public float crouchHeight;

    public float crawlSpeed;
    public float crawlHeight;
}
