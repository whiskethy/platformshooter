using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimDirections
{
    //TODO: Make this less annoying to use
    public struct aimRange
    {
        public float botRange;
        public float trueAim;
        public float topRange;
        

        public aimRange(float bot, float top, float aim)
        {
            this.botRange = bot;
            this.topRange = top;
            this.trueAim = aim;
        }
    }
    private static float div = (Mathf.PI * 2) / 16;
    //x = bot range, y = top range
    public aimRange right = new aimRange (div * 15, div * 1, 0.0f);
    public aimRange upRight = new aimRange (div * 1, div * 3, div * 2);
    public aimRange up = new aimRange (div * 3, div * 5, div * 4);
    public aimRange upLeft = new aimRange (div * 5, div * 7, div * 6);
    public aimRange left = new aimRange (div * 7, div * 9, div * 8);
    public aimRange downLeft = new aimRange (div * 9, div * 11, div * 10);
    public aimRange down = new aimRange (div * 11, div * 13, div * 12);
    public aimRange downRight = new aimRange (div * 13, div * 15, div * 14);
}
