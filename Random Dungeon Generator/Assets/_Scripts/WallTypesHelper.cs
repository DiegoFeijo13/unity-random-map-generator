using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WallType : int
{
    Vertical = 0,
    Horizontal = 1,
    LeftUpCorner = 2,
    LeftDownCorner = 3,
    RightUpCorner = 4,
    RightDownCorner = 5,

    //Three directions
    UpDownLeft = 6,
    UpDownRight = 7,

    //Four directions
    UpDownLeftRight = 8
}

public static class WallTypesHelper
{
    public static WallType GetWallType(string binaryType)
    {
        var typeAsInt = Convert.ToInt32(binaryType, 2);
        if (vertical.Contains(typeAsInt))
            return WallType.Vertical;
        if (horizontal.Contains(typeAsInt))
            return WallType.Horizontal;
        if (leftUpCorner.Contains(typeAsInt))
            return WallType.LeftUpCorner;
        if (leftDownCorner.Contains(typeAsInt))
            return WallType.LeftDownCorner;
        if (rightUpCorner.Contains(typeAsInt))
            return WallType.RightUpCorner;
        if (rightDownCorner.Contains(typeAsInt))
            return WallType.RightDownCorner;

        //Three
        if (upDownLeft.Contains(typeAsInt))
            return WallType.UpDownLeft;
        if (upDownRight.Contains(typeAsInt))
            return WallType.UpDownRight;

        //Four
        if (upDownLeftRight.Contains(typeAsInt))
            return WallType.UpDownLeftRight;


        //Default
        return WallType.Horizontal;

    }

    private static HashSet<int> vertical = new HashSet<int>
    {
        0b1010,
        0b1000,
        0b0010,
        0b1110,
        0b1011,
    };

    private static HashSet<int> horizontal = new HashSet<int>
    {
        0b0101,
        0b0001,
        0b0100,
        0b1101,
        0b0111,
    };

    public static HashSet<int> leftUpCorner = new HashSet<int>
    {
        0b0110
    };

    public static HashSet<int> leftDownCorner = new HashSet<int>
    {
        0b1100
    };

    public static HashSet<int> rightUpCorner = new HashSet<int>
    {
        0b0011
    };

    public static HashSet<int> rightDownCorner = new HashSet<int>
    {
        0b1001
    };

    public static HashSet<int> upDownLeft = new HashSet<int>
    {
        0b1110,
    };

    public static HashSet<int> upDownRight= new HashSet<int>
    {
        0b1011,
    };

    public static HashSet<int> upDownLeftRight = new HashSet<int>
    {
        0b1111,
    };

    public static HashSet<int> wallTop = new HashSet<int>
    {
        0b1111,
        0b0110,
        0b0011,
        0b0010,
        0b1010,
        0b1100,
        0b1110,
        0b1011,
        0b0111
    };

    public static HashSet<int> wallSideLeft = new HashSet<int>
    {
        0b0100
    };

    public static HashSet<int> wallSideRight = new HashSet<int>
    {
        0b0001
    };

    public static HashSet<int> wallBottm = new HashSet<int>
    {
        0b1000
    };

    public static HashSet<int> wallInnerCornerDownLeft = new HashSet<int>
    {
        0b11110001,
        0b11100000,
        0b11110000,
        0b11100001,
        0b10100000,
        0b01010001,
        0b11010001,
        0b01100001,
        0b11010000,
        0b01110001,
        0b00010001,
        0b10110001,
        0b10100001,
        0b10010000,
        0b00110001,
        0b10110000,
        0b00100001,
        0b10010001
    };

    public static HashSet<int> wallInnerCornerDownRight = new HashSet<int>
    {
        0b11000111,
        0b11000011,
        0b10000011,
        0b10000111,
        0b10000010,
        0b01000101,
        0b11000101,
        0b01000011,
        0b10000101,
        0b01000111,
        0b01000100,
        0b11000110,
        0b11000010,
        0b10000100,
        0b01000110,
        0b10000110,
        0b11000100,
        0b01000010

    };

    public static HashSet<int> wallDiagonalCornerDownLeft = new HashSet<int>
    {
        0b01000000
    };

    public static HashSet<int> wallDiagonalCornerDownRight = new HashSet<int>
    {
        0b00000001
    };

    public static HashSet<int> wallDiagonalCornerUpLeft = new HashSet<int>
    {
        0b00010000,
        0b01010000,
    };

    public static HashSet<int> wallDiagonalCornerUpRight = new HashSet<int>
    {
        0b00000100,
        0b00000101
    };

    public static HashSet<int> wallFull = new HashSet<int>
    {
        0b1101,
        0b0101,
        0b1101,
        0b1001

    };

    public static HashSet<int> wallFullEightDirections = new HashSet<int>
    {
        0b00010100,
        0b11100100,
        0b10010011,
        0b01110100,
        0b00010111,
        0b00010110,
        0b00110100,
        0b00010101,
        0b01010100,
        0b00010010,
        0b00100100,
        0b00010011,
        0b01100100,
        0b10010111,
        0b11110100,
        0b10010110,
        0b10110100,
        0b11100101,
        0b11010011,
        0b11110101,
        0b11010111,
        0b11010111,
        0b11110101,
        0b01110101,
        0b01010111,
        0b01100101,
        0b01010011,
        0b01010010,
        0b00100101,
        0b00110101,
        0b01010110,
        0b11010101,
        0b11010100,
        0b10010101

    };

    public static HashSet<int> wallBottmEightDirections = new HashSet<int>
    {
        0b01000001
    };

}

