﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// Add models
using NotaWeb.Models;
using NotaWeb.Entity;
using NotaWeb.Filtros;

namespace NotaWeb.Controllers
{
    [Autorizacao]
    public class ItensController : Controller
    {
        public ActionResult Index()
        {
            // Nao deixar o usuario acessar Disciplinas
            // If trocado por [Autorizacao]
            //if (Session["usuario"] is Aluno)
            //    return RedirectToAction("Index", "Home");

            using (DisciplinaModel model = new DisciplinaModel())
            {
                // Recuperando a sessao
                Funcionario p = (Funcionario) Session["usuario"];
                return View(model.Read(p.Pessoa_id));
            }
                
        }


        // GET: Disciplina
        // nao precisa colocar pq ja eh padrao
        [HttpPost]
        public ActionResult Create()
        {
            // Abre a conexão em model
            using (FuncionarioModel model = new FuncionarioModel())
            {
                // inserir método
                // Tipo de dado dinamico -- vai conter todos os professores cadastrados
                ViewBag.Funcionarios = model.Read();

            } // fecha conexao
            return View();
        }

        // Executar por Post - pega dados do form e insere no banco
        [HttpPost]
        public ActionResult Create(Itens entity)
        {
            // toda vez q for acessar o banco
            using (DisciplinaModel model = new DisciplinaModel())
            {
                model.Create(entity);
            }

            // retornar para view
            return RedirectToAction("Create");
        }
    }
}