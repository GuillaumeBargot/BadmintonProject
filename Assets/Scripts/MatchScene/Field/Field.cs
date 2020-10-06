using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using DG.Tweening;

public class Field : MonoBehaviour
{
    [SerializeField]
    private FieldSide playerSide;

    [SerializeField]
    private FieldSide cpuSide;  

    [SerializeField]
    private Vector3[] cpuSideCoordinates;

    [SerializeField]
    private Vector3[] p1SideCoordinates;

    [SerializeField]
    private Transform shotLineParent;

    [SerializeField]
    private Line shotLinePrefab;

    [SerializeField]
    private Disc player;

    [SerializeField]
    private Disc cpu;
    


    public void DoARandomGreen(int player){
        if(player == 0){
            playerSide.GreenTile(Maths.RandCoord());
        }else{
            cpuSide.GreenTile(Maths.RandCoord());
        }
    } 

    public void DoARandomRed(int player){
        if(player == 0){
            playerSide.RedTile(Maths.RandCoord());
        }else{
            cpuSide.RedTile(Maths.RandCoord());
        }
    } 


    public void DoAGreen(int player, (int, int) coord){
        if(player == 0){
            playerSide.GreenTile(coord);
        }else{
            cpuSide.GreenTile(coord);
        }
    } 

    public void DoARed(int player, (int, int) coord){
        if(player == 0){
            playerSide.RedTile(coord);
        }else{
            cpuSide.RedTile(coord);
        }
    } 

    public void DoAShot(int indexFrom, int indexTo, int playerShooting){
        Vector3 from = new Vector3();
        Vector3 to = new Vector3();
        if(playerShooting==0){
            from = cpuSideCoordinates[indexFrom];
            to = p1SideCoordinates[indexTo];
            MovePlayer(player,from);
            MovePlayer(cpu,to);
        }else{
            from = p1SideCoordinates[indexFrom];
            to = cpuSideCoordinates[indexTo];
            MovePlayer(player, to);
            MovePlayer(cpu,from);
        }
        AnimateShot(from,to);
    }

    private void AnimateShot(Vector3 from, Vector3 to){
        Line shotLine = Instantiate(shotLinePrefab,Vector3.zero, Quaternion.identity, shotLineParent);
        shotLine.transform.localPosition = Vector3.zero;
        shotLine.Start = from;
        shotLine.End = from;
        DOTween.To(()=> shotLine.End, x=> shotLine.End = x, to, 0.25f).SetEase(Ease.InFlash).OnComplete(()=>Destroy(shotLine.gameObject));
    }

    private void MovePlayer(Disc disc, Vector3 to){
        disc.transform.DOLocalMove(to,0.25f).SetEase(Ease.InCirc);
    }
}
