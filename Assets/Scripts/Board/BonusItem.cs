using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : Item
{
    public enum eBonusType
    {
        NONE,
        HORIZONTAL,
        VERTICAL,
        ALL
    }

    public eBonusType ItemType;
    static Action<BonusItem>[] ActivateBonusActions = new Action<BonusItem>[] {
            null,
            ExplodeHorizontalLine,
            ExplodeVerticalLine,
            ExplodeBomb,
        };

    public void SetType(eBonusType type)
    {
        ItemType = type;
    }

    protected override string GetPrefabName()
    {
        return Constants.PREFAB_BONUS_NAMES[(int)ItemType];
    }

    internal override bool IsSameType(Item other)
    {
        BonusItem it = other as BonusItem;

        return it != null && it.ItemType == this.ItemType;
    }

    internal override void ExplodeView()
    {
        ActivateBonus();

        base.ExplodeView();
    }

    private void ActivateBonus()
    {
        ActivateBonusActions[(int)ItemType]?.Invoke(this);
    }

    private static void ExplodeBomb(BonusItem item)
    {
        List<Cell> list = new List<Cell>();
        if (item.Cell.NeighbourBottom) list.Add(item.Cell.NeighbourBottom);
        if (item.Cell.NeighbourUp) list.Add(item.Cell.NeighbourUp);
        if (item.Cell.NeighbourLeft)
        {
            list.Add(item.Cell.NeighbourLeft);
            if (item.Cell.NeighbourLeft.NeighbourUp)
            {
                list.Add(item.Cell.NeighbourLeft.NeighbourUp);
            }
            if (item.Cell.NeighbourLeft.NeighbourBottom)
            {
                list.Add(item.Cell.NeighbourLeft.NeighbourBottom);
            }
        }
        if (item.Cell.NeighbourRight)
        {
            list.Add(item.Cell.NeighbourRight);
            if (item.Cell.NeighbourRight.NeighbourUp)
            {
                list.Add(item.Cell.NeighbourRight.NeighbourUp);
            }
            if (item.Cell.NeighbourRight.NeighbourBottom)
            {
                list.Add(item.Cell.NeighbourRight.NeighbourBottom);
            }
        }

        for (int i = 0; i < list.Count; i++)
        {
            list[i].ExplodeItem();
        }
    }

    private static void ExplodeVerticalLine(BonusItem item)
    {
        List<Cell> list = new List<Cell>();

        Cell newcell = item.Cell;
        while (true)
        {
            Cell next = newcell.NeighbourUp;
            if (next == null) break;

            list.Add(next);
            newcell = next;
        }

        newcell = item.Cell;
        while (true)
        {
            Cell next = newcell.NeighbourBottom;
            if (next == null) break;

            list.Add(next);
            newcell = next;
        }


        for (int i = 0; i < list.Count; i++)
        {
            list[i].ExplodeItem();
        }
    }

    private static void ExplodeHorizontalLine(BonusItem item)
    {
        List<Cell> list = new List<Cell>();

        Cell newcell = item.Cell;
        while (true)
        {
            Cell next = newcell.NeighbourRight;
            if (next == null) break;

            list.Add(next);
            newcell = next;
        }

        newcell = item.Cell;
        while (true)
        {
            Cell next = newcell.NeighbourLeft;
            if (next == null) break;

            list.Add(next);
            newcell = next;
        }


        for (int i = 0; i < list.Count; i++)
        {
            list[i].ExplodeItem();
        }

    }
}
