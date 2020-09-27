using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using DG.Tweening;

public class FieldSide : MonoBehaviour
{
    [SerializeField]
    private Rectangle[] tiles;

    private Rectangle GetTile((int, int) coord){
        return tiles[coord.Item1*3+coord.Item2];
    }

    public void GreenTile((int, int) coord){
        Rectangle tile = GetTile(coord);
        DOTween.To(()=> tile.Color, x=> tile.Color = x, Color.green, 0.25f).OnComplete(()=>
        DOTween.To(()=> tile.Color, x=> tile.Color = x, Color.white, 0.25f)).SetEase(Ease.InCirc);
    }

    public void RedTile((int, int) coord){
        Rectangle tile = GetTile(coord);
        DOTween.To(()=> tile.Color, x=> tile.Color = x, Color.red, 0.25f).OnComplete(()=>
        DOTween.To(()=> tile.Color, x=> tile.Color = x, Color.white, 0.25f)).SetEase(Ease.InCirc);
    }
}
