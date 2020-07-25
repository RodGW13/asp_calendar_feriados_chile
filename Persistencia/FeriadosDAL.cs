using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class FeriadosDAL
    {
        /// <summary>
        /// Metodo que consume los feriados del año actual + el proximo
        /// se usa la api del gobierno digital
        /// </summary>
        /// <returns></returns>
        public IList<FeriadosBO> ObtenerFeriadosAPI()
        {
            IList<FeriadosBO> IlstFeriados = new List<FeriadosBO>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://apis.digital.gob.cl/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync("fl/feriados/" + System.DateTime.Now.Year).Result;
                    if (response.IsSuccessStatusCode)
                    {

                        string json = response.Content.ReadAsStringAsync().Result;
                        IlstFeriados = JsonConvert.DeserializeObject<IList<FeriadosBO>>(json);
                    }
                    IList<FeriadosBO> LstPosterior = ObtenerFeriadosPostAPI();
                    if (LstPosterior.Count > 0)
                    {
                        for (int i = 0; i < LstPosterior.Count; i++)
                        {
                            FeriadosBO feriadosBO = new FeriadosBO();
                            feriadosBO.Comentarios = LstPosterior[i].Comentarios;
                            feriadosBO.Fecha = LstPosterior[i].Fecha;
                            feriadosBO.Irrenunciable = LstPosterior[i].Irrenunciable;
                            feriadosBO.Tipo = LstPosterior[i].Tipo;
                            feriadosBO.Nombre = LstPosterior[i].Nombre;
                            feriadosBO.leyes = LstPosterior[i].leyes;
                            IlstFeriados.Add(feriadosBO);
                        }
                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return IlstFeriados;
        }

        /// <summary>
        /// Metodo que consume los feriados del proximo Año 
        /// se usa la api del gobierno digital
        /// </summary>
        /// <returns></returns>
        public IList<FeriadosBO> ObtenerFeriadosPostAPI()
        {
            IList<FeriadosBO> IlstFeriados = new List<FeriadosBO>();
            try
            {
                using (var client = new HttpClient())
                {
                    int anio = Convert.ToInt32(DateTime.Now.Year);
                    anio = anio + 1;
                    client.BaseAddress = new Uri("https://apis.digital.gob.cl/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync("fl/feriados/" + anio).Result;
                    if (response.IsSuccessStatusCode)
                    {

                        string json = response.Content.ReadAsStringAsync().Result;
                        IlstFeriados = JsonConvert.DeserializeObject<IList<FeriadosBO>>(json);
                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return IlstFeriados;
        }
    }
}
