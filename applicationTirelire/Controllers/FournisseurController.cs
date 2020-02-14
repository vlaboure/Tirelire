﻿using applicationTirelire.DataAccess;
using applicationTirelire.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace applicationTirelire.Controllers
{
    public class FournisseurController : Controller
    {
        //Instanciation du EFRepository pour l'entité Fournisseur
        IRepository<Fournisseur> repFournisseur = new EFRepository<Fournisseur>();
        // GET: Fournisseur
        public ActionResult Index()
        {
            return View(repFournisseur.Lister().Where(f => f.Statut != 0));         
        }
        public ActionResult Afficher()
        {
            return View("Index",repFournisseur.Lister());
        }

        // GET: Fournisseur/Details/5
        public ActionResult Details(int id)
        {
            return View(repFournisseur.Trouver(id));
        }
        //[Authorize(Roles = "Administrator")]
        // GET: Fournisseur/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Fournisseur/Create
        [HttpPost]
        public ActionResult Create(Fournisseur fournisseur)
        {
            try
            {
                repFournisseur.Ajouter(fournisseur);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Fournisseur/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repFournisseur.Trouver(id));
        }
        // POST: Fournisseur/Edit/5
        [HttpPost]
        public ActionResult Edit(Fournisseur fournisseur)
        {
            try
            {
                repFournisseur.Modifier(fournisseur);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Fournisseur/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repFournisseur.Trouver(id));
        }
        // POST: Fournisseur/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                Fournisseur fournisseurASupprimer = repFournisseur.Trouver(id);
                fournisseurASupprimer.Statut = 0;
                repFournisseur.Modifier(fournisseurASupprimer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
