using System;
using GESTCRM.Clases;

namespace GESTCRM.Clases
{
	/// <summary>
	/// Descripción breve de Pedido.
	/// </summary>
	public class Atencion
	{
		public int iIdAtencion;
		public string sIdAtencionTemp;
		public string sIdAtencion;
		public int iIdDelegado;
		public string sIdEstAtencion;
		public string tDescripcion;
		public DateTime dFechaSolicitud;
		public DateTime dFechaAprob;
		public int iIdDelegadoAprob;
		public DateTime dFechaLiq;
		public double fImportePrev;
		public double fImporteReal;
		public bool bLiqNotaGastos;
		public DateTime dFUM;
		public int iEstado;
		public bool bEnviadoPDA;
		public bool bEnviadoCEN;
		public int iImpPrevMax;
		public DateTime dFechaAJA;
		public DateTime dFechaPrep;
		public bool bComidas;

		public Atencion()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
			Configuracion.iUIAtencionCLI++;
			
			this.iIdAtencion=int.Parse(Configuracion.iIdDelegado.ToString().PadLeft(4,'0')+Configuracion.ValorConf(109).ToString().PadLeft(6,'0'));
			this.sIdAtencionTemp="T"+this.iIdAtencion.ToString();
			this.iIdDelegado=GESTCRM.Clases.Configuracion.iIdDelegado;
			this.sIdAtencion="";
			this.sIdEstAtencion="";
			this.tDescripcion="";
			this.iIdDelegadoAprob=0;
			this.fImportePrev=0;
		    this.fImporteReal=0;					
			this.bLiqNotaGastos=false;		
			this.iEstado=0;
			this.bEnviadoPDA=false;
			this.bEnviadoCEN=false;
			this.iImpPrevMax = Convert.ToInt32(Configuracion.fImpMaxAtencion);
			this.dFechaSolicitud = DateTime.MinValue;
			this.dFechaAprob = DateTime.MinValue;
			this.dFechaLiq = DateTime.MinValue;
			this.dFUM = DateTime.MinValue;
			this.dFechaAJA = DateTime.MinValue;
			this.dFechaPrep = DateTime.MinValue;
			this.bComidas= false;

		}
		public Atencion (int sIP)
		{
			this.iIdAtencion=sIP;
			//this.sIdAtencionTemp="T"+this.iIdAtencion.ToString();
			this.sIdAtencionTemp="";
			//this.iIdDelegado=GESTCRM.Clases.Configuracion.iIdDelegado;
			this.sIdAtencion="";
			this.iIdDelegado=0;
			this.sIdEstAtencion="";
			this.tDescripcion="";
			this.iIdDelegadoAprob=0;
			this.fImportePrev=0;
			this.fImporteReal=0;					
			this.bLiqNotaGastos=false;		
			this.iEstado=0;
			this.bEnviadoPDA=false;
			this.bEnviadoCEN=false;
			this.iImpPrevMax = Convert.ToInt32(Configuracion.fImpMaxAtencion);
			this.dFechaSolicitud = DateTime.MinValue;
			this.dFechaAprob = DateTime.MinValue;
			this.dFechaLiq = DateTime.MinValue;
			this.dFUM = DateTime.MinValue;
			this.dFechaAJA = DateTime.MinValue;
			this.dFechaPrep = DateTime.MinValue;
			this.bComidas= false;
		}
	}
}
