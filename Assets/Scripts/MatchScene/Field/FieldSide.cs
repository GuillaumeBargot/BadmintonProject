using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using DG.Tweening;
using GameEngine;

public class FieldSide : MonoBehaviour
{
    [SerializeField]
    private Rectangle[] tiles;

    private Rectangle GetTile(ShotCoord coord){
        return tiles[coord.Index];
    }

    public void GreenTile(ShotCoord coord){
        Rectangle tile = GetTile(coord);
        DOTween.To(()=> tile.Color, x=> tile.Color = x, Color.green, 0.25f).OnComplete(()=>
        DOTween.To(()=> tile.Color, x=> tile.Color = x, Color.white, 0.25f)).SetEase(Ease.InCirc);
    }

    public void RedTile(ShotCoord coord){
        Rectangle tile = GetTile(coord);
        DOTween.To(()=> tile.Color, x=> tile.Color = x, Color.red, 0.25f).OnComplete(()=>
        DOTween.To(()=> tile.Color, x=> tile.Color = x, Color.white, 0.25f)).SetEase(Ease.InCirc);
    }
}
