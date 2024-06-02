/*
 * Created by SharpDevelop.
 * User: razvan
 * Date: 5/31/2024
 * Time: 1:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace weatherGraphics
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			Left = 0;
			Top = 0;
			f = Font;
			g = panel1.CreateGraphics();
		}
		public float halfa = 0.0f;
		public float halfb = 0.0f;
		public void drawYear(ref float [] an, float hf, ref Pen p, ref Brush b, int ypost, int h,string d, int correction)
		{
			//doar pentru date pozitive toate
			//int h = 300;
			float px = 1;
			float py = h;
			float ste = 50;
			float x = (1 + 0) * ste;
			float y = h-(3*an[0]- hf);
			g.DrawLine(p, 0, h, 800, h);
			string s;
			
			for (int i = 0; i < 12; i++) {
				
				 x = (1 + i) * ste;
				 y = h-(3*an[i]- hf);
				 s = an[i].ToString();
				 if(s.Length>=5){s = s.Substring(0,5);}
				
				 g.DrawString(s,f,b,x+5,ypost);
				 if(i==0)
				 {
				 	 g.DrawString(d,f,b,x-55,ypost);
				 }
				
				 g.DrawString(month[i],f,b,x+5,600-30);
				 g.DrawLine(p, x, y-correction, px, py-correction);
				 g.DrawEllipse(ph2, x-2, y-correction-2, 4,4);
				g.DrawLine(ph, x, 0, x, 600);
				g.DrawLine(ph, 0, y-correction, 600, y-correction);
				
				g.DrawString(s,f,b,x,y-35);
				px = x;
				py = y;
			}
		}
		public void caldifsani(ref float [] an1, ref float [] an2, ref float [] dif)
		{
			
			for(int i = 0 ; i < 12 ; i++)
			{
				dif[i] = an1[i]-an2[i];
			}
		}
		public float findmin(ref float [] a)
		{
			float min = a[0];
			for(int i = 1 ; i < 12 ; i++)
			{
				if(a[i]<a[0]){min=a[i];}
			}
			return min;
		}
		public float findmax(ref float [] a)
		{
			float max = a[0];
			for(int i = 1 ; i < 12 ; i++)
			{
				if(a[i]>a[0]){max=a[i];}
			}
			return max;
		}
		public float findHalfMinMax(float a, float b)
		{
			return Math.Abs(a-b)/2;
		}
		public string [] month = {"JAN","FEB","MAR","APR","MAY","JUN","JUL","AUG","SEP","OCT","NOV","DEC"};
		public float [] an1874 = {19.0f,18.9f,23.3f,29.6f,51.3f,58.1f,65.3f,64.4f,60.0f,45.7f,29.9f,21.0f};
		public float [] an1875 = {5.9f,1.3f,19.4f,33.3f,48.5f,56.7f,63.0f,61.5f,52.8f,39.9f,28.5f,25.7f};
		public float [] difani  = new float[12];
		
		public Graphics g;
		public Pen pa = new Pen(Color.FromArgb(200,156,57,59),1);
		public Pen pb = new Pen(Color.FromArgb(200,255,100,59),1);
		public Pen pd = new Pen(Color.FromArgb(200,0,57,100),1);
		public Pen ph = new Pen(Color.FromArgb(20,0,57,100),1);
		public Pen ph2 = new Pen(Color.FromArgb(100,0,57,100),1);
		public Brush ba = new SolidBrush(Color.Blue);
		public Brush bb = new SolidBrush(Color.Green);
		public Brush bd = new SolidBrush(Color.Red);
		
		public Font f;
		void Button1Click(object sender, EventArgs e)
		{
			float maxa = findmax(ref an1874);
			float mina = findmin(ref an1874);
			 halfa  = findHalfMinMax(maxa, mina);
			 
			 float maxb = findmax(ref an1875);
			float minb = findmin(ref an1875);
			 halfb  = findHalfMinMax(maxb, minb);
			
			caldifsani(ref an1874, ref an1875, ref difani);
			int correction = 15;	
			drawYear(ref an1874,halfa,ref pa,ref ba,10,300,"1874",correction);
			drawYear(ref an1875,halfb, ref pb,ref bb,25,300,"1875",correction);
			drawYear(ref difani,halfa,ref pd, ref bd,40,500,"1875-1874",0);
		}
		
	}
}
