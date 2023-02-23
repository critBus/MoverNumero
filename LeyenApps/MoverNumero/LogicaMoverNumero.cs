/*
 * Created by SharpDevelop.
 * User: Rene
 * Date: 9/1/2022
 * Time: 12:43
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
namespace LeyenApps.MoverNumero
{
	/// <summary>
	/// Description of LogicaMoverNumero.
	/// </summary>
	public class LogicaMoverNumero:ConsolaBasica
	{
		public LogicaMoverNumero()
		{
		}
		public static void quitarNumeroDelPrincipio(DirectoryInfo carpeta,bool recorrerCarpetasInternas,bool soloArchivos,bool anime){
		recorridoPorCarpetas(carpeta:carpeta
			                     ,recorrerCarpetasInternas:recorrerCarpetasInternas
			                    ,soloArchivos:soloArchivos
			                    ,anime:anime
			                   ,crearNuevoNombre:(pr,nombre)=>pr.getNombreSinNumeroAlPrincipio(nombre));
			
		}
		private static void recorridoPorCarpetas(DirectoryInfo carpeta,bool recorrerCarpetasInternas,bool soloArchivos,bool anime,metodoCreador2<ProcesadorDeSerie,string,string> crearNuevoNombre){
		
			
			ContextoDeConjuntoDeSeries cx = new ContextoDeConjuntoDeSeries();
			cwl("Comenzando...");
			ContextoDeSerie cxs = new ContextoDeSerie();
			ConfiguracionDeSeries cf=null;
			if(anime){
				cf = ConfiguracionDeSeries.getConfiguracionParaAnime();
			}else{
				cf = ConfiguracionDeSeries.getConfiguracionParaSeriesPersona();
			}
			
			ProcesadorDeSerie pr = new ProcesadorDeSerie(cf);
			pr.contextoDeConjunto = cx;
			pr.contexto = cxs;
			
			Predicate<FileSystemInfo> ulitilizarFile = f => {
				string nombre = Archivos.esArchivo(f.ToString()) ? Archivos.getNombre(new FileInfo(f.ToString())) : f.Name;
				//string nuevoNombre=pr.getNombreConNumeroAlPrincipio(nombre,separador,poner1raTemporada);
				string nuevoNombre=crearNuevoNombre(pr,nombre);
				if(nombre!=nuevoNombre){
					if(f.GetType()==carpeta.GetType()){
						DirectoryInfo c=(DirectoryInfo)f;
						Directory.Move(f.ToString(),Directory.GetParent(f.ToString())+"/"+nuevoNombre);
					}else{
						Archivos.renombrar_SinExtencion((FileInfo)f,nuevoNombre);
					}
					
					
				}
				return true;
			};
			cwl("Recorriendo Carpetas...");
			Archivos.recorrerCarpeta_UtilizarCarpetaAlFinal(carpeta,recorrerCarpetasInternas, d => {
				if (d.Name.Contains("Subtitulo") || d.Name.StartsWith("_")) {
					return false;
				}
				cx.Url = d.ToString();
				
				cxs.Url = d.ToString();
				cxs.IndiceExtencion = -1;
				cxs.EsVideo = false;
				cxs.EsCarpeta = true;
				cxs.EsArchivo = false;
				if(!soloArchivos){
					ulitilizarFile(d);
				}
				
				return true;
				//cx.ConjuntoDeNombres = Arreglos.unir(Archivos.getCarpetas_SoloNombreStr(d), Archivos.getArchivos_SoloNombreSinExtencionStr(d));
			}, f => {
				if (Videos.esVideo(f)||Videos.esSubtitulo(f)) {
					cxs.Url = f.ToString();
					cxs.IndiceExtencion = f.Name.LastIndexOf(".");
					cxs.EsVideo = true;
					cxs.EsCarpeta = false;
					cxs.EsArchivo = true;
					ulitilizarFile(f);
					
				}//fin del if es video                     	
				
			                         	
			});
			
			
		}
		
		public static void provarPonerNumerosAlPrincipio(DirectoryInfo carpeta,bool recorrerCarpetasInternas=true,string separador="+",bool poner1raTemporada=true,bool soloArchivos=false,bool anime=false)
		{
			recorridoPorCarpetas(carpeta:carpeta
			                     ,recorrerCarpetasInternas:recorrerCarpetasInternas
			                    ,soloArchivos:soloArchivos
			                    ,anime:anime
			                   ,crearNuevoNombre:(pr,nombre)=>pr.getNombreConNumeroAlPrincipio(nombre,separador,poner1raTemporada));
			
			
			
//		ContextoDeConjuntoDeSeries cx = new ContextoDeConjuntoDeSeries();
//			cwl("Comenzando...");
//			ContextoDeSerie cxs = new ContextoDeSerie();
//			ConfiguracionDeSeries cf=null;
//			if(anime){
//				cf = ConfiguracionDeSeries.getConfiguracionParaAnime();
//			}else{
//				cf = ConfiguracionDeSeries.getConfiguracionParaSeriesPersona();
//			}
//			
//			ProcesadorDeSerie pr = new ProcesadorDeSerie(cf);
//			pr.contextoDeConjunto = cx;
//			pr.contexto = cxs;
//			
//			Predicate<FileSystemInfo> ulitilizarFile = f => {
//				string nombre = Archivos.esArchivo(f.ToString()) ? Archivos.getNombre(new FileInfo(f.ToString())) : f.Name;
//				string nuevoNombre=pr.getNombreConNumeroAlPrincipio(nombre,separador,poner1raTemporada);
//				if(nombre!=nuevoNombre){
//					if(f.GetType()==carpeta.GetType()){
//						DirectoryInfo c=(DirectoryInfo)f;
//						Directory.Move(f.ToString(),Directory.GetParent(f.ToString())+"/"+nuevoNombre);
//					}else{
//						Archivos.renombrar_SinExtencion((FileInfo)f,nuevoNombre);
//					}
//					
//					
//				}
//				return true;
//			};
//			cwl("Recorriendo Carpetas...");
//			Archivos.recorrerCarpeta_UtilizarCarpetaAlFinal(carpeta,recorrerCarpetasInternas, d => {
//				if (d.Name.Contains("Subtitulo") || d.Name.StartsWith("_")) {
//					return false;
//				}
//				cx.Url = d.ToString();
//				
//				cxs.Url = d.ToString();
//				cxs.IndiceExtencion = -1;
//				cxs.EsVideo = false;
//				cxs.EsCarpeta = true;
//				cxs.EsArchivo = false;
//				if(!soloArchivos){
//					ulitilizarFile(d);
//				}
//				
//				return true;
//				//cx.ConjuntoDeNombres = Arreglos.unir(Archivos.getCarpetas_SoloNombreStr(d), Archivos.getArchivos_SoloNombreSinExtencionStr(d));
//			}, f => {
//				if (Videos.esVideo(f)||Videos.esSubtitulo(f)) {
//					cxs.Url = f.ToString();
//					cxs.IndiceExtencion = f.Name.LastIndexOf(".");
//					cxs.EsVideo = true;
//					cxs.EsCarpeta = false;
//					cxs.EsArchivo = true;
//					ulitilizarFile(f);
//					
//				}//fin del if es video                     	
//				
//			                         	
//			});
			
			
			
		}
		
	}
}
