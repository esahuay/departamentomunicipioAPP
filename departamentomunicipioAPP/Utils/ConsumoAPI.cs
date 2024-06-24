using departamentomunicipio.Models;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace departamentomunicipioAPP.Utils
{
    public class ConsumoAPI
    {
        private const string urlBaseAPI = "https://localhost:7028/api/";

        #region Departamento
        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            List<Departamento> departamentos = new List<Departamento>();
            using (var httpClient = new HttpClient())
            {
                string url = urlBaseAPI + "Departamento";
                using (var response = await httpClient.GetAsync(url))
                {
                    string result = await response.Content.ReadAsStringAsync();
                    departamentos = JsonConvert.DeserializeObject<List<Departamento>>(result);
                }
            }
            return departamentos;
        }
        public async Task<Departamento> GetDepartamentoPorIDAsync(int id)
        {
            Departamento departamento = new Departamento();
            using (var httpClient = new HttpClient())
            {
                string url = urlBaseAPI + $"Departamento/{id}";
                using (var response = await httpClient.GetAsync(url))
                {
                    string result = await response.Content.ReadAsStringAsync();
                    departamento = JsonConvert.DeserializeObject<Departamento>(result);
                }
            }
            return departamento;
        }
        public async Task<Departamento> PostDepartamentoAsync(Departamento model)
        {
            Departamento departamento = new Departamento();
            using (var httpClient = new HttpClient())
            {
                string url = $"{urlBaseAPI}Departamento";
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(url, content))
                {
                    string result = await response.Content.ReadAsStringAsync();
                    departamento = JsonConvert.DeserializeObject<Departamento>(result);
                }
            }
            return departamento;
        }
        public async Task<Departamento> PutDepartamentoAsync(int Id, Departamento model)
        {
            Departamento departamento = new Departamento();
            using (var httpClient = new HttpClient())
            {
                string url = $"{urlBaseAPI}Departamento/{Id}";
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8 , "application/json");
                using (var response = await httpClient.PutAsync(url, content))
                {
                    string result = await response.Content.ReadAsStringAsync();
                    departamento = JsonConvert.DeserializeObject<Departamento>(result);
                }
            }
            return departamento;
        }
        #endregion

        #region Municipio
        public async Task<List<Municipio>> GetMunicipiosAsync()
        {
            List<Municipio> municipios = new List<Municipio>();
            using (var httpClient = new HttpClient())
            {
                string url = urlBaseAPI + "Municipio";
                using (var response = await httpClient.GetAsync(url))
                {
                    string result = await response.Content.ReadAsStringAsync();
                    municipios = JsonConvert.DeserializeObject<List<Municipio>>(result);
                }
            }

            for (int i = 0; i < municipios.Count; i++)
            {
                var municipio = municipios[i];
                var departamento = await GetDepartamentoPorIDAsync(municipio.DepartamentoId);
                municipios[i].Departamento = departamento ?? new Departamento();
            }
            return municipios;
        }

        public async Task<List<Municipio>> GetMunicipioPorDepartamento(int id)
        {
            List<Municipio> municipios = new List<Municipio>();
            using (var httpClient = new HttpClient())
            {
                string url = urlBaseAPI + $"Municipio/MunByDepto/{id}";
                using (var response = await httpClient.GetAsync(url))
                {
                    string result = await response.Content.ReadAsStringAsync();
                    municipios = JsonConvert.DeserializeObject<List<Municipio>>(result);
                }
            }
            return municipios;
        }

        public async Task<Municipio> GetMunicipioPorIDAsync(int id)
        {
            Municipio municipio = new Municipio();
            using (var httpClient = new HttpClient())
            {
                string url = $"{urlBaseAPI}Municipio/{id}";
                using(var response = await httpClient.GetAsync(url))
                {
                    string result = await response.Content.ReadAsStringAsync();
                    municipio = JsonConvert.DeserializeObject<Municipio>(result);
                }
            }
            if(municipio  != null)
            {
                municipio.Departamento = await GetDepartamentoPorIDAsync(municipio.DepartamentoId);
            }
            return municipio;
        }
        public async Task<Municipio> PostMunicipio(Municipio model) 
        {
            Municipio municipio = new Municipio();
            using (var httpClient = new HttpClient())
            {
                string url = $"{urlBaseAPI}Municipio";
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(url, content)) 
                {
                    string result = await response.Content.ReadAsStringAsync();
                    municipio = JsonConvert.DeserializeObject<Municipio>(result);
                }
            }
            return municipio;
        }
        public async Task<Municipio> PutMunicipio(int Id, Municipio model)
        {
            Municipio municipio = new Municipio();
            using (var httpClient = new HttpClient())
            {
                string url = $"{urlBaseAPI}Municipio/{Id}";
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync(url, content))
                {
                    string result = await response.Content.ReadAsStringAsync();
                    municipio = JsonConvert.DeserializeObject<Municipio>(result);
                }
            }
            return municipio;
        }
        #endregion

        #region Paises
        public async Task<List<Tablapai>> GetTablapaisesAsync()
        {
            List<Tablapai> tpais = new List<Tablapai>();
            using (var httpClient = new HttpClient())
            {
                string url = $"{urlBaseAPI}Tablapais";
                using (var response = await httpClient.GetAsync(url))
                {
                    string result = await response.Content.ReadAsStringAsync();
                    tpais = JsonConvert.DeserializeObject<List<Tablapai>>(result);
                }
            }
            for (int i = 0; i < tpais.Count; i++)
            {
                var pais = tpais[i];
                var departamento = await GetDepartamentoPorIDAsync(pais.IdDepartamento);
                tpais[i].Departamento = departamento;
            }
            for (int i = 0; i < tpais.Count; i++)
            {
                var pais = tpais[i];
                var municipio = await GetMunicipioPorIDAsync(pais.IdMunicipio);
                tpais[i].Municipio = municipio;
            }
            return tpais;
        }
        public async Task<Tablapai> PostTablapaises(Tablapai model)
        {
            Tablapai tpais = new Tablapai();
            using (var httpClient = new HttpClient())
            {
                string url = $"{urlBaseAPI}Tablapais";
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(url, content))
                {
                    string result = await response.Content.ReadAsStringAsync();
                    tpais = JsonConvert.DeserializeObject<Tablapai>(result);
                }
            }
            return tpais;
        }
        #endregion

    }
}
