using System;
using System.Linq;
using System.Collections.Generic;

using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class LocalizacaoDAL : ILocalizacaoDAL
    {
        private ISQLiteDataContext DataContext { get; set; }
        public LocalizacaoDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }
        public void Cadastrar(LocalizacaoDTO localizacaoDTO)
        {
            var localizacao = VerificaGlossarioExistente(localizacaoDTO);
            
            RemoverLocalidadesAnteriores(localizacao);
            DataContext.ObterDataContext().InsertOrReplace(localizacao);
            
            localizacaoDTO.SetID(ObterLocalizacao(localizacaoDTO).FirstOrDefault().Id);
            VincularLocalidades(ObterLocalidades(localizacaoDTO));
        }
        public List<LocalizacaoDTO> Consultar(LocalizacaoDTO localizacaoDTO, double inicioX, double inicioY, double fimX, double fimY)
        {
            var retorno = new List<LocalizacaoDTO>();
            var localizacoes = new List<Localizacao>();

            if (string.IsNullOrEmpty(localizacaoDTO.Nome))
                localizacoes = ObterLocalizacao(inicioX, inicioY, fimX, fimY);
            else
                localizacoes = ObterLocalizacao(localizacaoDTO);

            foreach(var localizacao in localizacoes)
            {
                var saida = new LocalizacaoDTO(localizacao.Id)
                {
                    Nome = localizacao.Nome,
                    Latitude = localizacao.Latitude,
                    Longitude = localizacao.Longitude,
                    DataRegistro = localizacao.DataRegistro,
                };
                var localidades = ObterLocalidades(saida);
                foreach(var localidade in localidades)
                {
                    saida.Regioes.Add(new RegiaoDTO()
                    {
                        Regiao = localidade.Regiao,
                        Local = localidade.Local,
                        NomeLocal = ObterLocalizacao(new LocalizacaoDTO(localidade.Local)).FirstOrDefault().Nome
                    });
                }
                retorno.Add(saida);
            }
            return retorno;
        }

        private Localizacao VerificaGlossarioExistente(LocalizacaoDTO localizacaoDTO)
        {
            return ObterLocalizacao(localizacaoDTO).FirstOrDefault() ?? new Localizacao()
            {
                Nome = localizacaoDTO.Nome,
                Latitude = localizacaoDTO.Latitude,
                Longitude = localizacaoDTO.Longitude,
                DataRegistro = localizacaoDTO.DataRegistro
            };
        }

        private List<RegiaoLocal> ObterLocalidades(LocalizacaoDTO localizacaoDTO)
        {
            var id = localizacaoDTO.GetID();
            return DataContext.ObterDataContext().Table<RegiaoLocal>().Where(regiao => regiao.Regiao == id).ToList();
        }
        private List<Localizacao> ObterLocalizacao(double inicioX, double inicioY, double fimX, double fimY)
        {
            if (inicioX > fimX || inicioY > fimY)
                throw new Exception("Coordenadas inválidas, o vetor de busca deve ser traçado de norte a sul e de oeste a leste.");

            return DataContext.ObterDataContext().Table<Localizacao>().Where(localizacao => 
                localizacao.Latitude > inicioX && localizacao.Latitude < fimX &&
                localizacao.Longitude > inicioY && localizacao.Longitude < fimY
                ).ToList();
        }

        private List<Localizacao> ObterLocalizacao(LocalizacaoDTO localizacaoDTO)
        {
            var id = localizacaoDTO.GetID();

            if (string.IsNullOrEmpty(localizacaoDTO.Nome) && id == null)
                return DataContext.ObterDataContext().Table<Localizacao>().ToList();
            
            if (localizacaoDTO.GetID() != null)
                return DataContext.ObterDataContext().Table<Localizacao>().Where(localizacao => localizacao.Id == id).ToList();
            
            return DataContext.ObterDataContext().Table<Localizacao>().Where(localizacao => localizacao.Nome == localizacaoDTO.Nome).ToList();
        }

        private void VincularLocalidades(List<RegiaoLocal> localidades)
        {
            foreach(var localidade in localidades)
            {
                DataContext.ObterDataContext().Insert(localidade);
            }
        }

        private void RemoverLocalidadesAnteriores(Localizacao localizacao)
        {
            if (localizacao.Id != null)
            {
                var regiao = DataContext.ObterDataContext().Table<RegiaoLocal>().Where(vinculo => vinculo.Regiao == localizacao.Id);
                foreach(var local in regiao)
                    DataContext.ObterDataContext().Delete(local);
            }
        }
    }
}