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
using System.Drawing;
using System.Windows.Forms;

using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Windows.Forms;
using LeyenApps.MoverNumero;
using MoverNumero.LeyenApps.MoverNumero;
using ReneUtiles;
using ReneUtiles.Clases;
using ReneUtiles.Clases.Multimedia;
using ReneUtiles.Clases.Multimedia.Series;
using ReneUtiles.Clases.Multimedia.Relacionador.Saltos;
using ReneUtiles.Clases.Multimedia.Series.Contextos;

using ReneUtiles.VisualBasico.Clases.Dialogos;
using ReneUtiles.VisualBasico;
using ReneUtiles.VisualBasico.Clases.Administrador;

namespace MoverNumero
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private SistemaEA<EA_MoverNumero> SEA;
		public MainForm()
		{
			
			
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			SEA=new SistemaEA<EA_MoverNumero>(nombreEA_ConExtencion:"EA_MoverNumero.leyenappea"
			                                  ,creadorEA:()=>{
			                                  EA_MoverNumero ea = new EA_MoverNumero();
												ea.Carpeta = getTextoEnCarpeta();
												ea.CarpetasInternas = estaSeleccionadoCarpetasInternas();
												ea.No1raTemparada = estaSeleccionadoNoPoner1raTemporada();
												ea.ParaAnime = estaSeleccionadoParaAnime();
												ea.Separador = getTextoSeparador();
												ea.SoloArchivos = estaSeleccionadoSoloArchivos();
												return ea;
			                                  }
			                                  ,utilizarEA:(ea)=>{
			                                  	setCarpetasInternas(ea.CarpetasInternas);
			                                  	setNoPoner1raTemporada(ea.No1raTemparada);
			                                  	setParaAnime(ea.ParaAnime);
			                                  	setTextoEnCarpeta(ea.Carpeta);
			                                  	setSoloArchivos(ea.SoloArchivos);
			                                  	setTextoSeparador(ea.Separador);
			                                  });
			SEA.cargarEA();
			seguridad();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		private bool estaSeleccionadoCarpetasInternas()
		{
			return checkBox1.Checked;
		}
		private bool setCarpetasInternas(bool a)
		{
			return checkBox1.Checked=a;
		}
		private bool estaSeleccionadoSoloArchivos()
		{
			return checkBox3.Checked;
		}
		private bool setSoloArchivos(bool a)
		{
			return checkBox3.Checked=a;
		}
		private bool estaSeleccionadoParaAnime()
		{
			return checkBox2.Checked;
		}
		private bool setParaAnime(bool a)
		{
			return checkBox2.Checked=a;
		}
		private bool estaSeleccionadoNoPoner1raTemporada()
		{
			return checkBox4.Checked;
		}
		private bool setNoPoner1raTemporada(bool a)
		{
			return checkBox4.Checked=a;
		}
		private string getTextoSeparador()
		{
			return textBox2.Text;
		}
		private string setTextoSeparador(string a)
		{
			return textBox2.Text=a;
		}
		private string getTextoEnCarpeta()
		{
			return textBox1.Text;
		}
		private string setTextoEnCarpeta(string a)
		{
			return textBox1.Text=a;
		}
		//acceso a direcciones
		private DirectoryInfo getCarpeta()
		{
			return UtilesVisualBasico.getDirectoryInfo(textBox1);
		}
		
		
		
		private bool hayUnaRutaValida()
		{
			return UtilesVisualBasico.tieneRutaValidaCarpeta(textBox1);
		}
		
		private void cargarCarpetaPrincipal(DirectoryInfo f)
		{
			textBox1.Text = f.ToString();
           
		}
		//buscar Carpeta
		private void Button5Click(object sender, EventArgs e)
		{
			UtilesVisualBasico.showFolderBrowserDlg(cargarCarpetaPrincipal);
		}
		//buscar Carpeta
		private void Button1Click(object sender, EventArgs e)
		{
			try {
				if (hayUnaRutaValida()) {
					UtilesVisualBasico.showProgresDlg(this, "Moviendo Numero...", () =>
            		                                  	LogicaMoverNumero.provarPonerNumerosAlPrincipio(
						carpeta: getCarpeta()
            		                                  		, recorrerCarpetasInternas: estaSeleccionadoCarpetasInternas()
            		                                  		, separador: getTextoSeparador().Trim()
            		                                  		, poner1raTemporada: !estaSeleccionadoNoPoner1raTemporada()
            		                                  		, soloArchivos: estaSeleccionadoSoloArchivos()
            		                                  		, anime: estaSeleccionadoParaAnime()
					)
            		                                  
            		                                  , () =>
            		                                  	UtilesVisualBasico.showDlgAceptarInf("Movidos Con Exito")
					);
				} else {
					UtilesVisualBasico.showDlgAceptarInf("No hay una Ruta Valida");
				}
                
                
			} catch (Exception ex) {
				UtilesVisualBasico.reponderException(ex, "Error");
			}
		}
        
		private void TextBox1TextChanged(object sender, EventArgs e)
		{
			textBox1.ForeColor = hayUnaRutaValida() ? Color.Green : Color.Red;
			seguridad();
		}
		private void seguridad()
		{


			UtilesVisualBasico.setEnable(hayUnaRutaValida(), button1, button2);
			//   VisualBasico.setEnable(hayUnaRutaValidaArchivoPalabras(), button3, button4);
		}
		void Button2Click(object sender, EventArgs e)
		{
			try {
				if (hayUnaRutaValida()) {
					UtilesVisualBasico.showProgresDlg(this, "Quitando Numero Del Principio...", () =>
            		                                  	LogicaMoverNumero.quitarNumeroDelPrincipio(
						carpeta: getCarpeta()
            		                                  		, recorrerCarpetasInternas: estaSeleccionadoCarpetasInternas()
            		                                  		, soloArchivos: estaSeleccionadoSoloArchivos()
            		                                  		, anime: estaSeleccionadoParaAnime()
					)
            		                                  
            		                                  , () =>
            		                                  	UtilesVisualBasico.showDlgAceptarInf("Quitandos Con Exito")
					);
				} else {
					UtilesVisualBasico.showDlgAceptarInf("No hay una Ruta Valida");
				}
                
                
			} catch (Exception ex) {
				UtilesVisualBasico.reponderException(ex, "Error");
			}
		}
		
//		private readonly string nombreEA = "EA_MoverNumero.leyenappea";
//		private string getUrlEA()
//		{
//			return Directory.GetCurrentDirectory().ToString() + "/" + nombreEA;
//		}
		private EA_MoverNumero getEA()
		{
			EA_MoverNumero ea = new EA_MoverNumero();
			ea.Carpeta = getTextoEnCarpeta();
			ea.CarpetasInternas = estaSeleccionadoCarpetasInternas();
			ea.No1raTemparada = estaSeleccionadoNoPoner1raTemporada();
			ea.ParaAnime = estaSeleccionadoParaAnime();
			ea.Separador = getTextoSeparador();
			ea.SoloArchivos = estaSeleccionadoSoloArchivos();
			return ea;
		}
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			SEA.crearEA();
		}
//		private void crearEA()
//		{
//			Archivos.saveObject(getUrlEA(), getEA());
//		
//		}
//		private void updateEA()
//		{
//		}
//		
//		private void cargarEA()
//		{
//			try {
//				try {
//					string url = getUrlEA();
//					if (Archivos.existeArchivo(url)) {
//						EA_MoverNumero ea = (EA_MoverNumero)Archivos.readObject(url);
//						//algo..
//					} else {
//						crearEA();
//					}
//				} catch (Exception ex) {
//					UtilesVisualBasico.reponderException(ex, "Error al cargar");
//					crearEA();
//				}
//			} catch (Exception ex) {
//				UtilesVisualBasico.reponderException(ex, "Error");
//			}
//		}

	}
}
