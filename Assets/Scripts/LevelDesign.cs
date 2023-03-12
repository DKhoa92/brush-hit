using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesign
{
    // struct Level
    // {
    //     Color firstColor;
    //     Color secondColor;
    // }
    public static Level LEVEL_1 = new Level(
        1,
        "#FF0000",
        "#FFFF00",
        new Platform[]{
            new Platform(GameDefine.PLATFORM_1, false, 0, 0, new Vector3(0,0,0)),
            new Platform(GameDefine.PLATFORM_1, false, 1, 1, new Vector3(10,0,0)),
            new Platform(GameDefine.PLATFORM_1, false, 1, 1, new Vector3(0,0,10)),
            new Platform(GameDefine.PLATFORM_1, false, 1, 1, new Vector3(10,0,10))
        },
        new Vector3(10,1,10)
    );
    public static Level LEVEL_2 = new Level(
        2,
        "#FFFF00",
        "#FF0000",
        new Platform[]{
            new Platform(GameDefine.PLATFORM_1, false, 0, 0, new Vector3(0,0,0)),
            new Platform(GameDefine.PLATFORM_1, false, 1, 1, new Vector3(10,0,0)),
            new Platform(GameDefine.PLATFORM_1, false, 1, 1, new Vector3(0,0,10)),
            new Platform(GameDefine.PLATFORM_1, false, 1, 1, new Vector3(10,0,10)),
            new Platform(GameDefine.PLATFORM_2, false, 1, 1, new Vector3(-10,0,0)),
            new Platform(GameDefine.PLATFORM_2, false, 1, 1, new Vector3(-10,0,10)),
            new Platform(GameDefine.PLATFORM_2, false, 1, 1, new Vector3(25,0,0)),
            new Platform(GameDefine.PLATFORM_2, false, 1, 1, new Vector3(25,0,10)),
        },
        new Vector3(0,1,0)
    );

    public static Level[] ARR_LEVEL = new Level[]{
        LEVEL_1,
        LEVEL_2,
    };
}
