using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SampleGame
{
    //Нельзя менять!
    internal sealed class Inventory : IInventory
    {
        public event Action<IInventory.ICell> OnCellAdded;
        public event Action<IInventory.ICell> OnCellRemoved;
        public event Action OnCellsChanged;

        [ShowInInspector]
        private readonly Dictionary<InventoryItem, Cell> items = new();

        [Button]
        internal void SetItems(params Cell[] cells)
        {
            this.items.Clear();

            for (int i = 0, length = cells.Length; i < length; i++)
            {
                Cell cell = cells[i];
                if (cell.Count > 0)
                {
                    this.items[cell.Item] = new Cell(cell);
                }
            }

            this.OnCellsChanged?.Invoke();
        }

        [Button]
        public void AddItems(InventoryItem item, int range)
        {
            if (this.items.TryGetValue(item, out Cell cell))
            {
                cell.Count += range;
            }
            else
            {
                cell = new Cell(item, range);
                this.items.Add(item, cell);
                this.OnCellAdded?.Invoke(cell);
            }
        }

        public void RemoveItem(InventoryItem item)
        {
            this.RemoveItems(item, 1);
        }

        [Button]
        public void RemoveItems(InventoryItem item, int range)
        {
            if (!this.items.TryGetValue(item, out Cell cell))
            {
                throw new Exception($"Can't remove items with name: {item.name}. Not exists!");
            }

            if (cell.Count < range)
            {
                throw new Exception(
                    $"Can't remove items with name: {item.name}. Range {range} more then count {cell.Count}!");
            }

            cell.Count -= range;

            if (cell.Count > 0)
            {
                return;
            }

            this.items.Remove(cell.Item);
            this.OnCellRemoved?.Invoke(cell);
        }

        public bool HasItem(InventoryItem item)
        {
            return this.HasItems(item, 1);
        }

        [Button]
        public bool HasItems(InventoryItem item, int count)
        {
            return this.items.TryGetValue(item, out Cell cell) && cell.Count >= count;
        }

        [Button]
        public int GetCount(InventoryItem item)
        {
            if (this.items.TryGetValue(item, out Cell cell))
            {
                return cell.Count;
            }

            return 0;
        }

        public IEnumerator<IInventory.ICell> GetEnumerator()
        {
            return this.items.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        [Serializable]
        internal sealed class Cell : IInventory.ICell
        {
            public event Action<int> OnCountChanged;

            public InventoryItem Item
            {
                get { return _item; }
            }

            public int Count
            {
                get { return _count; }
                set
                {
                    _count = value;
                    this.OnCountChanged?.Invoke(_count);
                }
            }

            [SerializeField]
            private InventoryItem _item;

            [SerializeField]
            private int _count;

            public Cell(InventoryItem item, int count)
            {
                _item = item;
                _count = count;
            }

            public Cell(Cell cell)
            {
                _item = cell._item;
                _count = cell._count;
            }
        }
    }
}