using System;
using System.Collections.Generic;
using System.Linq;

using Mathematics.Extentions;

namespace Mathematics.Common
{
	public sealed class BinaryTree : BinaryTreeItem
	{
		private int _maxLevel;

		private readonly Dictionary<int, List<BinaryTreeItem>> _levels = new Dictionary<int, List<BinaryTreeItem>>();

		public BinaryTree(int value)
		{
			Value = value;
		}

		public BinaryTree(string rawInput)
		{
			var lines = rawInput.Split(new [] {"\r\n"}, StringSplitOptions.None);
			Value = Convert.ToInt32(lines[0]);
			lines.Skip(1).ForEach(x => AddLevel(x.Split(' ').Select(y => Convert.ToInt32(y)).ToArray()));
		}

		public override int Level { get { return 0; } }
		public override int Index { get { return 0; } }

		public BinaryTree AddLevel(params int[] items)
		{
			if (++_maxLevel != items.Length-1)
				throw new ArgumentException("Expected " + (items.Length - 1) + " items in the array for level " + _maxLevel);

			if (_maxLevel == 1)
			{
				Left = new BinaryTreeItem { Value = items[0], Level = _maxLevel, Index = 0 };
				Right = new BinaryTreeItem { Value = items[1], Level = _maxLevel, Index = 1 };
				_levels.Add(_maxLevel, new List<BinaryTreeItem> { Left, Right});
			}
			else
			{
				_levels.Add(_maxLevel, new List<BinaryTreeItem>());
				for (int i = 0; i < items.Length; i++)
				{
					var treeItem = new BinaryTreeItem { Value = items[i], Level = _maxLevel, Index = i };
					_levels[_maxLevel].Add(treeItem);
					if (i != 0)
						FindRightParentTreeItemForIndex(_maxLevel, i - 1).Right = treeItem;
					if (i != (items.Length-1))
						FindRightParentTreeItemForIndex(_maxLevel, i).Left = treeItem;
				}
			}
			return this;
		}

		private BinaryTreeItem FindRightParentTreeItemForIndex(int targetChildLevel, int i)
		{
			BinaryTreeItem parentItem = this;
			for (int level = 0; level < targetChildLevel - 1; level++)
			{
				parentItem = (level < (targetChildLevel - i - 1)) ? parentItem.Left : parentItem.Right;
			}
			return parentItem;
		}

		public int FindMaxPath()
		{
			int level = 1;
			List<BinaryTreeItem> levelItems;
			var calculatedLevelValues = new List<List<int>> {new List<int>{Value}};

			do
			{
				levelItems = _levels[level];

				var newValues = new List<List<int>>();
				for (int i = 0; i < levelItems.Count; i++)
				{
					var levelItem = levelItems[i];
					var currentValues = new List<int>();
					if (i != 0)
						currentValues.AddRange(calculatedLevelValues[i-1].Select(x => x + levelItem.Value));
					if (i != (levelItems.Count-1))
						currentValues.AddRange(calculatedLevelValues[i].Select(x => x + levelItem.Value));

					newValues.Add(new List<int> {currentValues.Max()});
				}

				calculatedLevelValues = newValues;
				
			} while (++level <= _maxLevel);

			return calculatedLevelValues.SelectMany(x => x).Max();
		}
	}

	public class BinaryTreeItem : IBinaryTreeItem
	{
		public virtual int Level { get; set; }
		public virtual int Index { get; set; }
		public virtual int Value { get; set; }

		public int Key { get { return 100000*Level + Index; } }

		public BinaryTreeItem Left { get; set; }
		public BinaryTreeItem Right { get; set; }

		public override string ToString()
		{
			return Value.ToString();
		}
	}

	internal interface IBinaryTreeItem
	{
		int Level { get; }
		int Index { get; }

		BinaryTreeItem Left { get; }
		BinaryTreeItem Right { get; }
	}
}