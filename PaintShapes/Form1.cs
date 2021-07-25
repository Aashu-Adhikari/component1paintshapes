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

namespace PaintShapes
{
    public partial class Form1 : Form
    {

        
        Boolean drawCircle, drawRectangle, drawPolygon, drawTriangle;
        //string variables to store text command text info
        String app;
        //holds the information of words in arrayS
        String[] words;
        //stores integer variables of x and y cordinates
        int moveX, moveY;
        //stores the thickness of pen in integer
        int thickness;
        //FactoryShapes Declared
        Shapes shape1, shape2, shape3;
        //list to hold circle, rectangle, variable, triangle and polygon objects
        List<Circle> circleObjects;
        
        List<Rectangle> rectangleObjects;
        
        List<Polygon> polygonObjects;

        List<MoveDirection> moveObjects;

        List<Triangle> triangleObjects;

        Circle circle;
        Rectangle rectangle;
        Triangle triangle;

        //stores the implement command form implement text
        string implementCmd;
        string console_text;

        Graphics g;
        Polygon polygon;
        //Declared the Color as c
        Color c;

        

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            circle = new Circle(); //creates new circle
            rectangle = new Rectangle(); //creates new rectangle
            circleObjects = new List<Circle>(); //creates array of new circle objects
            rectangleObjects = new List<Rectangle>(); //creates array of new rectangle objects
            moveObjects = new List<MoveDirection>(); //creates array of new move objects
            triangleObjects = new List<Triangle>(); //creates array of new polygon object
            polygonObjects = new List<Polygon>();
            c = Color.White;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("!!!!MAKE SURE YOU ENTER THE SYNTAX AND PARAMATERS CORRECT!!!!\n" +
                "++++++++++++++++++++++++++\n" +
                "Hint\n" +
                "++++++++++++++++++++++++++\n" +
                "TO DISPLAY SHAPES COMMANDS\n" +
                "-----------------------------\n" +
                "draw rectangle 500 100\n" +
                "draw circle 100 100\n" +
                
                "-----------------------------\n" +
                "TO CHANGE THE CORDINATES OF THE SHAPES COMMANDS\n" +
                "-----------------------------\n" +
                "move 100 100\n" +
                "------------------------------\n" +
                "TO CHANGE THE COLOR AND SIZE OF THE PEN\n" +
                "--------------------------------\n" +
                "color red 23\n");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        


        public Form1()
        {
            InitializeComponent();
            FactoryAbstract shapeFactory = FactProd.getFactory("Shapes");
            shape1 = shapeFactory.getShapes("Circle");
            shape2 = shapeFactory.getShapes("Rectangle");
            shape3 = shapeFactory.getShapes("Triangle");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            implementCmd = textBox1.Text.ToLower();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (implementCmd)
            {
                case "run":
                    if (richTextBox1.Text == "")
                    {
                        MessageBox.Show("No Syntax and Paramater Detected");
                    }
                    try
                    {
                        app = richTextBox1.Text.ToLower();

                        char[] delimiters = new char[] { '\r', '\n' };
                        //holds invididuals code line 
                        string[] parts = app.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                        console_text = "app code: \n";
                        foreach (string part in parts)
                        {
                            console_text += part + "\n";
                        }
                        console_text += "\n\n";
                        //loop through the whole app code line
                        for (int i = 0; i < parts.Length; i++)
                        {
                            //single code line
                            String code_line = parts[i];
                            //splits the code when space 
                            char[] value_code = new char[] { ' ' };
                            //holds invididuals code line
                            words = code_line.Split(value_code, StringSplitOptions.RemoveEmptyEntries);
                            //checks if words has move command then
                            if (words[0] == "move")
                            {
                                moveX = Convert.ToInt32(words[1]);//sets the location the shape xaxis
                                moveY = Convert.ToInt32(words[2]);//sets the location of the shape yaxis
                            }


                            //checks if word holds the value color then
                            if (words[0] == "color")
                            {
                                thickness = Convert.ToInt32(words[2]);//converting string value to integer value

                                if (words[1] == "red")//if red then color changes to red
                                {
                                    c = Color.Red;
                                    console_text += "red color\n\n";
                                }
                                else if (words[1] == "blue")//if blue then color changes to blue
                                {
                                    c = Color.Blue;
                                    console_text += "blue color\n\n";
                                }
                                else if (words[1] == "yellow")//if yellow then color changes to yellow
                                {
                                    c = Color.Yellow;
                                    console_text += "yellow color\n\n";
                                }
                                else
                                {
                                    c = Color.AliceBlue;
                                    console_text += "green color\n\n";//default color 
                                }
                            }

                            //checks for 'draw' word
                            if (words[0].Equals("draw"))
                            {
                                //checks for 'circle' word
                                if (words[1] == "circle")
                                {
                                    //checks weather the written code is right or wrong
                                    if (!(words.Length == 3))
                                    {
                                        MessageBox.Show("!!!Wrong Command!!!\neg.draw circle 100");

                                    }
                                    else
                                    {
                                        Circle circle = new Circle();
                                        circle.setX(moveX);
                                        circle.setY(moveY);
                                        circle.setRadius(Convert.ToInt32(words[2]));
                                        circleObjects.Add(circle);
                                        drawCircle = true;
                                        console_text += "Adding new circle\n\n";
                                    }
                                }
                                //checks if the word is rectangle or not
                                if (words[1].Equals("rectangle"))
                                {
                                    //checks if the given paramater is wrng then displays message
                                    if (!(words.Length == 4))
                                    {
                                        MessageBox.Show("!!!Wrong Command!!!\neg.draw rectangle 100 100 ");
                                    }
                                    else
                                    {
                                        Rectangle rect = new Rectangle();
                                        rect.setX(moveX);
                                        rect.setY(moveY);
                                        rect.setHeight(Convert.ToInt32(words[2]));
                                        rect.setWidth(Convert.ToInt32(words[3]));
                                        rectangleObjects.Add(rect);
                                        drawRectangle = true;
                                        console_text += "Adding new rectangle\n\n";
                                    }
                                }
                                if (words[1].Equals("polygon"))
                                {
                                    drawPolygon = true;
                                }

                                if (words[1].Equals("triangle"))
                                {
                                    //created triangle instance of triangle class
                                    Triangle triangle = new Triangle();
                                    //Takes the cordination of the trangle
                                    PointF[] points = { new PointF(100, 100), new PointF(200, 100), new PointF(150, 10) };
                                    //puts points value to Trangle setter method
                                    triangle.setPoints(points);
                                    triangleObjects.Add(triangle);
                                    //makes draw triangle true
                                    drawTriangle = true;

                                }
                            }
                        }
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        console_text += "Error: " + ex.Message + "\n\n";
                    }
                    //refresh everytime painting equals to true
                    panel2.Refresh();
                    break;
                case "clear"://if action command is clear
                    circleObjects.Clear();
                    rectangleObjects.Clear();
                    moveObjects.Clear();
                    polygonObjects.Clear();
                    triangleObjects.Clear();
                    drawCircle = false;
                    drawRectangle = false;
                    drawPolygon = false;
                    drawTriangle = false;
                    richTextBox1.Clear();
                    textBox1.Clear();
                    
                    panel2.Refresh();
                    break;
                default:
                    MessageBox.Show("The command space is empty\n" +//if acction text area is empty
                        "Or\n" +
                        "Must be: 'Run' for the execution\n" +
                        "Must be: 'Clear' for Fresh Start");
                    break;
            }
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //inbuilt Graphic library in value g to paint
            Graphics g = e.Graphics;

            if (drawCircle == true)//if condition is true then
            {
                foreach (Circle circleObject in circleObjects)
                {
                    console_text += "painting Circle\n\n";
                    circleObject.paint(g, c, thickness); // paints the circle 
                }
            }

            if (drawRectangle == true) //paint condtion is true then
            {
                foreach (Rectangle rectangleObject in rectangleObjects)
                {
                    console_text += "painting Rectangle\n\n";
                    rectangleObject.paint(g, c, thickness); //paint the rectangle
                }
            }


            if (drawTriangle == true)// draw condition is true then
            {
                foreach (Triangle traingleObject in triangleObjects)
                {
                    console_text += "painting Triangle\n\n";
                    traingleObject.paint(g, c, thickness); //draw the triangle
                }
            }

            if (drawPolygon == true)// if condition is true then
            {
                Pen blackPen = new Pen(c, thickness);
                SolidBrush fill = new SolidBrush(c);

                PointF point1 = new PointF(50.0F, 50.0F);
                PointF point2 = new PointF(70.0F, 25.0F);
                PointF point3 = new PointF(100.0F, 5.0F);
                PointF point4 = new PointF(150.0F, 30.0F);
                PointF point5 = new PointF(200.0F, 50.0F);
                PointF point6 = new PointF(250.0F, 100.0F);
                PointF point7 = new PointF(150.0F, 150.0F);
                string[] str = new string[5];
                PointF[] curvePoints =
                 {
                    point1,
                    point2,
                    point3,
                    point4,
                    point5,
                    point6,
                    point7
             };
                e.Graphics.DrawPolygon(blackPen, curvePoints);// paints the polygon
                e.Graphics.FillPolygon(fill, curvePoints);// paints the polygon
            }
        }
    }
}
