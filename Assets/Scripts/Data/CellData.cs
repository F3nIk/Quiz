using System;

using UnityEngine;

[Serializable]
public class CellData
{
    [SerializeField] private string _identifier;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float _spriteRotation;

    public string Identifier => _identifier;
    public Sprite Sprite => _sprite;

    public float SpriteRotation => _spriteRotation;
}
