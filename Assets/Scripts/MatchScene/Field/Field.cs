using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField]
    private FieldSide player1Side;

    [SerializeField]
    private FieldSide player2Side;  


    public void DoARandomGreen(int player){
        if(player == 0){
            player1Side.GreenTile(Maths.RandCoord());
        }else{
            player2Side.GreenTile(Maths.RandCoord());
        }
    } 

    public void DoARandomRed(int player){
        if(player == 0){
            player1Side.RedTile(Maths.RandCoord());
        }else{
            player2Side.RedTile(Maths.RandCoord());
        }
    } 


    public void DoAGreen(int player, (int, int) coord){
        if(player == 0){
            player1Side.GreenTile(coord);
        }else{
            player2Side.GreenTile(coord);
        }
    } 

    public void DoARed(int player, (int, int) coord){
        if(player == 0){
            player1Side.RedTile(coord);
        }else{
            player2Side.RedTile(coord);
        }
    } 
}
