using System;
using GESTCRM.Clases;

namespace GESTCRM.Clases
{
	/// <summary>
	/// Descripción breve de Pedido.
	/// </summary>
	public class Pedido
	{
		public string sIdPedido;
		public string sIdPedidoTemp;
		public int iIdDelegado;
		public string sIdTipoPedido;
		public int iIdCliente;
		public string sIdCliente;
		public string sNombreCliente;
		public int iIdDestinatario;
		public string sIdDestinatario;
		public string sNombreDestinatario;
		public DateTime dFechaPedido;
		public DateTime dFechaPreferente;
		public DateTime dFechaValor;
		public double fImporte;
		public double fDescuento;
		public string sIdTipoCampana;
		public string tObservaciones;
		public int iEstado;
		public DateTime dFUM;
		public bool bEnviadoCEN;
		public bool bEnviadoPDA;

		public Pedido()
		{
			/*
			
			Se deberá incrementar el contador de iIdPedido cuando se sepa seguro que se ha
			guardado bien la cabecera de pedido.
			
			Configuracion.iUIPedidoCLI++;
			Configuracion.Graba ();
			
			*/

			this.sIdPedido="T"+Configuracion.iIdDelegado.ToString().PadLeft(4,'0')+Configuracion.iUIPedidoCLI.ToString().PadLeft(6,'0');
			this.sIdPedidoTemp=this.sIdPedido;
			this.iIdDelegado=GESTCRM.Clases.Configuracion.iIdDelegado;
			this.iIdCliente=0;
			this.sIdCliente="";
			this.sNombreCliente="";
			this.iIdDestinatario=0;
			this.sIdDestinatario="";
			this.sNombreDestinatario="";
			this.sIdTipoCampana="";
			this.tObservaciones="";
			this.iEstado=0;
			this.dFUM=DateTime.Now;
			this.bEnviadoCEN=false;
			this.bEnviadoPDA=false;
		}
		public Pedido (string sIP)
		{
			this.sIdPedido=sIP;
			this.sIdPedidoTemp=sIP;
			this.iIdDelegado=GESTCRM.Clases.Configuracion.iIdDelegado;
			this.iIdCliente=0;
			this.sIdCliente="";
			this.sNombreCliente="";
			this.iIdDestinatario=0;
			this.sIdDestinatario="";
			this.sNombreDestinatario="";
			this.sIdTipoCampana="";
			this.tObservaciones="";
			this.iEstado=0;
			this.dFUM=DateTime.Now;
			this.bEnviadoCEN=false;
			this.bEnviadoPDA=false;
		}
	}
}
