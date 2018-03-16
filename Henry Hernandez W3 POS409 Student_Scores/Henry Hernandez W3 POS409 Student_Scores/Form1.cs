
//Henry Hernandez W3 POS 409 Student Score Records
//C# Program - Calculates average score, displays highest scoring student, and allows user to edit and save files
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Windows.Forms;


namespace Henry_Hernandez_W3_POS409_Student_Scores
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int studentScores;//private class for sorting open files
        private const int ARRAY_SIZE = 10;
        private int[] score = new int[ARRAY_SIZE];
        string[] name = new string[ARRAY_SIZE];
        private void openFile_Click(object sender, EventArgs e)
        {
        try//captures error
            {
                if (openFD.ShowDialog() == DialogResult.OK)//verifies file existence 
                {
                    
                    StreamReader tRead = new StreamReader(openFD.FileName);//opens file

                    while (tRead.Peek() != -1)
                    {
                        if (studentScores <= name.Length)//velidates array size
                        {
                            score[studentScores] = Convert.ToInt32(tRead.ReadLine());//sorts and collects textfile number data 
                            name[studentScores] = tRead.ReadLine();//sorts and collects textfile word data
                            studentScores++;
                         
                        }
                        else
                        {
                            MessageBox.Show("Error: Unable To Open File");//error display
                            break;


                        }
                    }
                    displayArrays();//calls method to display arrays 
                    tRead.Close();//Closes the writer 
                    tRead.Dispose();//Disposes of writer
                }
            }
        catch (System.Exception excep)//error display
        {

        MessageBox.Show(excep.Message);

        }
           
        }
void displayArrays()
    {
       
            StreamReader tRead = new StreamReader(openFD.FileName);//opens text file
            textBox1.Text = tRead.ReadToEnd();//reads text file 
          
            int answer = (score[0] + score[1] + score[2] + score[3] + score[4] + score[5] + score[6] + score[7] + score[8] + score[9]);
            int average = answer / 10;
            string myAvg = average.ToString();//converts int to string
            label1.Text = myAvg;
            for (int i = 0; i < studentScores; i++)//For loop that sorts arrays into fields
            {
             
                Array.Sort(score, name);//sorts arrays from least to greatest(descending)
           
                listBox1.Items.Add(score[i].ToString());//adds items from text file to list box
                listBox2.Items.Add(name[i]);//adds items from text file to list box
                label4.Text = name[9] + score[9];//displays highest scoring student
           }
            tRead.Close();//Closes the writer 
            tRead.Dispose();//Disposes of writer
    }

        private void saveButton_Click(object sender, EventArgs e)
        {
            {
                //Saves "Edit File" to anhy file
                if (saveFD.ShowDialog() == DialogResult.OK)//Verifies if savefiledialog is true
                {
                    StreamWriter objWriter = new StreamWriter(saveFD.FileName);
                    objWriter.Write(textBox1.Text);
                    objWriter.Close();//Closes the writer 
                    objWriter.Dispose();//Disposes of writer
                   
                }
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
           // Resets all the fields
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox1.Clear();
            label1.Text="";
            label4.Text = "";
        
        }
    }
    
}

