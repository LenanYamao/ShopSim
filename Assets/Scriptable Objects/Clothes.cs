using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Slot { None, Head, Chest, Arm, Leg }
[CreateAssetMenu(menuName = "Scriptable Objects/Clothes")]
public class Clothes : ScriptableObject
{
    // Scriptable object to create clothes
    // If there's enough time, rename the class to items
    public Slot slot;
    public string clotheName;
    public float clothePrice;
    public Sprite itemIcon;

    [Header("Head")]
    public Sprite face;
    public Sprite hood;

    [Header("Chest")]
    public Sprite chest;
    public Sprite shoulderL;
    public Sprite shoulderR;
    public Sprite pelvis;

    [Header("Arm")]
    public Sprite wristL;
    public Sprite elbowL;
    public Sprite wristR;
    public Sprite elbowR;
    [Header("Leg")]
    public Sprite legL;
    public Sprite bootL;
    public Sprite legR;
    public Sprite bootR;

}
