using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEngine
{
    public class Advantage
    {
        private int amount = 0;
        private int whichPlayer = 0;

        public int Amount{
            get{
                return amount;
            }
        }

        public int Player{
            get{
                return whichPlayer;
            }
        }

        public void AddAdvantage(int player){
            Debug.Log("Adding advantage to " + player);
            if(whichPlayer==player){
                if(amount<3){
                    amount++;
                }
            }else{
                if(amount>0){
                    amount--;
                }else{
                    ChangeWhichPlayer();
                    amount++;
                }
            }
        }

        private void ChangeWhichPlayer(){
            whichPlayer = (whichPlayer==0)?1:0;
        }
    }
}

