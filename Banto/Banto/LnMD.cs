using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banto
{
    /// 
    /// <summary>
    /// Solução : Banto - Parse de Manipulação de Domínios
    /// Projeto : LMD PT-BR - Linguagem de Manipulação de Domínios
    /// Criador : YAN DE LIMA JUSTINO
    /// Data    : 27/04/2010
    /// Créditos: Marcos Antônio Costa, Ada Lima de Sousa, Paulo Henrique Duque
    /// </summary>
    /// 
    internal class LnMD
    {
        Dominio _DominioSelecao;
        Dominio _DominioPossecao;
        Dominio _DominioCondicao;
        List<Dominio> _Contexto = new List<Dominio>();

        public LnMD()
        {
            _DominioSelecao = new Dominio(1);
            _DominioSelecao.Expressoes.Add("CAMPO");
            _DominioSelecao.Expressoes.Add("CAMPOS");
            _DominioSelecao.Expressoes.Add("O CAMPO");
            _DominioSelecao.Expressoes.Add("OS CAMPOS");
            _DominioSelecao.Expressoes.Add("COLUNA");
            _DominioSelecao.Expressoes.Add("COLUNAS");
            _DominioSelecao.Expressoes.Add("A COLUNA");
            _DominioSelecao.Expressoes.Add("AS COLUNAS");

            _DominioPossecao = new Dominio(2);
            _DominioPossecao.Expressoes.Add("TABELA");
            _DominioPossecao.Expressoes.Add("DA TABELA");
            _DominioPossecao.Expressoes.Add("DE");
            _DominioPossecao.Expressoes.Add("LISTA DE");

            _DominioCondicao = new Dominio(3);
            _DominioCondicao.Expressoes.Add("SE");
            _DominioCondicao.Expressoes.Add("QUANDO");
            _DominioCondicao.Expressoes.Add("ONDE");

            _Contexto.Add(_DominioPossecao);
            _Contexto.Add(_DominioSelecao);
            _Contexto.Add(_DominioCondicao);
        }

        private string Process(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            try
            {
                SQL sql = new SQL();
                string Expressao = string.Empty;
                string Sequenciador = string.Empty;

                List<Dominio> Dominios = new List<Dominio>();
                List<string> Sequenciadores = new List<string>();
                List<string> Lexicos = text.GerarListaDeLexicos();

                // Reverberação
                foreach (string lexico in Lexicos)
                {
                    if (string.IsNullOrEmpty(lexico))
                        continue;

                    if ((lexico.IndexOf('{') >= 0) || (!string.IsNullOrEmpty(Sequenciador)))
                    {
                        if (lexico.Equals("E"))
                            Sequenciador += ",";
                        else
                            Sequenciador += lexico;
                    }
                    else
                    {
                        string Projecao = Expressao + lexico;

                        var Projecoes = from p in _Contexto
                                        where p.Expressoes.Where(c => c.StartsWith(Projecao.ValidarExpressao())).Count() > 0
                                        select p;

                        if (Projecoes.Count() > 0)
                        {
                            var qExpressao = from p in Projecoes
                                             where p.Expressoes.Where(c => c.Equals(Projecao.ValidarExpressao())).Count() > 0
                                             select p;

                            if (qExpressao.Count() == 1)
                            {
                                Dominios.Insert(0, qExpressao.First());
                                Expressao = string.Empty;
                            }
                            else
                            {
                                Expressao += lexico + " ";
                            }
                        }
                        else
                        {
                            Expressao = string.Empty;
                        }
                    }

                    // Saida ativa dos sequenciadores
                    if ((lexico.IndexOf('}') >= 0) && (!string.IsNullOrEmpty(Sequenciador)))
                    {
                        if (Dominios.Count > 0 && Sequenciadores.Count() < Dominios.Count)
                        {
                            if (Dominios[0].PesoConceitual == 1)
                            {
                                var campos = Sequenciador.ListarSequenciador();
                                foreach (string campo in campos)
                                    sql.Fields.Add(campo);
                            }

                            if (Dominios[0].PesoConceitual == 2)
                            {
                                var tabelas = Sequenciador.ListarSequenciador();
                                foreach (string tabela in tabelas)
                                    sql.Tables.Add(tabela);
                            }

                            if (Dominios[0].PesoConceitual == 3)
                            {
                                var parametros = Sequenciador.ListarSequenciador();
                                foreach (string paramentro in parametros)
                                    sql.Params.Add(paramentro);
                            }

                            Sequenciador = string.Empty;
                            Dominios.RemoveAt(0);
                        }
                        else
                        {
                            Sequenciadores.Insert(0, Sequenciador);
                            Sequenciador = string.Empty;
                        }
                    }
                }

                // Saida ativa das sequências que não foram semantizadas
                if (Dominios.Count > 0 && Sequenciadores.Count > 0)
                {
                    while (Dominios.Count > Sequenciadores.Count)
                        Dominios.RemoveAt(0);

                    for (int I = 0; I < Dominios.Count; I++)
                    {
                        if (Dominios[I].PesoConceitual == 1)
                        {
                            var campos = Sequenciadores[I].ListarSequenciador();
                            foreach (string campo in campos)
                                sql.Fields.Add(campo);
                        }

                        if (Dominios[I].PesoConceitual == 2)
                        {
                            var tabelas = Sequenciadores[I].ListarSequenciador();
                            foreach (string tabela in tabelas)
                                sql.Tables.Add(tabela);
                        }

                        if (Dominios[0].PesoConceitual == 3)
                        {
                            var parametros = Sequenciador.ListarSequenciador();
                            foreach (string paramentro in parametros)
                                sql.Params.Add(paramentro);
                        }

                    }
                }
                return sql.CreateSQLCommand();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Execute(string text)
        {
            return Process(text);
        }
    }
}
