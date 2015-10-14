using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MemoryProfilerWindow;
using Treemap;
using UnityEditor.Graphs;
using UnityEngine;

namespace Assets.Editor.Treemap
{
    public class Item : IComparable<Item>
    {
        public Group _group;
        public Rect _position;
        public int _index;

        public ThingInMemory _thingInMemory;

        public int memorySize { get { return _thingInMemory.size; } }
        public string name { get { return _thingInMemory.caption; } }
        public Color color { get { return _group.color; } }

        public Item(ThingInMemory thingInMemory, Group group)
        {
            _thingInMemory = thingInMemory;
            _group = group;
        }

        public int CompareTo(Item other)
        {
            return (int)(_group != other._group ? other._group.totalMemorySize - _group.totalMemorySize : other.memorySize - memorySize);
        }
    }
}
