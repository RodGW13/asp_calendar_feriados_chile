using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FeriadosBLL
    {
		public IList<FeriadosBO> ObtenerFeriados()
		{
			try
			{
				Persistencia.FeriadosDAL feriadosDAL = new Persistencia.FeriadosDAL();
				return feriadosDAL.ObtenerFeriadosAPI();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
	}
}
