using PrismaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismaWEB.Validacoes
{
    public class CandidatoValidate
    {
        public string Validacao(PESSOAS pessoa /*PRESIDENTES presidente*/)
        {
            var error = "";
            if (pessoa.nome == null)
            {
                return "Falta preencher campo NOME";
            }

            if (pessoa.DataNascimento == null)
            {
                return "Falta preencher campo DATA DE NASCIMENTO";
            }

            if (pessoa.Cpf == null)
            {
                return "Falta preencher campo CPF";
            }

            if (pessoa.Email == null)
            {
                return "Falta preencher campo EMAIL";
            }

            if (pessoa.Ativo == 0)
            {
                return "Falta preencher campo ATIVO";
            }

            //if (pessoa.TelefoneFixo == null)
            //{
            //    return "Falta preencher campo TELEFONE FIXO";
            //}

            //if (pessoa.TelefoneMovel == null)
            //{
            //    return "Falta preencher campo TELEFONE MOVEL";
            //}

            if (pessoa.Pais_Id == null)
            {
                return "Falta preencher campo PAIS";
            }

            if (pessoa.Estado_Id == null)
            {
                return "Falta preencher campo ESTADO";
            }

            if (pessoa.Municipio_Id == null)
            {
                return "Falta preencher campo MUNICIPIO";
            }

            if (pessoa.Bairro_Id == null)
            {
                return "Falta preencher campo BAIRRO";
            }

            //if (pessoa.Logradouro_Id == null)
            //{
            //    return "Falta preencher campo LOGRADOURO";
            //}

            //if (pessoa.Cep == null)
            //{
            //    return "Falta preencher campo CEP";
            //}

            //if (pessoa.Numero == null)
            //{
            //    return "Falta preencher campo NUMERO";
            //}
            //if (pessoa.Complemento == null)
            //{
            //    return "Falta preencher campo COMPLEMENTO";
            //}
            return error;
        }
    }
}