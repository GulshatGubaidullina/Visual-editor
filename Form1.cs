using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Laba_6._5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            end1 = picBoxPaint.Width;
            end2 = picBoxPaint.Height;

            paintBoxBegin = new Point(0, 0);
            paintBoxEnd = new Point(end1, end2);

            cursor.replace(paintBoxEnd);
            container = new Container<Shape>();

            ofd = new OpenFileDialog();
            sfd = new SaveFileDialog();

            tree = new Tree(container, treeView1);
            container.Add(tree);                          //дерево подписывается на хранилище
        }

        Cursor cursor = new Cursor(500, 500);
        Container<Shape> container;

        Point paintBoxBegin;
        Point paintBoxEnd;
        int end1, end2, selectedcount;

        OpenFileDialog ofd;
        SaveFileDialog sfd;
        int indexFigure = 1;

        Tree tree;
        

        private void picBoxPaint_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            selectedcount = 0;

            for (int i = 0; i < container.getSize(); i++)
            {
                if (container[i] != null)
                {
                    container[i].create(gr);
                    if (container[i].getselect())
                    {
                        container[i].createframe(gr); 
                        selectedcount++;
                    }
                    if (container[i].getselect2())
                    {
                        container[i].createframe2(gr);
                    }
                }
                //else break;

            }
            //cursor.create(gr, cursor);
            picBoxPaint.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void picBoxPaint_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = container.getSize() - 1; i >= 0; i--)
            {
                if (Control.ModifierKeys == Keys.Control)
                {
                    if (container[i].check(e.Location))    //если ctrl ЗАЖАТ и мы ПОПАЛИ по фигуре
                    {
                        container[i].select(true);
                        checkBoxSticky.Checked = false;
                        container.Notify();
                        return;
                    }
                }
                else
                {
                    if (container[i].check(e.Location))         //если ctrl НЕ ЗАЖАТ и мы ПОПАЛИ по фигуре
                    {
                        for (int j = 0; j < container.getSize(); j++)
                            container[j].select(false);
                        container[i].select(true);
                        checkBoxSticky.Checked = false;
                        container.Notify();
                        return;
                    }
                }
            }
            if (Control.ModifierKeys == Keys.Control)
            {
                for (int j = 0; j < container.getSize(); j++)
                    container[j].select(false);
                checkBoxSticky.Checked = false;
                container.Notify();
                return;
            }
            else
            {
                if (indexFigure == 1)
                {
                    Shape section = new Section(e.Location);
                    //section.setPointVax(picBoxPaint.Height, picBoxPaint.Width);
                    for (int j = 0; j < container.getSize(); j++)
                    {
                        container[j].select(false);
                    }
                    container.Add(section);
                    picBoxPaint.Invalidate();

                }
                else if (indexFigure == 2)
                {
                    Shape circle = new Circle(e.Location);
                    //circle.setPointVax(picBoxPaint.Height, picBoxPaint.Width);
                    for (int j = 0; j < container.getSize(); j++)
                        container[j].select(false);
                    container.Add(circle);
                    picBoxPaint.Invalidate();


                }
                else if (indexFigure == 3)
                {
                    Shape square = new Square(e.Location);
                   // square.setPointVax(picBoxPaint.Height, picBoxPaint.Width);
                    for (int j = 0; j < container.getSize(); j++)
                        container[j].select(false);
                    container.Add(square);
                    picBoxPaint.Invalidate();
                }
                checkBoxSticky.Checked = false;
            }
            container.Notify();

        }
    
       
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            container.Notify();
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void checkBoxSticky_CheckedChanged(object sender, EventArgs e)
        {
            if (container.getSize() != 0)
            {
                if (checkBoxSticky.Checked)
                {
                    int index = -1;
                    for (int i = container.getSize() - 1; i >= 0; i--)
                        if (container[i].getselect())
                            index = i;
                    if (selectedcount == 1)
                    {
                        container[index].SetSticky(checkBoxSticky.Checked);
                        if (checkBoxSticky.Checked == true)
                            container[index].Add(container);
                    }
                }
                else
                {
                    for (int i = container.getSize() - 1; i >= 0; i--)
                    {
                        container[i].SetSticky(false);
                        for (int j = 0; j < container.getSize(); j++)
                        {
                            container[j].select2(false);
                        }
                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (e.Action == TreeViewAction.ByMouse && e.Node.Text != "Shape")
            {
                TreeNode node = e.Node;
                while (node.Parent.Text != "Shape")
                    node = node.Parent;
                treeView1.SelectedNode = node;

                for (int i = 0; i < container.getSize(); i++)
                {
                    container[i].select(false);
                }

                container[node.Index].select(true);
                picBoxPaint.Invalidate();
            }
        }

        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1)
            {
                indexFigure = 1;
            }
            if (e.KeyCode == Keys.D2)
            {
                indexFigure = 2;
            }
            if (e.KeyCode == Keys.D3)
            {
                indexFigure = 3;
            }

            if (e.KeyCode == Keys.V)
            {

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    for (int i = container.getSize() - 1; i >= 0; i--)
                        container.RemoveAt(i);

                    FileStream file = new FileStream(ofd.FileName, FileMode.Open);

                    StreamReader stream = new StreamReader(file);

                    AbstractFactory factory = new ShapeFactory();
                    int numberOfShapes = Convert.ToInt32(stream.ReadLine());

                    for (int i = 0; i < numberOfShapes; i++)
                    {
                        Shape shape;
                        shape = factory.createShape(stream.ReadLine());

                        shape.Load(stream, factory);

                        container.Add(shape);
                    }
                    checkBoxSticky.Checked = false;
                    stream.Close();
                    file.Close();
                    container.Notify();
                }
                
                picBoxPaint.Invalidate();
            }
            if (e.KeyCode == Keys.S)
            {
                for (int i = 0; i < container.getSize(); i++)
                {
                    if (container[i].getselect())
                    {
                        container[i].move(0, 5, paintBoxBegin, paintBoxEnd);
                        picBoxPaint.Invalidate();
                    }
                }
                if (Control.ModifierKeys == Keys.Control)
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        FileStream file = new FileStream(sfd.FileName, FileMode.Create);
                        StreamWriter stream = new StreamWriter(file);
                        stream.WriteLine(container.getSize());
                        for (int i = 0; i < container.getSize(); i++)
                        {
                            container[i].Save(stream);
                        }
                        stream.Close();
                        file.Close();
                    }
                }
            }
            ///////////////////////////////////////////////////
            if (e.KeyCode == Keys.W)
            {
                for (int i = 0; i < container.getSize(); i++)
                    if (container[i].getselect())
                    {
                        container[i].move(0, -5, paintBoxBegin, paintBoxEnd);
                        picBoxPaint.Invalidate();
                    }
            }

            

            if (e.KeyCode == Keys.A)
            {
                for (int i = 0; i < container.getSize(); i++)
                {
                    if (container[i].getselect())
                    {
                        container[i].move(-5, 0, paintBoxBegin, paintBoxEnd);
                        picBoxPaint.Invalidate();
                    }
                }
            }
            if (e.KeyCode == Keys.D)
            {
                for (int i = 0; i < container.getSize(); i++)
                {
                    if (container[i].getselect())
                    {
                        container[i].move(5, 0, paintBoxBegin, paintBoxEnd);
                        picBoxPaint.Invalidate();
                    }
                }
            }
            ///////////////////////////////////////////////////
           

            if (e.KeyCode == Keys.Z)
            {
                for (int i = 0; i < container.getSize(); i++)
                {
                    container[i].select(false);
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                var group = new SGroup(paintBoxEnd.X, paintBoxEnd.Y);
                int count = container.getSize();
                for (int i = 0; i < count; i++)
                {
                    if (container[i].Selected == true)
                    {
                        group.addShape(container[i]);
                        container.RemoveAt(i);
                        count--;
                        i--;
                    }
                    
                }
                container.Add(group);
                picBoxPaint.Invalidate();
                checkBoxSticky.Checked = false;
            }
            if (e.KeyCode == Keys.Escape)
            {
                int countGroup = 0;
                if (container.getSize() != 0)
                {
                    for (int i = 0; i < container.getSize(); i++)
                    {
                        if (container[i].getselect() && container[i].isgroup())
                        {
                            if (countGroup == 0)
                            {
                                SGroup group = (SGroup)container[i];

                                for (int j = group.getCount() - 1; j >= 0; j--)
                                    container.Add(group.GetAndDel(j));

                                container.RemoveAt(i);
                                countGroup++;
                            }
                            else
                                break;
                        }

                    }
                    for (int i = 0; i < container.getSize(); i++)
                    {
                        container[i].select(false);
                    }
                }
                checkBoxSticky.Checked = false;
            }

            ////////////////////////////////////////////

            if (e.KeyCode == Keys.Delete)
            {
                    for (int i = 0; i < container.getSize(); i++)
                    {
                        if (container[i].getselect())
                        {
                            container.RemoveAt(i);
                            i--;
                            picBoxPaint.Invalidate();
                        }
                    }
                checkBoxSticky.Checked = false;
            }

                if (e.KeyCode == Keys.Q)
                {
                    for (int i = 0; i < container.getSize(); i++)
                    {
                        if (container[i].getselect())
                        {
                            container[i].resize(-5, paintBoxBegin, paintBoxEnd);
                            picBoxPaint.Invalidate();
                        }
                    }
                }


                if (e.KeyCode == Keys.E)
                {
                    for (int i = 0; i < container.getSize(); i++)
                    {
                        if (container[i].getselect())
                        {
                            container[i].resize(5, paintBoxBegin, paintBoxEnd);

                            //////////////////
                            picBoxPaint.Invalidate();
                        }
                    }
                }

                /////////////////////////////////////////// 


                if (e.KeyCode == Keys.P)
                {
                    for (int i = 0; i < container.getSize(); i++)
                    {
                        if (container[i].getselect())
                        {
                            container[i].colorselect("Purple");
                            picBoxPaint.Invalidate();
                        }
                    }
                }

                if (e.KeyCode == Keys.G)
                {
                    for (int i = 0; i < container.getSize(); i++)
                    {
                        if (container[i].getselect())
                        {
                            container[i].colorselect("Green");
                            picBoxPaint.Invalidate();
                        }
                    }
                }

                if (e.KeyCode == Keys.Y)
                {
                    for (int i = 0; i < container.getSize(); i++)
                    {
                        if (container[i].getselect())
                        {
                            container[i].colorselect("Yellow");
                            picBoxPaint.Invalidate();
                        }
                    }
                }
            }
        }
    }
