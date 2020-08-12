using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProvaEAuditoria.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaEAuditoria.Models
{
    public class Locacao
    {
       
        public int Id { get; set; }
        public int IdCliente {
            get;
            set;
        }
        public int IdFilme {
            get;
            set;
        }

        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao {
            get;
            set;
        }

        private DateTime GetDataDevolucao(int idFilme)
        {
            
            DateTime dataDevolucao = default(DateTime);
           
            //var list = FilmesController.myList;
            //foreach (var item in list)
            //{
            //    if (item.Id == idFilme)
            //    {
            //        dataDevolucao = item.Lancamento == true ? this.DataLocacao.AddDays(2) : this.DataLocacao.AddDays(3);
            //        break;
            //    }
            //}
            
            return dataDevolucao;
        }

       

    }
}
