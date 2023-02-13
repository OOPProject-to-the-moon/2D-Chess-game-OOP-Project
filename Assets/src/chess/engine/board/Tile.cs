using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    #region params

    [Header("Tile Uniqe")]
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private GameObject highlight;

    [Space(3)] 
    [Header("Tile attribute")] 
    [SerializeField] private bool isWalkable;
    
    private string _type;
    private Vector2 _pos;

    public Piece OccupiedPiece;
    public bool Walkable => isWalkable && !OccupiedPiece;
    
    #endregion
    
    public void Init(bool isOffset, string type, Vector2 pos)
    {
        renderer.color = isOffset? baseColor : offsetColor;
        _type = type;
        _pos = pos;
    }

    #region Getter
    public string TileType()
    {
        return _type;
    }

    public Vector2 GetPos()
    {
        return _pos;
    }
    #endregion
    
    #region Mouse action

    private void OnMouseEnter()
    {
        highlight.SetActive(true);

    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }
    
    #endregion

    public void SetPiece(Piece piece)
    {
        if (piece.OccupiedTile)
        {
            piece.OccupiedTile.OccupiedPiece = null;
        }
        
        piece.transform.position = transform.position;
        OccupiedPiece = piece;
        piece.OccupiedTile = this;
    }
    
}
