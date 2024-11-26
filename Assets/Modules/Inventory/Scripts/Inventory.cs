using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Modules.Inventories
{
    public sealed class Inventory<T>
    {
        public event Action<T, int> OnCellAdded;
        public event Action<T, int> OnCellChanged;
        public event Action<T> OnCellRemoved;

        [ShowInInspector]
        private readonly Dictionary<T, int> items = new();

        public Inventory()
        {
        }

        public Inventory(params KeyValuePair<T, int>[] items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            for (int i = 0, length = items.Length; i < length; i++)
            {
                (T key, int value) = items[i];
                this.AddItems(key, value);
            }
        }

        [Button]
        public bool AddItems(T item, int range)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (range < 0)
                throw new ArgumentOutOfRangeException(nameof(range));

            if (range == 0)
                return false;

            if (this.items.TryGetValue(item, out int count))
            {
                count += range;
                this.items[item] = count;
                this.OnCellChanged?.Invoke(item, count);
            }
            else
            {
                this.items.Add(item, count);
                this.OnCellAdded?.Invoke(item, count);
            }

            return true;
        }

        [Button]
        public bool RemoveItem(T item)
        {
            return this.RemoveItems(item, 1);
        }

        [Button]
        public bool RemoveItems(T item, int range)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (range < 0)
                throw new ArgumentOutOfRangeException(nameof(range));

            if (range == 0)
                return false;

            if (!this.items.TryGetValue(item, out int count))
                return false;

            if (count < range)
                return false;

            count -= range;
            if (count > 0)
            {
                this.items[item] = count;
                this.OnCellChanged?.Invoke(item, count);
            }
            else
            {
                this.items.Remove(item);
                this.OnCellRemoved?.Invoke(item);
            }

            return true;
        }

        public bool HasItem(T item)
        {
            return this.HasItems(item, 1);
        }

        public bool HasItems(T item, int count)
        {
            return item == null
                ? throw new ArgumentNullException(nameof(item))
                : this.items.TryGetValue(item, out int current) && current >= count;
        }

        public int GetCount(T item)
        {
            return item == null
                ? throw new ArgumentNullException(nameof(item))
                : this.items.TryGetValue(item, out int count)
                    ? count
                    : 0;
        }
        
        public IReadOnlyCollection<KeyValuePair<T, int>> GetItems()
        {
            return this.items;
        }
    }
}