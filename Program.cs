/*
 * Created by SharpDevelop.
 * User: Rene
 * Date: 9/1/2022
 * Time: 09:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Windows.Forms;
using ReneUtiles;
using ReneUtiles.Clases;
using ReneUtiles.Clases.Multimedia;
using ReneUtiles.Clases.Multimedia.Series;
using ReneUtiles.Clases.Multimedia.Relacionador.Saltos;
using ReneUtiles.Clases.Multimedia.Series.Contextos;
namespace MoverNumero
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
		
		
	}
}
