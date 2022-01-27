using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Laba_6._5
{
    public abstract class TreeObserver
    {
        public abstract void SubjectChanged();
    }

    public class Tree : TreeObserver
    {
        private Container<Shape> objects;                              //дерево наблюдает за объектами
        private TreeView tree;

        public Tree(Container<Shape> objects_, TreeView tree_)
        {
            objects = objects_;
            tree = tree_;
        }

        public void Print()
        {
            tree.Nodes.Clear();
            if (objects.getSize() != 0)
            {
                TreeNode start = new TreeNode("Shape");

                for (int i = 0; i < objects.getSize(); i++)
                    PrintNode(start, objects[i]);

                tree.Nodes.Add(start);

                for (int i = 0; i < objects.getSize(); i++)
                    if (objects[i].getselect() == true)
                    {
                        tree.SelectedNode = tree.Nodes[0].Nodes[i];
                    }

                tree.ExpandAll();
            }
        }

        public void PrintNode(TreeNode node, Shape obj)
        {
            if (obj is SGroup)
            {
                TreeNode tn = new TreeNode(obj.GetData());

                for (int i = 0; i < ((SGroup)obj).getCount(); i++)
                    PrintNode(tn, ((SGroup)obj).getShape(i));

                node.Nodes.Add(tn);
            }
            else
            {
                node.Nodes.Add(obj.GetData());
            }
        }

        public override void SubjectChanged()
        {
            Print();
        }


    }
}
