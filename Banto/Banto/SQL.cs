using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banto
{
    internal class SQL
    {
        public List<string> Fields { get; set; }
        public List<string> Tables { get; set; }
        public List<string> Params { get; set; }

        private List<string> _lstSUMItens = new List<string>();
        private List<string> _lstAVGItens = new List<string>();
        private List<string> _lstCOUNTItens = new List<string>();

        public SQL()
        {
            _lstSUMItens.Add("ASOMA");
            _lstSUMItens.Add("ASOMADE");
            _lstSUMItens.Add("SOMA");
            _lstSUMItens.Add("SOMADE");
            _lstSUMItens.Add("SOMADO");
            _lstSUMItens.Add("SOMADA");
            _lstSUMItens.Add("SOMATÓRIO");
            _lstSUMItens.Add("SOMATÓRIODE");
            _lstSUMItens.Add("SOMAR");
            _lstSUMItens.Add("SOMANDO");

            _lstAVGItens.Add("AMÉDIA");
            _lstAVGItens.Add("AMÉDIADE");
            _lstAVGItens.Add("MÉIDA");
            _lstAVGItens.Add("MÉDIADE");

            _lstCOUNTItens.Add("ACONTA");
            _lstCOUNTItens.Add("ACONTAGEM");
            _lstCOUNTItens.Add("CONTAGEM");
            _lstCOUNTItens.Add("CONTADO");

            this.Tables = new List<string>();
            this.Fields = new List<string>();
            this.Params = new List<string>();
        }

        private string ProcessSUMField(string sumText)
        {
            string _strRetorno = sumText;
            foreach (string sum in _lstSUMItens)
            {
                if (sumText.IndexOf(sum) >= 0)
                    _strRetorno = string.Format("SUM( {0} )", sumText.Replace(sum, ""));
            }
            return _strRetorno;
        }

        private string ProcessAVGField(string avgText)
        {
            string _strRetorno = avgText;

            foreach (string avg in _lstAVGItens)
            {
                if (avgText.IndexOf(avg) >= 0)
                    _strRetorno = string.Format("AVG( {0} )", avgText.Replace(avg, ""));
            }

            return _strRetorno;
        }

        private string ProcessCOUNTField(string countText)
        {
            string _strRetorno = countText;
            foreach (string count in _lstCOUNTItens)
            {
                if (countText.IndexOf(count) >= 0)
                    _strRetorno = string.Format("COUNT( {0} )", countText.Replace(count, ""));
            }

            return _strRetorno;
        }

        private string ProcessALIASField(string aliasText)
        {
            string _strRetorno = aliasText;
            List<string> _lstALIAStens = new List<string>();
            _lstALIAStens.Add("COMO");
            _lstALIAStens.Add("RENOMEANDOPARA");
            _lstALIAStens.Add("ERENOMEANDOPARA");
            _lstALIAStens.Add("MUDANDOPARA");
            _lstALIAStens.Add("EMUDANDOPARA");

            foreach (string alias in _lstALIAStens)
            {
                if (aliasText.IndexOf(alias) >= 0)
                    _strRetorno = aliasText.Replace(alias, " AS ");
            }

            return _strRetorno;
        }

        public string CreateSQLCommand()
        {
            // Preparando Sintaxe SQL
            string _strSeparador = string.Empty;

            string SQLcampos = string.Empty;
            foreach (string field in this.Fields)
            {
                string _strField = field;
                if (ProcessSUMField(field) != field)
                    _strField = ProcessSUMField(field);

                if (ProcessAVGField(field) != field)
                    _strField = ProcessAVGField(field);

                if (ProcessCOUNTField(field) != field)
                    _strField = ProcessCOUNTField(field);

                SQLcampos += _strSeparador + _strField;
                _strSeparador = ", ";
            }

            _strSeparador = string.Empty;
            string SQLtabelas = string.Empty;
            foreach (string tabela in this.Tables)
            {
                SQLtabelas += _strSeparador + tabela;
                _strSeparador = ", ";
            }

            _strSeparador = string.Empty;
            string SQLCondicao = string.Empty;
            foreach (string param in this.Params)
            {
                SQLCondicao += _strSeparador + param;
                _strSeparador = " AND ";
            }

            if (string.IsNullOrEmpty(SQLcampos))
                SQLcampos = "*";

            string sentenca = string.Format("SELECT {0} FROM {1}", SQLcampos, SQLtabelas);
            if (!string.IsNullOrEmpty(SQLCondicao))
                sentenca = string.Format("SELECT {0} FROM {1} WHERE {2}", SQLcampos, SQLtabelas, SQLCondicao);

            return sentenca;
        }
    }
}
